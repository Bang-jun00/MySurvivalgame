using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    public Animator playerAnim;
    

    
    void Update()
    {
        PlayerMove();
    }

    public void PlayerMove()
    {
        //벡터 값 초기화
        Vector3 moveInput = new Vector3(0f, 0f, 0f);

        //수평
        moveInput.x = Input.GetAxisRaw("Horizontal");

        //수직
        moveInput.y = Input.GetAxisRaw("Vertical");

        //오브젝트의 위치에 방향 속도 시간보정을 더해줌
        transform.position += (moveInput.normalized * moveSpeed * Time.deltaTime);

        //애니메이션 기능
        if(moveInput != Vector3.zero)
        {
            playerAnim.SetBool("isMoving", true);
        }
        else
        {
            playerAnim.SetBool("isMoving", false);
        }
    }

   
}
