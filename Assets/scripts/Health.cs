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
        Debug.Log("i got damage!");
        currentHealth -= damage;
        slider.value = currentHealth;

        if(currentHealth <= 0)
        {
           currentHealth = 0;
           slider.value = currentHealth;
           Die();
        }

        if(Fill != null)
        {
            Fill.color = gradient.Evaluate(slider.normalizedValue);
        }

    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
