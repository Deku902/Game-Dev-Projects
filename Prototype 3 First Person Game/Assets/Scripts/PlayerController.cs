using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [Header("Movement")]
    public float moveSpeed;
    public float jumpForce;
    [Header("Camera")]
    public float lookSensitivity; // Mouse Look Sensitivity
    public float maxLookX; //Lowest Down We Can Look
    public float minLookX; //Highest up We Can look
    private float rotX; //Current X Rotation of the Camera
    [Header("GameObjects and Components")]
    private Camera cam;
    private Rigidbody rb;
    private Weapons weapons;
    
    [Header("stats")]
    public int curHP;
    public int maxHP;


   
    
    void Awake()
    {
        //Get The Components
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        weapons = GetComponent<Weapons>();
        // Disable Curser
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();
        // Jump When spacebar is pressed
        if(Input.GetButtonDown("Jump"))
         Jump();

         if(Input.GetButton("Fire1"))

              if(weapons.CanShoot())
              {
                  weapons.Shoot();
              }
    }
    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        //face the direction of the camera
        Vector3 dir = transform.right * x + transform.forward * z;
        // Jump direction
        dir.y = rb.velocity.y;
        // Move in the direction of the camera
        rb.velocity = dir;

    }

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(ray, 1.1f))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;
        //Clamps the Camera up and down rotation
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        // Apply Rotation To Camera
        cam.transform.localRotation = Quaternion.Euler(-rotX,0,0);
        transform.eulerAngles += Vector3.up * y;
        
    }

    public void TakeDamage(int damage)
    {
        curHP -= damage;
        
        if(curHP <= 0) 
            Die();

        GameUI.instance.UpdateHealthBar(curHP, maxHP);
    }

    void Die()
    {
        
    }

     public void GiveHealth (int amountToGive)
    {
        curHP = Mathf.Clamp(curHP + amountToGive, 0, maxHP);
        GameUI.instance.UpdateHealthBar(curHP, maxHP);
    }

    public void GiveAmmo (int amountToGive)
    {
        weapons.curAmmo = Mathf.Clamp(weapons.curAmmo + amountToGive, 0, weapons.maxAmmo);
        GameUI.instance.UpdateAmmoText(weapon.curammo, weapon.maxAmmo);
    }
}
