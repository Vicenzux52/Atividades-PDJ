using UnityEngine;

public class Multiplier : MonoBehaviour
{
    Score score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<Score>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Multiplier");
        score.points *= 2;
        Destroy(gameObject);
    }
}
