using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner")]
    public GameObject enemySpawn; //스폰할 프리팹
    public float timeToSpawn = 2f; //적이 생성되는 간격
    private float spawnTimer; //타이머

    [Header("SpawnPoint")]
    public Transform minSpawn, maxSpawn;
    public Transform target;

    void Start()
    {
        spawnTimer = timeToSpawn;
        
        target  = PlayerHP.instance.transform; //싱글톤에서 플레이어 Transform 가져오기
    }

    
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer < 0f)
        {
            spawnTimer = timeToSpawn;

            Instantiate(enemySpawn, SelectSpawnPoint(), transform.rotation); //적 생성
        }

        transform.position = target.position; // 스포너가 player를 따라다님   
    }

    public Vector3 SelectSpawnPoint()
    {
        Vector3 spawnPoint = Vector3.zero;

        bool spawnVerticalEdge = Random.Range(0f, 1f) > 0.5f; // true = 수직(왼쪽/오른쪽)소환, false = 수평(위/아래) 소환

        if (spawnVerticalEdge)
        {
            // 왼쪽 또는 오른쪽
            spawnPoint.y = Random.Range(minSpawn.position.y, maxSpawn.position.y);

            if (Random.Range(0f, 1f) > 0.5f)
            {
                spawnPoint.x = maxSpawn.position.x; // 오른쪽
            }
            else
            {
                spawnPoint.x = minSpawn.position.x; // 왼쪽
            }
        }
        else
        {
            // 위 또는 아래
            spawnPoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x);

            if (Random.Range(0f, 1f) > 0.5f)
            {
                spawnPoint.y = maxSpawn.position.y; // 위
            }
            else
            {
                spawnPoint.y = minSpawn.position.y; // 아래
            }
        }
        return spawnPoint;
    }
}

