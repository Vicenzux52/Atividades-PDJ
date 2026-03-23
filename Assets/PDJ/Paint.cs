using UnityEngine;

public class Paint : MonoBehaviour
{
    void OnMouseOver()
    {
        GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }
}
