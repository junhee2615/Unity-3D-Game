using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMng : MonoBehaviour
{
    // 다시 하기 버튼 클릭 시 Game 씬 로드
    public void Retry()
    {
        SceneManager.LoadScene("Game");   // Game 씬 로드
    }
}
