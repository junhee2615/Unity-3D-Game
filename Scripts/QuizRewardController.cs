using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizRewardController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� �±׸� Ȯ��
        if (other.CompareTag("Player"))
        {
            // �浹�� ������Ʈ�� �÷��̾��� ��� ������ ������Ʈ ����
            Destroy(gameObject);
        }
    }
}