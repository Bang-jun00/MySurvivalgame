using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    public TMP_Text damageText;

    public float lifetime;
    private float lifeCounter;
    public float floatSpeed;           
    
    void Update()
    {                
        if(lifeCounter > 0)
        {
            lifeCounter -= Time.deltaTime;
            
            transform.position += Vector3.up * floatSpeed * Time.deltaTime; //윗 방향으로 움직이게 만들어줌

            if (lifeCounter <= 0)
            {
                Destroy(gameObject); // 시간 다 되면 삭제
            }
        }       
    }

    public void Setup(int damageDisplay)
    {
        lifeCounter = lifetime; //다시 세팅

        damageText.text = damageDisplay.ToString(); // 숫자를 텍스트로 변환해서 표시
    }
}
