using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public static bool isMouseButtonDown;   //‰Ÿ‚µ‚½uŠÔ
    public static bool isMouseButtonOn;     //‰Ÿ‚µ‚Ä‚¢‚éŠÔ
    public static bool isMouseButtonUp;     //—£‚µ‚½uŠÔ

    private void Update()
    {
        isMouseButtonDown = Input.GetMouseButtonDown(0);
        isMouseButtonOn = Input.GetMouseButton(0);
        isMouseButtonUp = Input.GetMouseButtonUp(0);   
    }
}
