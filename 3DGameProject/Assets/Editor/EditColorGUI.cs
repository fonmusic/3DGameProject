using UnityEngine;
using UnityEditor;

public class EditColorGUI : EditorWindow
{

    public Color myColor; // градиент цвета
    public MeshRenderer GO; // ссылка на рендер объекта

    public Material newMaterial;
    private Transform MainCamera;

    [MenuItem("MyTools / Generate and color")]

    public static void ShowMyComponent()
    {
        GetWindow(typeof(EditColorGUI), false, "Generate and color");
    }

    private void OnGUI()
    {

        GO = EditorGUILayout.ObjectField("Mesh Object", GO, typeof(MeshRenderer), true) as MeshRenderer;
        newMaterial = EditorGUILayout.ObjectField("Material Object", newMaterial, typeof(Material), true) as Material;


         if (GO)
        {
            myColor = RGBSlider(new Rect(10, 50, 200, 20), myColor); // отрисовка пользовательского набора слайдеров
            GO.sharedMaterial.color = myColor; // покраска объекта
        }
        else
        {
            if (GUI.Button(new Rect(10, 60, 100, 30), "Create"))
            {
                MainCamera = Camera.main.transform;

                GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                MeshRenderer GORenderer = temp.GetComponent<MeshRenderer>();
                GORenderer.sharedMaterial = newMaterial;
                temp.transform.position = new Vector3(MainCamera.position.x, MainCamera.position.y, MainCamera.position.z + 5f);
                GO = GORenderer;
            }
        }

        if (GUI.Button(new Rect(10, 160, 100, 30), "Delete"))
        {
            DestroyImmediate(GO.gameObject);
            GO = null;
        }
    }

    
    // отрисовка пользовательского слайдера 
    float LabelSlider(Rect screenRect, float sliderValue, float sliderMaxValue, string labelText) // ДЗ - добавить minValue
    {
        //создаем прямоугольник с координатами в пространстве и заданными высотой и шириной
        Rect labelRect = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);

        //создаем лейбл на экране 
        GUI.Label(labelRect, labelText);

        Rect sliderRect = new Rect(screenRect.x + screenRect.width / 2, screenRect.y, screenRect.width / 2, screenRect.height);
        sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, 0.0f, sliderMaxValue);
        return sliderValue;
    }

    float LabelSlider2(Rect screenRect, float sliderValue, float sliderMinValue, float sliderMaxValue, string labelText) // ДЗ - добавить minValue
    {
        //создаем прямоугольник с координатами в пространстве и заданными высотой и шириной
        Rect labelRect = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);

        //создаем лейбл на экране 
        GUI.Label(labelRect, labelText);

        Rect sliderRect = new Rect(screenRect.x + screenRect.width / 2, screenRect.y, screenRect.width / 2, screenRect.height);
        sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, sliderMinValue, sliderMaxValue);
        return sliderValue;
    }

    // отрисовка тройной слайдер группы, где каждый слайдер отвечает за свой цвет

    Color RGBSlider(Rect screenRect, Color rgb)
    {
        // использую пользовательский слайдер, создаем слайдеры
        rgb.r = LabelSlider(screenRect, rgb.r, 1.0f, "Red");
        screenRect.y += 20;// делаем промежуток

        rgb.g = LabelSlider(screenRect, rgb.g, 1.0f, "Green");
        screenRect.y += 20;// делаем промежуток

        rgb.b = LabelSlider(screenRect, rgb.b, 1.0f, "Blue");
        screenRect.y += 20;// делаем промежуток

        rgb.a = LabelSlider(screenRect, rgb.a, 1.0f, "Alpha");
        screenRect.y += 20;// делаем промежуток

        rgb.a = LabelSlider2(screenRect, rgb.a, 0.5f, 1.0f, "Alpha min 50%");
        screenRect.y += 20;// делаем промежуток

        return rgb;
    }
}