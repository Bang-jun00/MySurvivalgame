using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    private Transform target;
    void Start()
    {
        target = FindObjectOfType <PlayerController>().transform;
    }

    
    void Update()
    {
        rb.velocity = (target.position - transform.position).normalized * moveSpeed;
    }
}
