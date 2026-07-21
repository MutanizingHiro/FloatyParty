using UnityEngine;
using TMPro;
public class GetScore : MonoBehaviour
{
    TextMeshProUGUI text;
    PlayerManager playerManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerManager = GameObject.FindFirstObjectByType<PlayerManager>();
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score:" + playerManager.score;
    }
}
