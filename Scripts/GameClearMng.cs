using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClearMng : MonoBehaviour
{
    //메인화면으로 버튼 클릭 시 Main 씬 로드
    public void ToHome()
    {
        SceneManager.LoadScene("Main");   // Main 씬 로드
    }
}
