using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text txtName;   // �̸�
    public Text txtSentence;   // ��ȭ����
    public Button StartBtn;   // ��ȭ ���� ��ư
    public Image phoneImage;   // phone �̹����� ���� ���� �߰�
    public PMoveXZ playerMovement;   // PlayerMovement ��ũ��Ʈ�� ���� ����

    Queue<string> sentences = new Queue<string>();

    public Animator anim;

    public CountDown countDownScript;   // CountDown ��ũ��Ʈ�� ���� ����

    public void Begin(Dialogue info)
    {

        anim.SetBool("isOpen", true);
        StartBtn.gameObject.SetActive(false);   // ���� ���� �� ��ȭ���� ��ư �� ����

        sentences.Clear();

        txtName.text = info.name;

        foreach (var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }

        Next();
    }

    public void Next()
    {
        if (sentences.Count == 0)
        {
            End();
        }

        //txtSentence.text = sentences.Dequeue();
        txtSentence.text = string.Empty;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentences.Dequeue()));
    }

    IEnumerator TypeSentence(string sentence)
    {
        foreach (var letter in sentence)
        {
            txtSentence.text += letter;
            yield return new WaitForSeconds(0.1f);
        }

        // �ټ� ��° ������ ���� �Ŀ� phone �̹��� Ȱ��ȭ
        if (sentences.Count == 4 && phoneImage != null)
        {
            phoneImage.gameObject.SetActive(true);
        }

        // ������° ������ ������ phone �̹��� ��Ȱ��ȭ
        //if (sentences.Count == 3 && phoneImage != null)
        //{
        //    phoneImage.gameObject.SetActive(false);
        //}
    }

    private void End()
    {
        anim.SetBool("isOpen", false);
        txtSentence.text = string.Empty;   // ���� ����� ����
        phoneImage.gameObject.SetActive(false);

        // CountDown ��ũ��Ʈ���� ī��Ʈ�ٿ� ����
        if (countDownScript != null)
        {
            countDownScript.StartCountdown();
        }

        // �÷��̾��� ������ Ȱ��ȭ
        if (playerMovement != null)
        {
            playerMovement.EnableMovement();
        }
    }
}