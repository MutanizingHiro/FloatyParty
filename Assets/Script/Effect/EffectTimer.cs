using System.Threading;
using UnityEngine;

public class EffectTimer : MonoBehaviour
{
    private float timer;
    public float timerLimit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if( timer > timerLimit )
        {
            Destroy(this.gameObject);
        }
    }
}
