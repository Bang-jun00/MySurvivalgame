using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpLevelController : MonoBehaviour
{
    public static ExpLevelController instance; //싱글톤 인스턴스

    public int currentExp; //현재 경험치

    public ExpPickup pickup;//픽업 프리팹

    private void Awake()
    {
        instance = this;
    }

    //경험치를 얻는 함수
    public void GetExp(int getExp)
    {
        currentExp += getExp;
        // 나중에 여기서 레벨업 체크 같은 것도 추가할 예정
    }

    //픽업을 생성하는 함수
    public void SpawnExp(Vector3 position, int expValue)
    {
        ExpPickup newPickup = Instantiate(pickup, position, Quaternion.identity);
        newPickup.expValue = expValue;
    }
}
