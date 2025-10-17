using UnityEngine;

public class Module : MonoBehaviour
{
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0)
            transform.position = Vector3.MoveTowards(transform.position, Vector3.forward * transform.position.z, 20 * Time.deltaTime);
        if (player.transform.position.z - transform.position.z > 105)
            Destroy(gameObject);
    }
}
