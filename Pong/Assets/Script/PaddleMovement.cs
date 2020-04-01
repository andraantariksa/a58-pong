using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField]
    private float velocity = 10;
    [SerializeField]
    private string keyUp = "w";
    [SerializeField]
    private string keyDown = "s";

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKey(keyUp) && transform.position.y <= 3.2)
        {
            transform.position += new Vector3(0.0f, velocity * Time.deltaTime, 0.0f);
        }
        else if (Input.GetKey(keyDown) && transform.position.y >= -3.2)
        {
            transform.position -= new Vector3(0.0f, velocity * Time.deltaTime, 0.0f);
        }
    }
}
