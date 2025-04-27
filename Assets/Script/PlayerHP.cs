using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    //싱글톤 설정
    public static PlayerHP instance;    
    private void Awake()
    {
        instance = this;
    }

    [Header("Health")]
    [SerializeField] float currentHealth, maxHealth;
    
    public Slider healthSlider; //체력바 연결할 변수

    void Start()
    {
        currentHealth = maxHealth;

        healthSlider.maxValue = maxHealth; // Max 설정
        healthSlider.value = currentHealth;// value(현재값) 설정
    }
        

    public void TakeDamage(float damage)
    { 
        currentHealth -= damage;

        healthSlider.value = currentHealth; //데미지 입으면 체력바 업데이트

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
