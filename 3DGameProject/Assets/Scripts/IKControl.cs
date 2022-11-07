using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class IKControl : MonoBehaviour
{
    protected Animator animator;

    public bool ikActive = false;
    public Transform rightHandObj = null;
    public Transform leftHandObj = null;
    public Transform lookObj = null;
    public Transform head = null;

    public float distance = 3;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    [SerializeField]
    private float currentHeadRotation;
    [SerializeField]
    private float headRotationSpeed = 0.2f;


    //Вызывается при расчёте IK
    private void OnAnimatorIK()
    {
        if (animator)
        {
            //Если, мы включили IK, устанавливаем позицию и вращение
            if (ikActive)
            {
                // Устанавливаем цель взгляда для головы
                if (lookObj != null)
                {
                    if (head)
                    {
                        if (Vector3.Distance(head.position,lookObj.position) < distance)
                        {
                            animator.SetLookAtWeight(currentHeadRotation);
                            animator.SetLookAtPosition(lookObj.position);

                            currentHeadRotation += Time.deltaTime * headRotationSpeed;
                            if (currentHeadRotation > 1)
                            {
                                currentHeadRotation = 1;
                            }
                        }
                        else
                        {
                            animator.SetLookAtWeight(currentHeadRotation);
                            currentHeadRotation -= Time.deltaTime * headRotationSpeed;
                            if (currentHeadRotation < 0)
                            {
                                currentHeadRotation = 0;
                            }

                        }
                    }
                }

                // Устанавливаем цель для правой руки и выставляем её в позицию
                if (rightHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, currentHeadRotation);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, currentHeadRotation);
                    animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
                }
                // Устанавливаем цель для левой руки и выставляем её в позицию
                if (leftHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, currentHeadRotation);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, currentHeadRotation);
                    animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.rotation);
                }
            }
            // Если IK неактивен, ставим позицию и вращение рук и головы в изначальное положение
            else
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                //animator.SetLookAtWeight(0);
            }
        }
    }
}
