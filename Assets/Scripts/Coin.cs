using UnityEngine;

public class Coin : MonoBehaviour
{
    NewPlayer player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<NewPlayer>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coin");
        player.GetCoin();
        Destroy(gameObject);
    }
}
