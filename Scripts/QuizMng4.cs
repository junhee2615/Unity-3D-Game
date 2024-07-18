using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuizMng4 : MonoBehaviour
{
    public Image quiz4Image;   // 이미지 UI
    public GameObject rewardObject;   // 리워드 오브젝트
    public InputField answerInput;   // 정답 입력 필드
    public Text resultText;   // 정답 결과 표시 텍스트
    public Image successImage;   // 성공 이미지

    // 퀴즈4 완료 시에 호출되는 이벤트
    public static event Action<int> OnQuiz4Complete;

    private string correctAnswer = "자료구조";   // 퀴즈 정답

    private void Start()
    {
        // 시작 시에 UI와 성공 이미지, 결과 텍스트, 리워드, 정답 입력 필드를 비활성화
        quiz4Image.gameObject.SetActive(false);
        successImage.gameObject.SetActive(false);
        rewardObject.SetActive(false);
        resultText.gameObject.SetActive(false);
        answerInput.gameObject.SetActive(false);
    }

    private void Update()
    {
        // 키보드 Enter키로 정답 확인
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckAnswer();
        }

        // 키보드 Esc키로 이미지 UI 비활성화
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HideQuizUI();
        }
    }

    private void HideQuizUI()
    {
        // 이미지 UI, 결과 텍스트, 정답 입력 필드 비활성화
        quiz4Image.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        // 오브젝트가 클릭되면 Quiz#3 UI가 보여짐
        if (IsQuizObjectClicked())
        {
            ShowQuizUI();
        }
    }

    private bool IsQuizObjectClicked()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.name == "Quiz#4")
            {
                return true;
            }
        }

        return false;
    }

    private void ShowQuizUI()
    {
        // 퀴즈4 이미지 활성화
        quiz4Image.gameObject.SetActive(true);
        // 결과 텍스트 비활성화
        resultText.gameObject.SetActive(false);
        // 정답 입력 필드 활성화
        answerInput.gameObject.SetActive(true);
    }

    public void CheckAnswer()
    {
        string userAnswer = answerInput.text;
        // 결과 텍스트 활성화
        resultText.gameObject.SetActive(true);

        // 정답일 경우
        if (userAnswer.Equals(correctAnswer))
        {
            resultText.text = "정답! 축하합니다";
            resultText.color = Color.blue;   // 텍스트 색을 파란색으로 변경
            StartCoroutine(DelQuizImageAfterDelay(2f));  // 3초 뒤에 quiz4Image 비활성화

            // 퀴즈4 완료 이벤트 발생 및 퀴즈 번호 전달
            OnQuiz4Complete?.Invoke(4);
        }

        // 오답일 경우
        else
        {
            resultText.text = "땡! 다시 생각해보세요.";
            resultText.color = Color.red;   // 텍스트 색을 빨간색으로 변경
            rewardObject.SetActive(false);
        }

        // 결과 텍스트를 활성화하여 결과 표시
        resultText.gameObject.SetActive(true);
    }

    // 정답 재입력을 위한 함수
    public void RetryQuiz()
    {
        // UI 숨기기
        quiz4Image.gameObject.SetActive(false);
        resultText.gameObject.SetActive(false);
        // 정답 입력 필드 초기화
        answerInput.text = "";
        // 정답 재입력 시 입력 필드 활성화
        answerInput.gameObject.SetActive(true);
    }

    // 정답 입력 버튼 클릭 시 호출되는 함수
    private void ShowInputField()
    {
        answerInput.gameObject.SetActive(true);
    }

    // 일정 시간이 지난 후 퀴즈 이미지를 비활성화하고 성공 이미지를 활성화하는 코루틴
    private IEnumerator DelQuizImageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // 퀴즈4 이미지 비활성화
        quiz4Image.gameObject.SetActive(false);
        // 리워드 활성화
        rewardObject.SetActive(true);
        // 리워드 회전
        StartCoroutine(RotateReward());

        // 3초 대기 후 성공 이미지 활성화
        yield return new WaitForSeconds(3f);
        successImage.gameObject.SetActive(true);

        // 퀴즈4 완료 이벤트 발생
        OnQuiz4Complete?.Invoke(4);
    }

    // 리워드 오브젝트를 자동으로 회전시키는 코루틴
    private IEnumerator RotateReward()
    {
        while (true)
        {
            rewardObject.transform.Rotate(Vector3.up, 30f * Time.deltaTime);
            yield return null;
        }
    }

    // 퀴즈4 완료 시 호출되는 함수
    private void CompleteQuiz4()
    {
        // 퀴즈4 완료 이벤트 발생 및 퀴즈 번호 전달
        OnQuiz4Complete?.Invoke(3);
    }
}
