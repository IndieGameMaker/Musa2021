using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusaCtrl : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    private new Camera camera;
    private Transform tr;
    private Animator anim;

    public float damping = 10.0f;
    public float moveSpeed = 5.0f;
    private Vector3 movePos = Vector3.zero;
    private readonly int hashRun = Animator.StringToHash("IsRun");

    void Start()
    {
        camera = Camera.main;
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100.0f, 1<<8))
            {
                movePos = hit.point;
            }
        }
#endif
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            ray = camera.ScreenPointToRay(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                if (Physics.Raycast(ray, out hit, 100.0f, 1<<8))
                {
                    movePos = hit.point;
                }
            }
        }
#endif

        if ((movePos - tr.position).sqrMagnitude >= 0.2f * 0.2f)
        {
            //벡터의 뺄셈   A - B  ==>   B좌표에서 A좌표로 방향 벡터     
            Vector3 dir = movePos - tr.position;
            Quaternion rot = Quaternion.LookRotation(dir);
            tr.rotation = Quaternion.Slerp(tr.rotation,
                                        rot,
                                        Time.deltaTime * damping);

            tr.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            anim.SetBool(hashRun, true);
        }
        else
        {
            anim.SetBool(hashRun, false);
        }
    }
}
