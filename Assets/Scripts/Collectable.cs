using UnityEngine;

public class Collectable : MonoBehaviour
{
    int type;
    public GameObject powerUp;
    public GameObject debuff;
    public GameObject light;
    public GameObject coin;
    public GameObject multiplier;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        type = Random.Range(0, 30);    //1 - PowerUp; 2 - Debuff; 3 - Ilumina o player; 4 - coin; 5 - Multiplicador
        if (type < 5)
        {
            Instantiate(powerUp, transform);
        }
        else if (type < 9)
        {
            Instantiate(debuff, transform);
        }
        else if (type < 12)
        {
            Instantiate(light, transform);
        }
        else if (type < 22)
        {
            Instantiate(coin, transform);
        }
        else if (type < 25)
        {
            Instantiate(debuff, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
