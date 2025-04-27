using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public static PlayerHP instance;    
    
    [SerializeField] float currentHealth, maxHealth;

    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    { 
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
