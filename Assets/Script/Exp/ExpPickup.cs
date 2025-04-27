using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ExpPickup : MonoBehaviour
{
    public int expValue; //경험치 양

    private bool movingToPlayer;
    public float moveSpeed; //픽업 이동속도

    public float timeBetweenChecks; //거리 체크 주기
    private float checkCounter; //거리 체크 타이머

    private PlayerController player; //플레이어 참조

    void Start()
    {
        player = PlayerHP.instance.GetComponent<PlayerController>(); //PlayerHP싱글톤에서 컴포넌트 가져옴
    }

    void Update()
    {
        if (movingToPlayer == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);  //플레이어를 향해 무브스피드 속도로 이동           
        }
        else
        {
            checkCounter -= Time.deltaTime; //일정시간마다 거리체크
            if (checkCounter <= 0f)
            {
                checkCounter = timeBetweenChecks; //타이머 리셋
                
                if (Vector3.Distance(transform.position, player.transform.position) < player.pickupRange)
                {
                    movingToPlayer = true; //플레이어 따라 이동
                    moveSpeed += player.moveSpeed; // 플레이어 속도 반영
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            ExpLevelController.instance.GetExp(expValue); //경험치 추가
            Destroy(gameObject); //픽업 삭제            
        }
    }    
}
