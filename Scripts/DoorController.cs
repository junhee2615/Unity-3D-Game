using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject keyPanel; // 열쇠가 필요한 패널
    private bool hasKey = false; // 열쇠 보유 여부

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (hasKey)
            {
                // 문을 여는 코드 추가
                Debug.Log("문이 열렸습니다!");
            }
            else
            {
                // 열쇠가 없으면 패널을 띄웁니다.
                keyPanel.SetActive(true);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // 플레이어가 충돌 영역을 빠져나가면 패널을 닫습니다.
            keyPanel.SetActive(false);
        }
    }

    // 열쇠를 얻었을 때 호출되는 메서드
    public void CollectKey()
    {
        hasKey = true;
        keyPanel.SetActive(false); // 패널을 닫습니다.
    }
}
