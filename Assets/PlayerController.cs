using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rigidBody;

    public Animator animator;
    
    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        var movement = new Vector2(horizontal, vertical);

        rigidBody.velocity = movement * speed;
        
        animator.SetFloat("HorizontalMovement", horizontal);
        animator.SetFloat("VerticalMovement", vertical);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
}
