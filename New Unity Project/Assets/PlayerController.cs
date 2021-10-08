using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 25.0f;
    public float turnSpeed = 50.0f;
    public float hInput = 9.17f;
    public float vInput = 4.45f;

    public float xRange = 6.16f;
    public float yRange = 4.5f;

    public GameObject projectile;
    public Transform launcher;
    public Vector3 offset = new Vector3(0,1,0);

    // public float health;

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

        //create a wall on the -x side
              if(transform.position.x < -xRange)
              {
                  transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
              }
        // Create a wall on x side
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3( xRange, transform.position.y, transform.position.z);
        }

        if(transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }

        if(transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }

        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectile, launcher.transform.position, launcher.transform.rotation);
        }
    }

}
