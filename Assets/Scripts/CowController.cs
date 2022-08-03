using System;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

public class CowController : MonoBehaviour
{
    public Collider2D parentCollider;
    public Collider2D childCollider;
    public NavMeshAgent agent;
    public Transform player;
    public Animator animator;

    private DateTime _eatingTimestamp;
    private Random _random;
    
    // Start is called before the first frame update
    void Start()
    {
        _random = new Random();
        _eatingTimestamp = DateTime.UtcNow;
        
        Physics2D.IgnoreCollision(
            childCollider, 
            parentCollider, true);

        agent.updateRotation = false;
        agent.updateUpAxis = false;
        
        animator.SetFloat("Speed", agent.velocity.sqrMagnitude);
    }

    void Update()
    {
        var distance = player.transform.position - transform.position;

        // Cows don't eat while they are running.
        if (agent.velocity.sqrMagnitude > 0.01)
        {
            animator.SetBool("Eating", false);
        }
        
        // Cows are curious animals. They'll follow you around when you're getting close.
        if (distance.magnitude < 5f)
        {
            agent.enabled = true;
            agent.destination = player.transform.position;
        }
        else
        {
            agent.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        var timeDifference = DateTime.UtcNow - _eatingTimestamp;

        if (timeDifference.TotalSeconds > 3 && agent.velocity.sqrMagnitude < 0.01)
        {
            _eatingTimestamp = DateTime.UtcNow;
            animator.SetBool("Eating", _random.NextDouble() < 0.7);
        }
    }
}
