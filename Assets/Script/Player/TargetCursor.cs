using UnityEngine;
using UnityEngine.UI;
public class TargetCursor : MonoBehaviour
{
    public static bool isMouseButtonDown;   //âüÇµÇΩèuä‘

    private RectTransform rectTranform;

    [SerializeField] Image targetCursorGauge;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTranform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        rectTranform.position = mousePos;
    }
}
