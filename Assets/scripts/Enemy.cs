using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField]  float moveSpeed = 2f;
    Rigidbody2D r;
    Health health;
    Transform target;
    Vector2 moveDirection;
    [SerializeField] float detectRange = 5f;
    Animator animator;
    [SerializeField] float attackRange = 2f;
    [SerializeField] float attackRate = 1f;
    float nextAttackTime = 0;

    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask playerLayers;
    [SerializeField] int attackDamage = 40;

    
    float targetUpdateTime = 1f;
    float timer;

    private void Awake(){
        r = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
    }

    void FindClosestTarget()
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");

        float closestDistance = Mathf.Infinity;
        Transform closest = null;

        foreach(GameObject p in player)
        {
            float distance = Vector2.Distance(transform.position , p.transform.position);

            if(distance < closestDistance)
            {
                closestDistance = distance;
                closest = p.transform;
            }

            target = closest;
        }
    }
    
    void Start()
    {
        FindClosestTarget();
    }



    // Update is called once per frame
    void Update()
    {
       
       timer += Time.deltaTime;

       if(timer >= targetUpdateTime)
        {
            FindClosestTarget();
            timer = 0;
        }
        if(target){
            float distance = Vector2.Distance(transform.position , target.position);

           
            if(distance <= attackRange)
            {
                moveDirection = Vector2.zero;
                animator.SetBool("isWalking" , false);

                if(Time.time >= nextAttackTime)
                {
                    animator.SetTrigger("Attack");
                    nextAttackTime = Time.time + 1f / attackRate;
                   
                }
            }
            else if(distance <= detectRange){
                Vector3 direction = (target.position - transform.position).normalized;
                moveDirection = direction;
                attackPoint.localPosition = moveDirection.normalized * 0.6f;
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

    public void TakeDamage(int damage)
    {
         health.TakeDamage(damage);

        animator.SetTrigger("Hurt");

        if(health.currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetBool("isDied" , true);
        Destroy(gameObject);
    }

    public void DealDamage()
    {

        Debug.Log(gameObject.name + " DealDmage");
        Collider2D[] players = Physics2D.OverlapCircleAll(attackPoint.position , attackRange , playerLayers);
        Debug.Log(players.Length);
        foreach(Collider2D player in players)
        {
            Debug.Log("Hit : " + player.name);
            Health health = player.GetComponent<Health>();

            if(health != null)
            {
                health.TakeDamage(attackDamage);
            }
        }
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position , attackRange);
    }


}
