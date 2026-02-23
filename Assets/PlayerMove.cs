using System.Runtime.InteropServices;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    CharacterController cc;
    float v;
    float h;
    Vector3 camDir;
    [SerializeField] float sensibility = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        cc.SimpleMove(Vector3.forward * v * sensibility + Vector3.right * h * sensibility);
    }

    void LateUpdate()
    {
        camDir = Camera.main.transform.forward;
        camDir.y = 0;
        transform.rotation = Quaternion.LookRotation(camDir);
    }
}
