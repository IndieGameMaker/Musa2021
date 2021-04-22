using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    //WayPoint를 저장할 배열
    public Transform[] points;

    //WayPoint Next Index
    public int nextIdx = 1;

    private new Transform transform;
    private Transform playerTr;

    public float moveSpeed = 2.0f;
    public float damping = 10.0f;
    public float traceDist = 5.0f;

    private Vector3 movePos;

    void Start()
    {
        transform = GetComponent<Transform>();
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        points = GameObject.Find("WayPointGroup").GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        // 주인공과 적캐릭터의 거리가 traceDist 이내일 경우
        if ((playerTr.position - transform.position).sqrMagnitude <= traceDist * traceDist)
        {
            movePos = playerTr.position;
        }
        else
        {
            movePos = points[nextIdx].position;
        }

        //다음 WayPoint위치로 바라보는 각도 산출
        Vector3 dir = movePos - transform.position;  
        //벡터를 Quaternion 변환
        Quaternion rot = Quaternion.LookRotation(dir);

        //구면선형 보간(Spherecal Linear Interpolate)을 사용해서 회전
        transform.rotation = Quaternion.Slerp(transform.rotation,
                                              rot,
                                              Time.deltaTime * damping);
        //이동(직진)
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    }

    void OnTriggerEnter(Collider coll)
    {
        //WAY_POINT 도착했을 때
        if (coll.CompareTag("WAY_POINT"))
        {
            nextIdx = (++nextIdx >= points.Length) ? 1 : nextIdx;

            // nextIdx = nextIdx +1;
            // if (nextIdx >= points.Length)
            // {
            //     nextIdx = 1;
            // }
        }
    }

}
