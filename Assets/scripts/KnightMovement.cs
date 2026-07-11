using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KnightMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D r;
    private Vector2 moveInput;
    private Animator animator;
    PlayerCombat playerCombat;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerCombat = GetComponent<PlayerCombat>();
    }

    // Update is called once per frame
    void Update()
    {
         r.velocity = moveInput * moveSpeed;
    }

     public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking" , true);
        
        if (context.canceled)
        {
            animator.SetBool("isWalking" , false);
            animator.SetFloat("LastInputX" , moveInput.x);
            animator.SetFloat("LastInputy" , moveInput.y);
        }
        
        moveInput = context.ReadValue<Vector2>();
        if(moveInput != Vector2.zero)
        {
            playerCombat.attackPoint.localPosition = moveInput.normalized * 0.6f;
            animator.SetFloat("InputX" , moveInput.x);
            animator.SetFloat("InputY" , moveInput.y);
        }
    }
}
