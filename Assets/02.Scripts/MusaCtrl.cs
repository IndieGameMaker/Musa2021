using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusaCtrl : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    private Camera camera;
    private Transform tr;

    public float damping = 10.0f;
    public float moveSpeed = 5.0f;

    private Vector3 movePos = Vector3.zero;

    void Start()
    {
        camera = Camera.main;
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            
        }        
    }
}
