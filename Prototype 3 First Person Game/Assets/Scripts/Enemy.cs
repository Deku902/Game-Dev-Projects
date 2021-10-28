using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Enemy : MonoBehaviour
{

    [Header("Stats")]
    public int curHP;
    public int maxHP;
    public int scoreToGive;

    [Header("Movement")]
    public float moveSpeed;
    public float attackRange;

    public float xPathOffset;


    private List<Vector1> path;

    private Weapon weapon;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
          //Gather Components
          weapon = GetComponents<weapon>();
          target = FindObjectOfType<PlayerController>().gameObject;

          InvokeRepeating("UpdatePath", 0.0f, 0.5f);
    }
    
    void UpdatePath ()
    {
        // calculate a path to the target
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.postition, target.transform.postition, navMesh.AllAreas, navMeshPath);

        // Save Path as a list
        path = navMeshPath.corners.ToList();
    }

    void ChaseTarget()
    {
        if(path.Count == 0)
             return;
        
        // Move towards the closest path
        transform.positition = Vector3.MoveTowards(transform.postition, path[0] + new Vector3(0, yPathOffset, 0), moveSpeed * Time.deltaTime);
         
         if(transform,postition == path[0] + new Vector3(0, yPathOffset, 0))
            path.RemoveAt[0];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
