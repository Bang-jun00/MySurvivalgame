using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWeapon : MonoBehaviour
{
    public float rotateSpeed;
    public Transform holder;

    
    void Update()
    {
        //z축 기준으로 회전
        holder.rotation = Quaternion.Euler(0f, 0f, holder.rotation.eulerAngles.z + (rotateSpeed *  Time.deltaTime));
    }
}
