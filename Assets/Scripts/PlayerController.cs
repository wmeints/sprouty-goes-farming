using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private static readonly Vector2 _raycastSize = new Vector2(1.5f, 1.5f);

    public float speed;

    public Rigidbody2D rigidBody;
    public Canvas dialogCanvas;
    public Animator animator;


    void Update()
    {
        CheckInteraction();    
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
        
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        var movement = new Vector2(horizontal, vertical);

        rigidBody.velocity = movement * speed;

        animator.SetFloat("HorizontalMovement", horizontal);
        animator.SetFloat("VerticalMovement", vertical);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    public void OpenInteractableIcon()
    {
        Debug.Log("Opening interactable icon");
    }

    public void CloseInteractableIcon()
    {
        Debug.Log("Closing interactable icon");
    }

    private void CheckInteraction()
    {
        var hits = Physics2D.BoxCastAll(transform.position, _raycastSize, 0.0f, Vector2.zero);
        var interactableHits = hits.Where(x => x.IsInteractable()).ToList();
        
        if (interactableHits.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                foreach (var interactableHit in interactableHits)
                {
                    interactableHit.Interact();
                }
                
            }
        }
        else
        {
            // Hide the dialog, we're not anywhere near an interactable object.
            dialogCanvas.gameObject.SetActive(false);
        }
    }
}