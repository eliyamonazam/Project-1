using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Health: MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image Fill;

    public int maxHealth = 100;
    public int currentHealth;
    Boolean isDied;
    

    void Start()
    {
        
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = currentHealth;

        if(Fill != null)
        {
           Fill.color = gradient.Evaluate(1f);
        }
        
    }



    public void TakeDamage(int damage)
    {
        if (isDied)
        {
            return;
        }
        Debug.Log("I got damage!");
        currentHealth -= damage;
        slider.value = currentHealth;
        Boolean hasHurt = false;
        

        if(currentHealth <= 0)
        {
           currentHealth = 0;
           slider.value = currentHealth;
           Die();
           return;
        }

       
        if(Fill != null)
        {
            Fill.color = gradient.Evaluate(slider.normalizedValue);
        }
if(gameObject.tag == "Player"){
        foreach(AnimatorControllerParameter a in GetComponent<Animator>().parameters)
        {
            if(a.name == "Hurt")
            {
                hasHurt = true;
                break;
            }
        }

        if (hasHurt)
        {
            GetComponent<Animator>().SetTrigger("Hurt");
            return;
        }
        
        StartCoroutine(HurtFlush());
}

    }

    void Die()
    {
        GetComponent<Animator>().SetBool("isDied" , true);
      
        if(CompareTag("Player")){
        FindObjectOfType<GameOverManager>().GameOver();
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Player");

        foreach(GameObject p in gameObjects)
        {
            p.SetActive(false);
        }
        
        }

        else
        {
            Destroy(gameObject);
        }
       
        
    }

    IEnumerator HurtFlush()
    {
         SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            sr.color = Color.white;
    }

}
