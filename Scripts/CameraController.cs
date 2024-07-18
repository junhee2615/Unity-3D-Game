using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 2.0f; // ���콺 ����
    private bool isRotating = false;
    private Vector3 lastMousePosition;
    private float rotationX = 0.0f; // X �� ȸ�� ����

    void Update()
    {
        HandleMouseRotation();
    }

    void HandleMouseRotation()
    {
        if (Input.GetMouseButtonDown(0))   // ���콺 ��Ŭ��
        {
            isRotating = true;
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }

        if (isRotating)
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;

            // ���� ȸ�� (X �� ����)
            rotationX -= delta.y * sensitivity;
            rotationX = Mathf.Clamp(rotationX, -90.0f, 90.0f); // ���� ȸ�� ���� ����

            transform.rotation = Quaternion.Euler(rotationX, transform.eulerAngles.y, 0.0f);

            lastMousePosition = Input.mousePosition;
        }
    }
}
