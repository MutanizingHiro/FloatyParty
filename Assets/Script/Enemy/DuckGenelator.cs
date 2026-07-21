using UnityEngine;

public class DuckGenelator : MonoBehaviour
{
    public GameObject duck;

    float frame = 2;
    public int generateFrame;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        frame += Time.deltaTime;
        if(frame > generateFrame)
        {
            frame = Random.Range(0, 3);//ŠJnŠÔ‚ğ‚O`‚Q‚É‚·‚é‚±‚Æ‚ÅŠ´Šo‚ª­‚µ•Ï‚í‚éB

            float posX = 11.0f;
            float posY = Random.Range(-4, 2);

            Instantiate(duck, new Vector2(posX, posY), Quaternion.identity);
            
        }
    }
}
