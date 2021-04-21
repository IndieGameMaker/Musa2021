using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    private bool isMouseClick => Input.GetMouseButtonDown(0);
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;    
    }

    void Update()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.green);

        if (isMouseClick)
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1<<LayerMask.NameToLayer("BOX")))
            {
                //박스 삭제
                Destroy(hit.collider.gameObject);
                ExpBox();
            }
        }
    }

    void ExpBox()
    {
        //광선이 맞은 지점으로 부터 특정 반경 범위이내에 들어오는 모든 Elf를 추출
        Collider[] colls = Physics.OverlapSphere(hit.point, 10.0f, 1<<6);

        foreach(Collider coll in colls)
        {
            coll.attachedRigidbody.AddExplosionForce(1800.0f,   //횡 폭발력
                                                    hit.point, //폭발 원점
                                                    10.0f);  
            // coll.GetComponent<Rigidbody>()?.AddExplosionForce(1800.0f,   //횡 폭발력
            //                                                     hit.point, //폭발 원점
            //                                                     10.0f,     //반경
            //                                                     2000.0f);  //종 폭발력
        }
    }
}
