using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxCtrl : MonoBehaviour
{
    public AudioSource audioSource;   // 리워드 효과음
    public AudioSource audioSource2;   // 시계 아이템 효과음

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource)
        {
            audioSource.playOnAwake = false;
            audioSource.loop = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트의 태그를 확인
        if (other.CompareTag("QuizReward"))
        {
            // AudioSource가 null이 아닌 경우에만 효과음 재생
            if (audioSource && audioSource.enabled)
            {
                audioSource.Play();
            }
        }
    }

    private void Update()
    {
        // 마우스 좌클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 레이캐스트를 이용하여 마우스 클릭 지점에서 충돌하는 오브젝트 확인
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "Clock")  // "Clock" 이름을 가진 아이템과 충돌했을 때
                {
                    // AudioSource2가 null이 아닌 경우에만 효과음 재생
                    if (audioSource2 && audioSource2.enabled)
                    {
                        audioSource2.Play();
                    }
                }

            }
        }
    }
}
