using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("DamageDelay")]
    public float damage;
    public float hitWaitTime = 1f;
    private float hitCounter;

    [Header("EnemyMove")]
    public Rigidbody2D rb;    
    [SerializeField] float moveSpeed;
    private Transform target;
    
    
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
}
