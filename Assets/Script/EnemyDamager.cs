using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    [Header("damage")]
    public float damageValue;
    [Header("LifeTime")]
    public float lifeTime;

    void Start()
    {
        Destroy(gameObject, lifeTime); //유지후 자동 삭제
    }

    
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(damageValue);
        }
    }
}
