using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner")]
    public EnemyPool enemyPool; // 몹 프리팹이 저장되어있는 풀 연결
    public float timeToSpawn = 2f; //적이 생성되는 간격
    private float spawnTimer; //타이머

    [Header("SpawnPoint")]
    public Transform minSpawn, maxSpawn;
    public Transform target;

    private float dispawnDistance;
    private List<GameObject> spawnEnemies = new List<GameObject>(); //활성화된 몹을 담을 리스트 추가
    

    void Start()
    {
        spawnTimer = timeToSpawn;
        
        target  = PlayerHP.instance.transform; //싱글톤에서 플레이어 Transform 가져오기

        dispawnDistance = Vector3.Distance(transform.position, maxSpawn.position) + 4f;
    }

    
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer < 0f)
        {
            spawnTimer = timeToSpawn;

            SpawnEnemy(); //적 생성
        }

        transform.position = target.position; // 스포너가 player를 따라다님
        
        //적 디스폰 체크
        for (int i = spawnEnemies.Count - 1; i >= 0; i--)
        {
            GameObject enemy = spawnEnemies[i];
            if (Vector3.Distance(target.position, enemy.transform.position) > dispawnDistance)
            {
                enemyPool.ReturnEnemy(enemy); // 풀에 돌려주고
                spawnEnemies.RemoveAt(i); // 리스트에서도 제거
            }
        }

    }

    void SpawnEnemy()
    {
        GameObject enemy = enemyPool.GetEnemy();
        enemy.transform.position = SelectSpawnPoint();
        enemy.transform.rotation = transform.rotation;

        spawnEnemies.Add(enemy); //리스트에 추가
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

