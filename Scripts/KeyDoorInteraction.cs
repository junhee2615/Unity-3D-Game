using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyDoorInteraction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� �±׸� Ȯ��
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
