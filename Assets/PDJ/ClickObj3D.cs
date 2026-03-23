using UnityEngine;

public class ClickObj3D : MonoBehaviour
{
    void OnMouseDown()
    {
        UIController.instance.AddEvento(Evento);
    }
    void Evento()
    {
        Debug.Log("ovô");
    }
}
