using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowController : MonoBehaviour
{
    public Collider2D parentCollider;
    public Collider2D childCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(
            childCollider, 
            parentCollider, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
