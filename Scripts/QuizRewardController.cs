using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizRewardController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트의 태그를 확인
        if (other.CompareTag("Player"))
        {
            // 충돌한 오브젝트가 플레이어일 경우 리워드 오브젝트 제거
            Destroy(gameObject);
        }
    }
}