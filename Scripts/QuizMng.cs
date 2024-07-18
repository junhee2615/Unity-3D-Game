using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizMng : MonoBehaviour
{
    public Image quiz1Image;   // �̹��� UI
    public GameObject rewardObject;   // ������ ������Ʈ
    public InputField answerInput;   // ���� �Է� �ʵ�
    public Text resultText;   // ���� ��� ǥ�� �ؽ�Ʈ
    public Image successImage;   // ���� �̹���

    // ����1 �Ϸ� �ÿ� ȣ��Ǵ� �̺�Ʈ
    public static event Action<int> OnQuiz1Complete;

    private string correctAnswer = "90";   // ���� ����

    private void Start()
    {
        // ���� �ÿ� UI�� ���� �̹���, ��� �ؽ�Ʈ, ������, ���� �Է� �ʵ带 ��Ȱ��ȭ
        quiz1Image.gameObject.SetActive(false);
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
        quiz1Image.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        // ������Ʈ�� Ŭ���Ǹ� Quiz#1 UI�� ������
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
            if (hit.collider.gameObject.name == "Quiz#1")
            {
                return true;
            }
        }

        return false;
    }

    private void ShowQuizUI()
    {
        // ����1 �̹��� Ȱ��ȭ
        quiz1Image.gameObject.SetActive(true);
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
            StartCoroutine(DelQuizImageAfterDelay(2f));  // 3�� �ڿ� quiz1Image ��Ȱ��ȭ

            // ����1 �Ϸ� �̺�Ʈ �߻� �� ���� ��ȣ ����
            OnQuiz1Complete?.Invoke(1);
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
        quiz1Image.gameObject.SetActive(false);
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
        // ����1 �̹��� ��Ȱ��ȭ
        quiz1Image.gameObject.SetActive(false);
        // ������ Ȱ��ȭ
        rewardObject.SetActive(true);
        // ������ ȸ��
        StartCoroutine(RotateReward());

        // 3�� ��� �� ���� �̹��� Ȱ��ȭ
        yield return new WaitForSeconds(3f);
        successImage.gameObject.SetActive(true);

        // ����1 �Ϸ� �̺�Ʈ �߻�
        OnQuiz1Complete?.Invoke(1);
    }

    // ��Ʈ�� ������Ʈ�� �ڵ����� ȸ����Ű�� �ڷ�ƾ
    private IEnumerator RotateReward()
    {
        while (true)
        {
            rewardObject.transform.Rotate(Vector3.up, 30f * Time.deltaTime);
            yield return null;
        }
    }

    private void CompleteQuiz1()
    {
        // ����1 �Ϸ� �̺�Ʈ �߻� �� ���� ��ȣ ����
        OnQuiz1Complete?.Invoke(1);
    }
}
