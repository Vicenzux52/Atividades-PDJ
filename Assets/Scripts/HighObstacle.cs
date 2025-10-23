using UnityEngine;
using UnityEngine.SceneManagement;

public class HighObstacle : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ContactPoint contact = collision.contacts[0];
            Vector3 normal = contact.normal;
            if (-Vector3.Dot(transform.forward, -normal) > 0.7f)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
