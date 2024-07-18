using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJump : MonoBehaviour
{
    public float power = 10;   // 힘의 크기
    Rigidbody rb;   // 강체 인스턴스

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   // 강체 컴포넌트 얻기
    }

    // Update is called once per frame
    void Update()
    {
        // 정지 상태이고, 점프 버튼(스페이스바)을 누르면
        if (Mathf.Abs(rb.velocity.y) < 0.001f && Input.GetButtonDown("Jump"))
            rb.AddForce(0, power, 0, ForceMode.Impulse);   // Y축 방향으로 power의 힘을 가함
    }
}
