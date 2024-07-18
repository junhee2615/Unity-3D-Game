using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuizMng4 : MonoBehaviour
{
    public Image quiz4Image;   // �̹��� UI
    public GameObject rewardObject;   // ������ ������Ʈ
    public InputField answerInput;   // ���� �Է� �ʵ�
    public Text resultText;   // ���� ��� ǥ�� �ؽ�Ʈ
    public Image successImage;   // ���� �̹���

    // ����4 �Ϸ� �ÿ� ȣ��Ǵ� �̺�Ʈ
    public static event Action<int> OnQuiz4Complete;

    private string correctAnswer = "�ڷᱸ��";   // ���� ����

    private void Start()
    {
        // ���� �ÿ� UI�� ���� �̹���, ��� �ؽ�Ʈ, ������, ���� �Է� �ʵ带 ��Ȱ��ȭ
        quiz4Image.gameObject.SetActive(false);
        successImage.gameObject.SetActive(false);
        rewardObject.SetActive(false);
        resultText.gameObject.SetActive(false);
        answerInput.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Ű���� EnterŰ�� ���� Ȯ��
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckAnswer();
        }

        // Ű���� EscŰ�� �̹��� UI ��Ȱ��ȭ
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HideQuizUI();
        }
    }

    private void HideQuizUI()
    {
        // �̹��� UI, ��� �ؽ�Ʈ, ���� �Է� �ʵ� ��Ȱ��ȭ
        quiz4Image.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        // ������Ʈ�� Ŭ���Ǹ� Quiz#3 UI�� ������
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
        // ����4 �̹��� Ȱ��ȭ
        quiz4Image.gameObject.SetActive(true);
        // ��� �ؽ�Ʈ ��Ȱ��ȭ
        resultText.gameObject.SetActive(false);
        // ���� �Է� �ʵ� Ȱ��ȭ
        answerInput.gameObject.SetActive(true);
    }

    public void CheckAnswer()
    {
        string userAnswer = answerInput.text;
        // ��� �ؽ�Ʈ Ȱ��ȭ
        resultText.gameObject.SetActive(true);

        // ������ ���
        if (userAnswer.Equals(correctAnswer))
        {
            resultText.text = "����! �����մϴ�";
            resultText.color = Color.blue;   // �ؽ�Ʈ ���� �Ķ������� ����
            StartCoroutine(DelQuizImageAfterDelay(2f));  // 3�� �ڿ� quiz4Image ��Ȱ��ȭ

            // ����4 �Ϸ� �̺�Ʈ �߻� �� ���� ��ȣ ����
            OnQuiz4Complete?.Invoke(4);
        }

        // ������ ���
        else
        {
            resultText.text = "��! �ٽ� �����غ�����.";
            resultText.color = Color.red;   // �ؽ�Ʈ ���� ���������� ����
            rewardObject.SetActive(false);
        }

        // ��� �ؽ�Ʈ�� Ȱ��ȭ�Ͽ� ��� ǥ��
        resultText.gameObject.SetActive(true);
    }

    // ���� ���Է��� ���� �Լ�
    public void RetryQuiz()
    {
        // UI �����
        quiz4Image.gameObject.SetActive(false);
        resultText.gameObject.SetActive(false);
        // ���� �Է� �ʵ� �ʱ�ȭ
        answerInput.text = "";
        // ���� ���Է� �� �Է� �ʵ� Ȱ��ȭ
        answerInput.gameObject.SetActive(true);
    }

    // ���� �Է� ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    private void ShowInputField()
    {
        answerInput.gameObject.SetActive(true);
    }

    // ���� �ð��� ���� �� ���� �̹����� ��Ȱ��ȭ�ϰ� ���� �̹����� Ȱ��ȭ�ϴ� �ڷ�ƾ
    private IEnumerator DelQuizImageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // ����4 �̹��� ��Ȱ��ȭ
        quiz4Image.gameObject.SetActive(false);
        // ������ Ȱ��ȭ
        rewardObject.SetActive(true);
        // ������ ȸ��
        StartCoroutine(RotateReward());

        // 3�� ��� �� ���� �̹��� Ȱ��ȭ
        yield return new WaitForSeconds(3f);
        successImage.gameObject.SetActive(true);

        // ����4 �Ϸ� �̺�Ʈ �߻�
        OnQuiz4Complete?.Invoke(4);
    }

    // ������ ������Ʈ�� �ڵ����� ȸ����Ű�� �ڷ�ƾ
    private IEnumerator RotateReward()
    {
        while (true)
        {
            rewardObject.transform.Rotate(Vector3.up, 30f * Time.deltaTime);
            yield return null;
        }
    }

    // ����4 �Ϸ� �� ȣ��Ǵ� �Լ�
    private void CompleteQuiz4()
    {
        // ����4 �Ϸ� �̺�Ʈ �߻� �� ���� ��ȣ ����
        OnQuiz4Complete?.Invoke(3);
    }
}
