using UnityEngine;

public class LightC : MonoBehaviour
{
    NewPlayer player;
    public Material material;
    Renderer render;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<NewPlayer>();
        render = transform.GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Light");
        material.EnableKeyword("_EMISSION");
        material.SetColor("_EmissionColor", Random.ColorHSV());
        Destroy(gameObject);
    }
}
