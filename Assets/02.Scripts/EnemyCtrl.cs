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
    public float moveSpeed = 2.0f;
    public float damping = 10.0f;

    void Start()
    {
        transform = GetComponent<Transform>();
        points = GameObject.Find("WayPointGroup").GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
