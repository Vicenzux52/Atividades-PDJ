using UnityEngine;

public class Hide : MonoBehaviour
{
    public void Click()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
