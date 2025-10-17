
using UnityEngine;
using UnityEngine.UIElements;

public class ModuleGeneration : MonoBehaviour
{
    public GameObject[] modules;
    public int actualModule = 0;
    public float destroyTime = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z >= 100 * actualModule -10)
        {
            if (actualModule > 0)
            {
                Instantiate(modules[Random.Range(0, 3)], Vector3.forward * (actualModule * 100 - 5) + Vector3.up * -10, Quaternion.identity);
                actualModule++;
            }
            else
            {
                Instantiate(modules[Random.Range(0, 3)], Vector3.forward * (actualModule * 100 - 5), Quaternion.identity);
                actualModule++;
            }
        }
    }
}
