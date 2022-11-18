using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotate : MonoBehaviour
{
    [SerializeField]
    Color Sky, Equator, Ground, SunColor; // цвета Солнца и Ambient SkyBox

    [SerializeField]
    float RotateSpeed; // скорость вращения Солнца

    Light Sun; // ссылка на источник света


    // Start is called before the first frame update
    void Start()
    {
        Sun = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        // Настраиваем Ambient Skybox Color
        RenderSettings.ambientSkyColor = Sky;
        RenderSettings.ambientEquatorColor = Equator;
        RenderSettings.ambientGroundColor = Ground;
        // Настраиваем цвет Солнца
        Sun.color = SunColor;
        // Вращаем Солнце
        transform.Rotate(transform.right, RotateSpeed, Space.Self);
    }
}
