using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform targetTr;   //추적 대상(주인공)
    public float distance = 5.0f; //타겟과의 거리
    public float height   = 5.0f; //카메라의 높이
    public float damping  = 3.0f; //민감도

    private new Transform transform;

    void Start()
    {
        transform = GetComponent<Transform>();       
    }

    void LateUpdate()
    {
        //카메라의 위치값 계산
        //(주인공의 위치) + (X 이동) + (Y 이동);
        Vector3 pos = targetTr.position 
                      + (Vector3.right * distance)
                      + (Vector3.up * height);
        
        //카메라의 부드러운 이동처리
        transform.position = Vector3.Lerp(transform.position,
                                          pos,
                                          Time.deltaTime * damping);
        //
        transform.LookAt(targetTr.position);
    }
}
