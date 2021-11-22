using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

 public class EnemyController : MonoBehaviour
{
    [SerializeField] public float lookRadius = 5f;

    Transform target;
    NavMeshAgent agent;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected() 
    {
        
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, lookRadius);
        
    }
}
