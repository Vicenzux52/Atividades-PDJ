using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public Button btn;
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    public void AddEvento(UnityAction env)
    {
        btn.onClick.AddListener(env);
    }
}
