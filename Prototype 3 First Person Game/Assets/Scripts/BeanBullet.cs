using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanBullet : MonoBehaviour
{
    public int damage;
    public float lifeTime;
    private float shootTime;

    public GameObject hitParticle;

    void onEnable()
    {
        shootTime = Time.time;


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
     
     void OnTriggerEnter(Collider other)
     {
         //Did we hit the target aka player
         if(other.CompareTag("Player"))
              other.GetComponent<PlayerController>().TakeDamage(damage);
        else
              if(other.CompareTag("Enemy"))
              other.GetComponent<Enemy>(). TakeDamage(damage);
              //disable Bullet
              gameObject.SetActive(false);
              // Create the hit particile effect
              GameObject obj = Instantiate(hitParticle, transform.position, Quaternion.identity);
              //Destroy Hit Particle
              Destroy(obj, 0.5f);
              

     }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - shootTime >= lifeTime)
           gameObject.SetActive(false);
    }
}
