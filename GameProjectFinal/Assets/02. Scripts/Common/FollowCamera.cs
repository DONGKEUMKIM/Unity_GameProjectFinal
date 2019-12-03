using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;           //추적할 타겟 오브젝트

    public float dist = 10.0f;          //카메라와의 일정거리
    public float height = 5.0f;         //카메라의 높이 설정
    public float smoothRotate = 5.0f;   //부드러운 회전을 위한 변수

    private Transform tr;               //카메라 자신의 transform 변수

    public void Start()
    {
        tr = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        float curryAngle = Mathf.LerpAngle(tr.eulerAngles.y, target.eulerAngles.y,
            smoothRotate * Time.deltaTime);

        Quaternion rot = Quaternion.Euler(0, curryAngle, 0);

        tr.position = target.position - (rot * Vector3.forward * dist)
            + (Vector3.up * height);

        tr.LookAt(target);
    }

}
