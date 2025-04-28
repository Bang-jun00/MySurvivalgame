using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpLevelController : MonoBehaviour
{
    public static ExpLevelController instance; //싱글톤 인스턴스

    public int currentExp; //현재 경험치

    public ExpPickup pickup;//픽업 프리팹

    public List<int> expLevels; //레벨별 경험치 리스트
    public int currentLevel = 1, levelCount = 70; //현재 플레이어 레벨, 총 레벨

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        while(expLevels.Count < levelCount) //지정된 레벨 갯수 만큼 경험치 데이터 자동 생성
        {
            expLevels.Add(Mathf.CeilToInt(expLevels[expLevels.Count - 1] * 1.5f)); //Mathf.CeilToInt(소수점 올림)
        }
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
