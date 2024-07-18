using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public NavMeshAgent agent;
    public Transform player;
    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
    }
}
