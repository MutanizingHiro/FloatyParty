using UnityEngine;

public class Cursor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //マウス座標取得
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(worldMousePos.x,worldMousePos.y,0);
    }
}
