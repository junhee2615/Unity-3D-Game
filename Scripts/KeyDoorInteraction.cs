using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyDoorInteraction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트의 태그를 확인
        if (other.CompareTag("Key"))
            StartCoroutine(GameClearAfterDelay());
        else if (other.CompareTag("Door"))
            StartCoroutine(GameClearAfterDelay());
    }

    private IEnumerator GameClearAfterDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("GameClear");
    }
}
