using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinY : MonoBehaviour
{
    public float speed = 360;   // ȸ�� �ӵ�
    public float rotationSpeed = 10.0f;   // ȸ�� �ӵ�

    private Quaternion initialRotation;   // �ʱ� ȸ�� ���� ����

    // Start is called before the first frame update
    void Start()
    {
        // �ʱ� ȸ�� ���� ����
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float mx = Input.GetAxis("Mouse X");   // ���콺 ���� �̵�
        float deg = mx * speed * Time.deltaTime;   // ȸ�� ����
        //float scroll = Input.GetAxis("Mouse ScrollWheel");   // ���콺 ��ũ�� �Է�

        // ��ũ�� ���� ���� ȸ�� ���� ���
        //float rotationAmount = scroll * rotationSpeed;

        // O Ű�� ������ �ʱ� ȸ�� ���·� ���ư�
        if (Input.GetKeyDown(KeyCode.O))
        {
            transform.rotation = initialRotation;
        }

        // ���� ��ü�� �������� Y�� ȸ��
        //transform.Rotate(rotationAmount, 0, 0);

        transform.Rotate(0, deg, 0);   // Y�� ���� ȸ��(deg)
    }
}
