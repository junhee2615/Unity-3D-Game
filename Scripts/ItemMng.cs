using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMng : MonoBehaviour
{
    private void Update()
    {
        // ���콺 ��Ŭ�� ����
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // ����ĳ��Ʈ�� �̿��Ͽ� ���콺 Ŭ�� �������� �浹�ϴ� ������Ʈ Ȯ��
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "Clock")  // "Clock" �̸��� ���� �����۰� �浹���� ��
                {
                    // �ð��� �ø��� �������� �ı�
                    CountDown countdownScript = GameObject.FindObjectOfType<CountDown>();
                    if (countdownScript != null)
                    {
                        countdownScript.IncreaseTime(30f);
                    }

                    Destroy(hit.collider.gameObject);
                }

            }
        }
    }
}
