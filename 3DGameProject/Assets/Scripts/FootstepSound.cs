using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioSource footstepSource;
    public AudioClip[] clip;

    // Start is called before the first frame update
    void Start()
    {
        footstepSource = gameObject.GetComponent<AudioSource>();
    }

    void Footstep()
    {
        int sampleIndex;
        sampleIndex = Random.Range(0, clip.Length);
        footstepSource.PlayOneShot(clip[sampleIndex]);
        Debug.Log("Шаг!");
    }
}
