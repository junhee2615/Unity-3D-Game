using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJump : MonoBehaviour
{
    public float power = 10;   // ���� ũ��
    Rigidbody rb;   // ��ü �ν��Ͻ�

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   // ��ü ������Ʈ ���
    }

    // Update is called once per frame
    void Update()
    {
        // ���� �����̰�, ���� ��ư(�����̽���)�� ������
        if (Mathf.Abs(rb.velocity.y) < 0.001f && Input.GetButtonDown("Jump"))
            rb.AddForce(0, power, 0, ForceMode.Impulse);   // Y�� �������� power�� ���� ����
    }
}
