using System;
using NUnit.Framework;
using UnityEditor.Rendering;
using UnityEngine;

public class NewPlayer : MonoBehaviour
{
    private Vector2 startTouch;
    public int route = 0;
    [SerializeField] float routeDistance = 2f;
    public int routeQuantity = 5;   //only odd
    public float FrontalSpeed = 10;
    public float lateralSpeed = 10;
    public float delayTime = 3f;
    public float delayCounter = 3f;
    bool isDelayed = false;
    public Material playerMaterial;
    Color original;

    void Start()
    {
        routeQuantity = (routeQuantity - 1) / 2;
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
        original = playerMaterial.color;
    }

    void Update()
    {
        GetInputs();
        FrontalMovement();
        SideMovement();
        if (delayCounter < delayTime) delayCounter += Time.deltaTime;
        else isDelayed = false;
    }

    void FrontalMovement()
    {
        if (!isDelayed) transform.Translate(Vector3.forward * FrontalSpeed * Time.deltaTime, Space.World);
        else transform.Translate(Vector3.forward * FrontalSpeed / 3 * Time.deltaTime, Space.World);
    }

    void SideMovement()
    {
        route = Mathf.Clamp(route, -routeQuantity, routeQuantity);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(route * routeDistance,
        transform.position.y, transform.position.z), lateralSpeed * Time.deltaTime);
    }

    void GetInputs()
    {
        bool leftInputs = Input.GetKeyDown(KeyCode.A) && route > -routeQuantity;
        bool rightInputs = Input.GetKeyDown(KeyCode.D) && route < routeQuantity;

#if UNITY_ANDROID || UNITY_IOS
    if (Input.touchCount > 0)
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            startTouch = touch.position;
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            Vector2 swipeDelta = touch.position - startTouch;

            // se o movimento horizontal for predominante
            if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y) && Mathf.Abs(swipeDelta.x) > 50f)
            {
                if (swipeDelta.x > 0 && route < routeQuantity)
                    rightInputs = true;
                else if (swipeDelta.x < 0 && route > -routeQuantity)
                    leftInputs = true;
            }
        }
    }
#endif

        if (leftInputs) route--;
        if (rightInputs) route++;
    }
    public void Delay()
    {
        isDelayed = true;
        delayCounter = 0;
    }

    public void PowerUp()
    {
        Invoke("EndPowerUp()", 5);
        lateralSpeed *= 2;
        playerMaterial.color = Color.yellow;
    }

    public void EndPowerUp()
    {
        lateralSpeed /= 2;
        playerMaterial.color = original;
    }
    
}
