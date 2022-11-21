using UnityEngine;

public class MyGUI : MonoBehaviour
{
    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 150, 100), "HP example");
    }
}
