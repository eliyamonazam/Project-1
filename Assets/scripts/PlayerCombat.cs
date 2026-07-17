using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;  
    public int attackDmg = 40;
    public float attackRate = 2f;
    
    float nextAttackTime = 0;
    private int bonusDamage = 0; 

    void Update()
    {
        if(Time.time >= nextAttackTime && Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position , attackRange , enemyLayers);

        int finalDmg = attackDmg + bonusDamage;

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(finalDmg);
        }
        
        bonusDamage = 0; 
    }

    public void BoostDamage(int amount) => bonusDamage += amount;

    void OnDrawGizmosSelected()
    {
        if(attackPoint != null)
            Gizmos.DrawWireSphere(attackPoint.position , attackRange);
    }
}