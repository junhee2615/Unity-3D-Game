using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMng : MonoBehaviour
{
    // �ٽ� �ϱ� ��ư Ŭ�� �� Game �� �ε�
    public void Retry()
    {
        SceneManager.LoadScene("Game");   // Game �� �ε�
    }
}
