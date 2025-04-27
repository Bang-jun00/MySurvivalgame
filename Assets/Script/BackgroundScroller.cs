using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public Transform player; // 플레이어 위치
    public Transform[] backgrounds; // 배경 오브젝트들 (3x3 총 9개)
    public Vector2 backgroundSize; // 배경 하나의 크기 (가로, 세로)

    void Update()
    {
        foreach (Transform bg in backgrounds)
        {
            // 배경과 플레이어 사이 거리 계산
            float distanceX = Mathf.Abs(player.position.x - bg.position.x);
            float distanceY = Mathf.Abs(player.position.y - bg.position.y);

            // 만약 배경이 너무 멀어지면
            if (distanceX > backgroundSize.x)
            {
                // X축으로 옮기기
                float move = (player.position.x > bg.position.x) ? backgroundSize.x * 3f : -backgroundSize.x * 3f;
                bg.position += new Vector3(move, 0f, 0f);
            }
            if (distanceY > backgroundSize.y)
            {
                // Y축으로 옮기기
                float move = (player.position.y > bg.position.y) ? backgroundSize.y * 3f : -backgroundSize.y * 3f;
                bg.position += new Vector3(0f, move, 0f);
            }
        }
    }
}
