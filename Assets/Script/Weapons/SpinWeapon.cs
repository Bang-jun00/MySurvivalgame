using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWeapon : MonoBehaviour
{
    public float rotateSpeed;
    public Transform holder, fireballSpawn;
    public float timeBetweenSpawn;
    private float spawnTimer;

    void Start()
    {
        spawnTimer = timeBetweenSpawn;
    }
    void Update()
    {
        //z축 기준으로 회전
        holder.rotation = Quaternion.Euler(0f, 0f, holder.rotation.eulerAngles.z + (rotateSpeed *  Time.deltaTime));

        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0f)
        {
            spawnTimer = timeBetweenSpawn;

            //파이어볼 생성
            Transform spawnedFireball = Instantiate(fireballSpawn, fireballSpawn.position, fireballSpawn.rotation, holder);

            spawnedFireball.gameObject.SetActive(true);
        }        
    }
}
