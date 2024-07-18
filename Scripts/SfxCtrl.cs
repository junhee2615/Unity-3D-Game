using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxCtrl : MonoBehaviour
{
    public AudioSource audioSource;   // ������ ȿ����
    public AudioSource audioSource2;   // �ð� ������ ȿ����

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
        // �浹�� ������Ʈ�� �±׸� Ȯ��
        if (other.CompareTag("QuizReward"))
        {
            // AudioSource�� null�� �ƴ� ��쿡�� ȿ���� ���
            if (audioSource && audioSource.enabled)
            {
                audioSource.Play();
            }
        }
    }

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
                    // AudioSource2�� null�� �ƴ� ��쿡�� ȿ���� ���
                    if (audioSource2 && audioSource2.enabled)
                    {
                        audioSource2.Play();
                    }
                }

            }
        }
    }
}
