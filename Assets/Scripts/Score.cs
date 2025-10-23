using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Transform player;
    public float points;
    float lastZ = 0;
    public TextMeshProUGUI score;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").transform;
        score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        points += (player.position.z - lastZ) / 10;
        lastZ = player.position.z;
        score.text = "Score: " + (int)points;
    }
}
