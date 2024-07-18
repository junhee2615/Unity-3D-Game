using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;   // 인벤토리 패널
    bool activeInventory = false;

    public Transform[] rewardImageSlots;   // 리워드 이미지 슬롯 배열
    private List<int> completedQuizzes = new List<int>();  // 완료된 퀴즈 목록

    public Button KeyButton;   // 열쇠 버튼
    public GameObject Key;   // 열쇠

    private void Start()
    {
        inventoryPanel.SetActive(activeInventory);   // 게임 시작 시에는 인벤토리가 보이지 않게 함
        KeyButton.gameObject.SetActive(false);   // 게임 시작 시에는 열쇠 버튼이 보이지 않게 함

        // 각 리워드 이미지 슬롯을 처음에는 비활성화
        foreach (Transform slot in rewardImageSlots)
        {
            slot.gameObject.SetActive(false);
        }

        // 퀴즈 완료 이벤트에 대한 리스너 추가
        QuizMng.OnQuiz1Complete += (quizNumber) => ShowRewardImages(quizNumber);
        QuizMng2.OnQuiz2Complete += (quizNumber) => ShowRewardImages(quizNumber);
        QuizMng3.OnQuiz3Complete += (quizNumber) => ShowRewardImages(quizNumber);
        QuizMng4.OnQuiz4Complete += (quizNumber) => ShowRewardImages(quizNumber);

        // KeyButton 클릭 이벤트에 대한 리스너 추가
        KeyButton.onClick.AddListener(OnKeyButtonClick);
    }

    private void Update()
    {
        // I키를 누르면 인벤토리가 보이게 함
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
    }

    // 퀴즈 완료 시 호출되는 함수
    private void ShowRewardImages(int quizNumber)
    {
        // 이미 완료된 퀴즈라면 중복해서 리워드 이미지를 표시하지 않음
        if (completedQuizzes.Contains(quizNumber))
        {
            return;
        }

        completedQuizzes.Add(quizNumber);  // 완료된 퀴즈 목록에 추가

        // 해당 퀴즈 번호에 해당하는 슬롯만 활성화
        if (quizNumber > 0 && quizNumber <= rewardImageSlots.Length)
        {
            // 해당 슬롯을 활성화
            Transform targetSlot = rewardImageSlots[quizNumber - 1];

            if (!targetSlot.gameObject.activeSelf)
            {
                targetSlot.gameObject.SetActive(true);
            }

            // 모든 퀴즈 완료 시 KeyButton 활성화
            if (completedQuizzes.Count == rewardImageSlots.Length)
            {
                 StartCoroutine(ActivateKeyButtonAfterDelay(4.5f)); // 3초 후에 활성화
            }
        }
    }

    // 일정 시간이 지난 후 KeyButton을 활성화하는 코루틴
    private IEnumerator ActivateKeyButtonAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        KeyButton.gameObject.SetActive(true);
    }

    // KeyButton이 클릭되었을 때 호출되는 함수
    private void OnKeyButtonClick()
    {
        // KeyButton이 눌리면 Key GameObject를 활성화
        ActivateKeyObject();
    }

    private void ActivateKeyObject()
    {
        if (Key != null)
        {
            Key.SetActive(true);
            KeyButton.gameObject.SetActive(false);

            // DoorController에 있는 CollectKey 메서드 호출
            DoorController doorController = FindObjectOfType<DoorController>();
            if (doorController != null)
            {
                doorController.CollectKey();
            }
            else
            {
                Debug.LogError("DoorController를 찾을 수 없습니다.");
            }
        }
        else
        {
            Debug.LogError("Key GameObject를 찾을 수 없습니다.");
        }
    }
}