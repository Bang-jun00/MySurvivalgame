using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    private Transform target;
    
    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
    }

   
    void LateUpdate()
    {
        CameraMove();
    }

    private void CameraMove()
    {
        //카메라 x y는 플레이어 따라가게하고 z위치는 고정
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}
