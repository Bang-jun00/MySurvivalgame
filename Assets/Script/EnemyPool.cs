using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int poolSize = 500; //뱀서류는 몬스터 겁나 많이 나와서 풀 사이즈 넉넉하게 잡기
    private Stack<GameObject> enemyPool = new Stack<GameObject>();

    private void Start()
    {
       for(int i = 0;  i < poolSize; i++)
       {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false); //비활성화 상태로
            enemyPool.Push(enemy); //Stack에 push
       }
    }

    public GameObject GetEnemy() //풀에서 꺼낼때
    {
        if(enemyPool.Count > 0)
        {
            GameObject enemy = enemyPool.Pop(); //꺼내기
            enemy.SetActive(true); //활성화 상태로
            return enemy;
        }
        else
        {
            GameObject enemy = Instantiate(enemyPrefab); //풀에 남아있지 않으면 새로 만들어서 줌(안전 처리)
            return enemy;
        }
    }

    public void ReturnEnemy(GameObject enemy) //풀에 다시 리턴시킬때
    {
        enemy.SetActive(false); //비활성화로
        enemyPool.Push(enemy); //넣어줌
    }
}
