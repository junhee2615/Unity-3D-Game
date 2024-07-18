using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;   // �κ��丮 �г�
    bool activeInventory = false;

    public Transform[] rewardImageSlots;   // ������ �̹��� ���� �迭
    private List<int> completedQuizzes = new List<int>();  // �Ϸ�� ���� ���

    public Button KeyButton;   // ���� ��ư
    public GameObject Key;   // ����

    private void Start()
    {
        inventoryPanel.SetActive(activeInventory);   // ���� ���� �ÿ��� �κ��丮�� ������ �ʰ� ��
        KeyButton.gameObject.SetActive(false);   // ���� ���� �ÿ��� ���� ��ư�� ������ �ʰ� ��

        // �� ������ �̹��� ������ ó������ ��Ȱ��ȭ
        foreach (Transform slot in rewardImageSlots)
        {
            slot.gameObject.SetActive(false);
        }

        // ���� �Ϸ� �̺�Ʈ�� ���� ������ �߰�
        QuizMng.OnQuiz1Complete += (quizNumber) => ShowRewardImages(quizNumber);
        QuizMng2.OnQuiz2Complete += (quizNumber) => ShowRewardImages(quizNumber);
        QuizMng3.OnQuiz3Complete += (quizNumber) => ShowRewardImages(quizNumber);
        QuizMng4.OnQuiz4Complete += (quizNumber) => ShowRewardImages(quizNumber);

        // KeyButton Ŭ�� �̺�Ʈ�� ���� ������ �߰�
        KeyButton.onClick.AddListener(OnKeyButtonClick);
    }

    private void Update()
    {
        // IŰ�� ������ �κ��丮�� ���̰� ��
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
    }

    // ���� �Ϸ� �� ȣ��Ǵ� �Լ�
    private void ShowRewardImages(int quizNumber)
    {
        // �̹� �Ϸ�� ������ �ߺ��ؼ� ������ �̹����� ǥ������ ����
        if (completedQuizzes.Contains(quizNumber))
        {
            return;
        }

        completedQuizzes.Add(quizNumber);  // �Ϸ�� ���� ��Ͽ� �߰�

        // �ش� ���� ��ȣ�� �ش��ϴ� ���Ը� Ȱ��ȭ
        if (quizNumber > 0 && quizNumber <= rewardImageSlots.Length)
        {
            // �ش� ������ Ȱ��ȭ
            Transform targetSlot = rewardImageSlots[quizNumber - 1];

            if (!targetSlot.gameObject.activeSelf)
            {
                targetSlot.gameObject.SetActive(true);
            }

            // ��� ���� �Ϸ� �� KeyButton Ȱ��ȭ
            if (completedQuizzes.Count == rewardImageSlots.Length)
            {
                 StartCoroutine(ActivateKeyButtonAfterDelay(4.5f)); // 3�� �Ŀ� Ȱ��ȭ
            }
        }
    }

    // ���� �ð��� ���� �� KeyButton�� Ȱ��ȭ�ϴ� �ڷ�ƾ
    private IEnumerator ActivateKeyButtonAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        KeyButton.gameObject.SetActive(true);
    }

    // KeyButton�� Ŭ���Ǿ��� �� ȣ��Ǵ� �Լ�
    private void OnKeyButtonClick()
    {
        // KeyButton�� ������ Key GameObject�� Ȱ��ȭ
        ActivateKeyObject();
    }

    private void ActivateKeyObject()
    {
        if (Key != null)
        {
            Key.SetActive(true);
            KeyButton.gameObject.SetActive(false);

            // DoorController�� �ִ� CollectKey �޼��� ȣ��
            DoorController doorController = FindObjectOfType<DoorController>();
            if (doorController != null)
            {
                doorController.CollectKey();
            }
            else
            {
                Debug.LogError("DoorController�� ã�� �� �����ϴ�.");
            }
        }
        else
        {
            Debug.LogError("Key GameObject�� ã�� �� �����ϴ�.");
        }
    }
}