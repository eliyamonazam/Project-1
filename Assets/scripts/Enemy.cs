using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField]  float moveSpeed = 2f;
    Rigidbody2D r;
    public Transform target;
    Vector2 moveDirection;
    [SerializeField] float detectRange = 5f;
    Animator animator;

    private void Awake(){
        r = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(target){
            float distance = Vector2.Distance(transform.position , target.position);
            if(distance <= detectRange){
                Vector3 direction = (target.position - transform.position).normalized;
                moveDirection = direction;
                animator.SetBool("isWalking" , true);
                animator.SetFloat("X" , moveDirection.x);
                animator.SetFloat("y" , moveDirection.y);
                animator.SetFloat("LastX" , moveDirection.x);
                animator.SetFloat("LastY" , moveDirection.y);
            }
            else{
                
                moveDirection = Vector2.zero;
            }
            
        }

        
    }

    private void FixedUpdate(){

        if(target){
            r.velocity = new Vector2(moveDirection.x , moveDirection.y) * moveSpeed; 
        }
    }
}
