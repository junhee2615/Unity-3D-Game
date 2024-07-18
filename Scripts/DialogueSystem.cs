using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text txtName;   // 이름
    public Text txtSentence;   // 대화문장
    public Button StartBtn;   // 대화 시작 버튼
    public Image phoneImage;   // phone 이미지에 대한 참조 추가
    public PMoveXZ playerMovement;   // PlayerMovement 스크립트에 대한 참조

    Queue<string> sentences = new Queue<string>();

    public Animator anim;

    public CountDown countDownScript;   // CountDown 스크립트에 대한 참조

    public void Begin(Dialogue info)
    {

        anim.SetBool("isOpen", true);
        StartBtn.gameObject.SetActive(false);   // 문장 시작 시 대화시작 버튼 안 보임

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

        // 다섯 번째 문장이 나온 후에 phone 이미지 활성화
        if (sentences.Count == 4 && phoneImage != null)
        {
            phoneImage.gameObject.SetActive(true);
        }

        // 여섯번째 문장이 나오면 phone 이미지 비활성화
        //if (sentences.Count == 3 && phoneImage != null)
        //{
        //    phoneImage.gameObject.SetActive(false);
        //}
    }

    private void End()
    {
        anim.SetBool("isOpen", false);
        txtSentence.text = string.Empty;   // 문장 종료시 공백
        phoneImage.gameObject.SetActive(false);

        // CountDown 스크립트에서 카운트다운 시작
        if (countDownScript != null)
        {
            countDownScript.StartCountdown();
        }

        // 플레이어의 움직임 활성화
        if (playerMovement != null)
        {
            playerMovement.EnableMovement();
        }
    }
}