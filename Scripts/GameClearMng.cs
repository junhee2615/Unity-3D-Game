using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClearMng : MonoBehaviour
{
    //����ȭ������ ��ư Ŭ�� �� Main �� �ε�
    public void ToHome()
    {
        SceneManager.LoadScene("Main");   // Main �� �ε�
    }
}
