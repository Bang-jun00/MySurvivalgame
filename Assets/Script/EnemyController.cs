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

    public void ResetEnemy()
    {
        health = defaultHealth; //체력 초기화
        hitCounter = 0f;
    }
}    