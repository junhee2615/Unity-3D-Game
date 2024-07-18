using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMng : MonoBehaviour
{
    public GameObject HowToPlayPanel;   // 게임방법 설명패널
    public GameObject HowToPlayPanel2;   // 조작방법 & 지도 패널

    // Start is called before the first frame update
    void Start()
    {
        // 게임 방법 패널 초기화(비활성화)
        if (HowToPlayPanel != null)
        {
            HowToPlayPanel.SetActive(false);
        }

        if (HowToPlayPanel2 != null)
        {
            HowToPlayPanel2.SetActive(false);
        }
    }

    // 닫기 버튼 클릭 시 호출할 메서드
    public void Exit()
    {
        if (HowToPlayPanel != null)
        {
            HowToPlayPanel.SetActive(false);
        }

        if (HowToPlayPanel2 != null)
        {
            HowToPlayPanel2.SetActive(false);
        }
    }

    // 게임 시작 버튼 클릭 시 호출할 메서드
    public void StartGame()
    {
        SceneManager.LoadScene("Game");   // 게임씬 로드
    }

    // 게임 방법 버튼 클릭 시 호출할 메서드
    public void ShowHowToPlayPanel()
    {
        if (HowToPlayPanel != null)
        {
            HowToPlayPanel.SetActive(true);
        }
    }

    public void ShowHowToPlayPanel2()
    {
        if (HowToPlayPanel2 != null)
        {
            HowToPlayPanel2.SetActive(true);
        }
    }

    // 게임 방법 패널 닫기 버튼 클릭 시 호출할 메서드
    public void HideHowToPlayPanel()
    {
        if (HowToPlayPanel != null)
        {
            HowToPlayPanel.SetActive(false);
        }
    }

    public void HideHowToPlayPanel2()
    {
        if (HowToPlayPanel2 != null)
        {
            HowToPlayPanel2.SetActive(false);
        }
    }
}
