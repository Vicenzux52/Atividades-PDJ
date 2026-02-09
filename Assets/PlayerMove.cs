using System.Runtime.InteropServices;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    CharacterController cc;
    float v;
    float h;
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
        cc.Move(Vector3.forward * v * sensibility + Vector3.right * h * sensibility);
    }
}
