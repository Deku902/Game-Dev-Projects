using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBeanController : MonoBehaviour
{
    // Movement
    public float moveSpeed;

    // Camera
    public float lookSensitivity; // Mouse Look Sensitivity
    public float maxLookX; //Lowest Down We Can Look
    public float minLookX; //Highest up We Can look
    private float rotX; //Current X Rotation of the Camera
    // GameObjects and Components
    private Camera cam;
    private Rigidbody rb;

    void Awake()
    {
        //Get The Components
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }
        

    

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        rb.velocity = new Vector3(x, rb.velocity.y, z);

    }
    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX = Input.GetAxis("Mouse Y") * lookSensitivity;
    }
}
