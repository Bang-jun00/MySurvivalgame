using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Transform enemySprite;

    [SerializeField] float speed;

    [SerializeField] float minSize, maxSize;

    private float activeSize;
    
    void Start()
    {
        activeSize = maxSize;

        speed = speed * Random.Range(0.75f, 1.25f);
    }

    
    void Update()
    {
        enemySprite.localScale = Vector3.MoveTowards(enemySprite.localScale, Vector3.one * activeSize, speed * Time.deltaTime);
           

        if(enemySprite.localScale.x == activeSize)
        {
            if(activeSize == maxSize)
            {
                activeSize = minSize;
            }
            else
            {
                activeSize = maxSize;
            }
        }
    }
}
