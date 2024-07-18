using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMoveXZ : MonoBehaviour
{
    public float power = 0.4f;
    Vector3 dir;
    Rigidbody rb;

    // 움직임 활성/비활성 플래그
    private bool isMovementEnabled = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   // 물리 컴포넌트 얻기
        DisabledMovement();
    }

    void FixedUpdate()
    {
        if (isMovementEnabled)
        {
            dir.x = Input.GetAxis("Horizontal");   // 수평 이동(-1.0 ~ 1.0)
            dir.z = Input.GetAxis("Vertical");   // 수직 이동(-1.0 ~ 1.0)

            // 모든 이동 방향에 대해 힘을 동일하게 조절
            if (dir.magnitude > 1)   // 벡터의 길이가 1보다 크면
                dir.Normalize();    // 벡터 길이를 1로 변경

            // dir 방향으로 힘을 가함
            rb.AddRelativeForce(dir * power, ForceMode.Impulse);
        }
    }

    // 움직임 비활성화
    public void DisabledMovement()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
        isMovementEnabled = false;
    }

    public void EnableMovement()
    {
        rb.isKinematic = false;
        isMovementEnabled = true;
    }

    // 움직임 활성화 여부 반환
    public bool IsMovementEnabled()
    {
        return isMovementEnabled;
    }

    // Update is called once per frame
    void Update()
    {

    }
}