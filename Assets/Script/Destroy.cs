using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] float destroyTime;
    void Start()
    {
        Destroy(gameObject,destroyTime);
    }
}
