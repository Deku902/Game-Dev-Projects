using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PickupType
{
    Health,
    Ammo
}
public class Pickup : MonoBehaviour
{
    public PickupType type;
    public int value;

    [Header ("Bobbiing Anim")]
    public float rotationSpeed;
    public float bobSpeed;
    public float bobHeight;

    // Start is called before the first frame update
    void Start()
    {
        
    }
   

   void OnTriggerEnter(Collider other)
   {
       if(other.CompareTag("player"))
       {
           PlayerController player = other.GetComponent<PlayerController>();

           switch(type)
           {
               case PickupType.Health:
               player.GiveHealth(value);
               break;

               case PickupType.Ammo:
               player.GiveAmmo(value);
               break;
            }

            Destroy(gameObject);
       }
   }
    // Update is called once per frame
    void Update()
    {
        //Rotating
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        //
        Vector3 offset = (bobbingUp == true ? new Vector3(0,bobHeight))
    }
}
