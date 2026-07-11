using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyAttack : MonoBehaviour
{
    
    public Animator animator;
    public Transform firePoint;
    public GameObject projecTile;
    Vector2 attackDirection;
    public float fireRate = 1f;
    float nextFireTime = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime) 
        {
            Attack();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Attack()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        attackDirection = (mousePos - firePoint.position).normalized;
        animator.SetFloat("LastInputX" , attackDirection.x);
        animator.SetFloat("LastInputy" , attackDirection.y);
        animator.SetTrigger("Attack");
    }

    public void Shoot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        firePoint.localPosition = attackDirection * 0.5f;

        GameObject obj = Instantiate(projecTile , firePoint.position , Quaternion.identity);

        obj.GetComponent<MagicRange>().SetDirection(attackDirection); 
    }
}
