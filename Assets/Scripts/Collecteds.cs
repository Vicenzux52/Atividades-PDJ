using UnityEngine;
using TMPro;

public class Collecteds : MonoBehaviour
{
    NewPlayer player;
    public TextMeshProUGUI score;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<NewPlayer>();
        score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = player.coin + " :Coins";
    }
}
