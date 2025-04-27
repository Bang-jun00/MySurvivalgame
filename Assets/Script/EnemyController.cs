using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{    
    public EnemyPool enemyPool;
    

    [Header("DamageDelay")]
    public float damage;
    public float hitWaitTime = 1f;
    private float hitCounter;

    [Header("EnemyMove")]
    public Rigidbody2D rb;    
    [SerializeField] float moveSpeed;
    private Transform target;

    [Header("EnemyHealth")]
    public float health;
    public float defaultHealth;

    [Header("KnockBack")]
    public float knockBackTime = 0.5f;
    private float knockBackCounter;

    [Header("EXP")]
    public int giveExp; //드랍할 경험치

    
    
    void Awake()
    {
        defaultHealth = health;
    }
    void Start()
    {
        target = PlayerHP.instance.transform;
    }

    
    void Update()
    {
        if(knockBackCounter > 0)
        {
            knockBackCounter -= Time.deltaTime;
            
            if(moveSpeed > 0)//moveSpeed를 음수로(뒤로이동)
            {
                moveSpeed = -moveSpeed * 2f;
            }

            if(knockBackCounter <= 0)
            {
                moveSpeed = Mathf.Abs(moveSpeed * 0.5f); //Knockback 끝났으면 복구
            }
        }
        
        rb.velocity = (target.position - transform.position).normalized * moveSpeed;
        
        if(hitCounter > 0f)
        {
            hitCounter -= Time.deltaTime; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && hitCounter <= 0f)
        {
            PlayerHP.instance.TakeDamage(damage);
            hitCounter = hitWaitTime;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;        

        if(health <= 0f)
        {
            ExpLevelController.instance.SpawnExp(transform.position, giveExp); // 경험치 드랍
            enemyPool.ReturnEnemy(gameObject);// 적 풀로 리턴
        }
        
        DamageNumberController.instance.SpawnDamage(damage, transform.position);
    }

    public void TakeDamage(float damage, bool knockBack)
    {
        TakeDamage(damage);

        if(knockBack == true)
        {
            knockBackCounter = knockBackTime;
        }
    }

    public void ResetEnemy()
    {
        health = defaultHealth; //체력 초기화
        hitCounter = 0f;
    }
}    