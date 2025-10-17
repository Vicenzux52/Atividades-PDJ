using UnityEngine;

public class lowObstacle : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) collision.gameObject.GetComponent<NewPlayer>().Delay();
        Destroy(gameObject);
    }
    
}
