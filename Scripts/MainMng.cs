using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMng : MonoBehaviour
{
    public GameObject HowToPlayPanel;   // ���ӹ�� �����г�
    public GameObject HowToPlayPanel2;   // ���۹�� & ���� �г�

    // Start is called before the first frame update
    void Start()
    {
        // ���� ��� �г� �ʱ�ȭ(��Ȱ��ȭ)
        if (HowToPlayPanel != null)
        {
            HowToPlayPanel.SetActive(false);
        }

        if (HowToPlayPanel2 != null)
        {
            HowToPlayPanel2.SetActive(false);
        }
    }

    // �ݱ� ��ư Ŭ�� �� ȣ���� �޼���
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

    // ���� ���� ��ư Ŭ�� �� ȣ���� �޼���
    public void StartGame()
    {
        SceneManager.LoadScene("Game");   // ���Ӿ� �ε�
    }

    // ���� ��� ��ư Ŭ�� �� ȣ���� �޼���
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

    // ���� ��� �г� �ݱ� ��ư Ŭ�� �� ȣ���� �޼���
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
