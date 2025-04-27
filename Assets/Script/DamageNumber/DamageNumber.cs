using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    public TMP_Text damageText;

    public float lifetime;
    private float lifeCounter;
    
    
    void Start()
    {
        lifeCounter = lifetime; //초기화
    }

    
    void Update()
    {
        if(lifeCounter > 0)
        {
            lifeCounter -= Time.deltaTime; //시간 흐르면 카운트 다운

            if(lifeCounter <= 0)
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
