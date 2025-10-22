using UnityEngine;

public class Collectable : MonoBehaviour
{
    int type;
    GameObject powerUp;
    GameObject debuff;
    GameObject light;
    GameObject coin;
    GameObject multiplier;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        type = Random.Range(0, 4);    //1 - PowerUp; 2 - Debuff; 3 - Ilumina o player; 4 - coin; 5 - Multiplicador
        switch (type)
        {
            case 0:
                Instantiate(powerUp);
                break;
            case 1:
                Instantiate(debuff);
                break;
            case 2:
                Instantiate(light);
                break;
            case 3:
                Instantiate(coin);
                break;
            case 4:
                Instantiate(multiplier);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
