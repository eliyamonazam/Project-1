using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicRange : MonoBehaviour
{
    
    public float speed = 10f;
    public int damg = 20;
    Vector2 direction;
    public float lifeTime = 5f;

    void Start()
    {
        Destroy(gameObject , lifeTime);
    }
    
    public void SetDirection(Vector2 dir)
    {
        direction = dir;
        Debug.Log("Direction" + direction);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if(enemy != null)
        {
            enemy.TakeDamage(damg);
            Destroy(gameObject);
        }
    }
    public void AddBonusDamage(int amount)
{
    damg += amount; 
}
}
