using System;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Vector2 startTouch;
    private float lastTapTime = 0f;
    private int tapCount = 0;
    private bool isOthers = false;
    Rigidbody rb;
    public float force = 500f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
    }

    void Update()
    {
        DetectSwipes();
        DetectPinch();

        if (!isOthers)
        {
            DetectTaps();
        }
        else if (Input.touchCount == 0)
        {
            isOthers = false;
        }
    }

    void DetectTaps()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            lastTapTime = Time.time;
            tapCount++;
            if (tapCount > 3)
            {
                TripleTap();
                tapCount = 1;
            }
        }
        else if (Time.time - lastTapTime > 0.3f && tapCount > 0)
        {
            switch (tapCount)
            {
                case 1:
                    SingleTap();
                    tapCount = 0;
                    break;
                case 2:
                    DoubleTap();
                    tapCount = 0;
                    break;
                case 3:
                    TripleTap();
                    tapCount = 0;
                    break;
            }
        }
    }

    void SingleTap()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex ^ 1);
    }

    void DoubleTap()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
        gameObject.GetComponent<Light>().color = gameObject.GetComponent<Renderer>().material.color;
    }

    void TripleTap()
    {
        if (gameObject.GetComponent<Light>().range == 0) gameObject.GetComponent<Light>().range = 50;
        else gameObject.GetComponent<Light>().range = 0;
    }

    void DetectSwipes()
    {
        if (Input.touchCount == 1)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
                startTouch = t.position;

            else if (t.phase == TouchPhase.Ended)
            {
                Vector2 delta = t.position - startTouch;

                if (delta.magnitude > 100)
                {
                    isOthers = true;
                    Vector3 delta3D = new Vector3(delta.x, 0, delta.y);
                    if (SceneManager.GetActiveScene().buildIndex != 0) rb.AddForce(delta3D.normalized * force);
                }
            }
        }
    }

    void DetectPinch()
    {
        if (Input.touchCount == 2)
        {
            isOthers = true;

            Touch t0 = Input.GetTouch(0);
            Touch t1 = Input.GetTouch(1);

            Vector2 start0 = t0.position - t0.deltaPosition;
            Vector2 start1 = t1.position - t1.deltaPosition;

            float startDist = (start0 - start1).magnitude;
            float atualDist = (t0.position - t1.position).magnitude;
            if (SceneManager.GetActiveScene().buildIndex != 0 && atualDist > startDist + 10 && transform.localScale.x < 50)
                transform.localScale += Vector3.one * 0.1f;
            else if (SceneManager.GetActiveScene().buildIndex != 0 && atualDist < startDist - 10 && transform.localScale.x > 3)
                transform.localScale -= Vector3.one * 0.1f;
        }
    }
}