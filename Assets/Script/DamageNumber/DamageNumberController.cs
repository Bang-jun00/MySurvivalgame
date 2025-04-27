using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumberController : MonoBehaviour
{
    public static DamageNumberController instance; //싱글톤

    public DamageNumber numberSpawn;
    public Transform numberCanvas;
    void Awake()
    {
        instance = this;
    }

    public void SpawnDamage(float damage, Vector3 location)
    {
        int round = Mathf.RoundToInt(damage); //float를 int로 반올림
        DamageNumber newDamage = Instantiate(numberSpawn, location, Quaternion.identity, numberCanvas);
        newDamage.Setup(round); //표시할 숫자 설정
        newDamage.gameObject.SetActive(true); //오브젝트 활성화
    }
    
}
