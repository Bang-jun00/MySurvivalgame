using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner")]
    public EnemyPool enemyPool; // 몹 프리팹이 저장되어있는 풀 연결
    //public float timeToSpawn = 2f; //적이 생성되는 간격
    private float spawnTimer; //타이머
    public Transform target;

    [Header("SpawnPoint")]
    public Transform minSpawn, maxSpawn;

    [Header("WaveList")]
    public List<WaveInfo> waves; //몬스터 웨이브를 저장할 리스트 추가

    private int currentWave;
    private float waveCounter;
    

    private float dispawnDistance;
    private List<GameObject> spawnEnemies = new List<GameObject>(); //활성화된 몹을 체크할 리스트 추가
    

    void Start()
    {
        target  = PlayerHP.instance.transform; //싱글톤에서 플레이어 Transform 가져오기

        dispawnDistance = Vector3.Distance(transform.position, maxSpawn.position) + 4f;

        currentWave = -1;
        GoToNextWave();
    }



    
    void Update()
    {
        transform.position = target.position; // 스포너가 player를 따라다님
        
        if(!PlayerHP.instance.gameObject.activeSelf)
            return; //플레이어가 죽으면 스폰 중단

        if(currentWave < waves.Count)
        {
            waveCounter -= Time.deltaTime;
            
            if(waveCounter <= 0f)
            {
                GoToNextWave();
            }
            spawnTimer -= Time.deltaTime;
            if(spawnTimer <= 0f)
            {
                spawnTimer = waves[currentWave].timeBetweenSpawns;
                SpawnEnemy();
            }
        }
        //적 디스폰 체크
        for (int i = spawnEnemies.Count - 1; i >= 0; i--)
        {
            GameObject enemy = spawnEnemies[i];
            if (Vector3.Distance(target.position, enemy.transform.position) > dispawnDistance)
            {
                waves[currentWave].enemiesPool.ReturnEnemy(enemy); // 풀에 돌려주고
                spawnEnemies.RemoveAt(i); // 리스트에서 제거
            }
        }

    }

    void SpawnEnemy()
    {
        GameObject enemy = waves[currentWave].enemiesPool.GetEnemy();
        enemy.transform.position = SelectSpawnPoint();
        enemy.transform.rotation = transform.rotation;

        enemy.GetComponent<EnemyController>().enemyPool = waves[currentWave].enemiesPool;

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
    void GoToNextWave()
    {
        currentWave++;

        if (currentWave >= waves.Count)
        {
            currentWave = waves.Count - 1;
        }

        waveCounter = waves[currentWave].waveLength;
        spawnTimer = waves[currentWave].timeBetweenSpawns;
    }
}

[System.Serializable] //이걸 통해서 인스팩터에 표시해도 되는 데이터라는 것을 인식시켜줌.
public class WaveInfo //MonoBehaviour를 상속받지 않아서 그냥 데이터를 담는 객체
{
    public EnemyPool enemiesPool; //어떤 풀에서 꺼낼지
    public float waveLength; //웨이브 지속시간
    public float timeBetweenSpawns = 1f; //스폰 간격
    
}

