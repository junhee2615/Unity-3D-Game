using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMoveXZ : MonoBehaviour
{
    public float power = 0.4f;
    Vector3 dir;
    Rigidbody rb;

    // ������ Ȱ��/��Ȱ�� �÷���
    private bool isMovementEnabled = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   // ���� ������Ʈ ���
        DisabledMovement();
    }

    void FixedUpdate()
    {
        if (isMovementEnabled)
        {
            dir.x = Input.GetAxis("Horizontal");   // ���� �̵�(-1.0 ~ 1.0)
            dir.z = Input.GetAxis("Vertical");   // ���� �̵�(-1.0 ~ 1.0)

            // ��� �̵� ���⿡ ���� ���� �����ϰ� ����
            if (dir.magnitude > 1)   // ������ ���̰� 1���� ũ��
                dir.Normalize();    // ���� ���̸� 1�� ����

            // dir �������� ���� ����
            rb.AddRelativeForce(dir * power, ForceMode.Impulse);
        }
    }

    // ������ ��Ȱ��ȭ
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

    // ������ Ȱ��ȭ ���� ��ȯ
    public bool IsMovementEnabled()
    {
        return isMovementEnabled;
    }

    // Update is called once per frame
    void Update()
    {

    }
}