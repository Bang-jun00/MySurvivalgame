using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    [Header("damage")]
    public float damageValue;
    [Header("LifeTime")]
    public float lifeTime;
    [Header("KnockBack")]
    public bool knockBack;

    void Start()
    {
        Destroy(gameObject, lifeTime); //유지후 자동 삭제
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyController>().TakeDamage(damageValue, knockBack);
        }
    }

}
