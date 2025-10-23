using UnityEngine;

public class PowerUp : MonoBehaviour
{
    NewPlayer player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<NewPlayer>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("PowerUp");
        player.PowerUp();
        Destroy(gameObject);
    }
}
