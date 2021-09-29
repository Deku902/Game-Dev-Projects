using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 25.0f;
    public float turnSpeed = 500.0f;
    public float hInput = 9.17f;
    public float vInput = 4.45f;
    public float xRange = 6.16f;
    public float yRange = 4.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        
        transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime * hInput);
        transform.Translate(Vector3.up * speed * Time.deltaTime * vInput);
        //create right wall
              if(transform.position.x > xRange)
              {
                  transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
              }
    }

}
