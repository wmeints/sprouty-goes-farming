using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CowController : MonoBehaviour
{
    public Collider2D parentCollider;
    public Collider2D childCollider;
    public NavMeshAgent agent;
    public Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(
            childCollider, 
            parentCollider, true);

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        var distance = player.transform.position - transform.position;

        if (distance.magnitude < 5f)
        {
            agent.destination = player.transform.position;
            agent.enabled = true;
        }
        else
        {
            agent.enabled = false;
        }
    }
}
