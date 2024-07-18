using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinY : MonoBehaviour
{
    public float speed = 360;   // 회전 속도
    public float rotationSpeed = 10.0f;   // 회전 속도

    private Quaternion initialRotation;   // 초기 회전 상태 저장

    // Start is called before the first frame update
    void Start()
    {
        // 초기 회전 상태 저장
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float mx = Input.GetAxis("Mouse X");   // 마우스 수평 이동
        float deg = mx * speed * Time.deltaTime;   // 회전 각도
        //float scroll = Input.GetAxis("Mouse ScrollWheel");   // 마우스 스크롤 입력

        // 스크롤 값에 따라 회전 각도 계산
        //float rotationAmount = scroll * rotationSpeed;

        // O 키를 누르면 초기 회전 상태로 돌아감
        if (Input.GetKeyDown(KeyCode.O))
        {
            transform.rotation = initialRotation;
        }

        // 현재 객체를 기준으로 Y축 회전
        //transform.Rotate(rotationAmount, 0, 0);

        transform.Rotate(0, deg, 0);   // Y축 기준 회전(deg)
    }
}
