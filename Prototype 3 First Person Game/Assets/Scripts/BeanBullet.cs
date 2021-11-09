using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanBullet : MonoBehaviour
{
    public int damage;
    public float lifeTime;
    private float shootTime;

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
              other.GetComponent<Enemy>().TakeDamage(damage);
              //disable Bullet
              gameObject.SetActive(false);
     }

    // Update is called once per frame
    void Update()
    {
        if(lifeTime.time - shootTime >= lifeTime)
        GameObject.getAction(false);
    }
}
