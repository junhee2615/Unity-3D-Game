using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject keyPanel; // ���谡 �ʿ��� �г�
    private bool hasKey = false; // ���� ���� ����

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (hasKey)
            {
                // ���� ���� �ڵ� �߰�
                Debug.Log("���� ���Ƚ��ϴ�!");
            }
            else
            {
                // ���谡 ������ �г��� ���ϴ�.
                keyPanel.SetActive(true);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // �÷��̾ �浹 ������ ���������� �г��� �ݽ��ϴ�.
            keyPanel.SetActive(false);
        }
    }

    // ���踦 ����� �� ȣ��Ǵ� �޼���
    public void CollectKey()
    {
        hasKey = true;
        keyPanel.SetActive(false); // �г��� �ݽ��ϴ�.
    }
}
