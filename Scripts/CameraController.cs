using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 2.0f; // 마우스 감도
    private bool isRotating = false;
    private Vector3 lastMousePosition;
    private float rotationX = 0.0f; // X 축 회전 각도

    void Update()
    {
        HandleMouseRotation();
    }

    void HandleMouseRotation()
    {
        if (Input.GetMouseButtonDown(0))   // 마우스 좌클릭
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

            // 상하 회전 (X 축 기준)
            rotationX -= delta.y * sensitivity;
            rotationX = Mathf.Clamp(rotationX, -90.0f, 90.0f); // 상하 회전 각도 제한

            transform.rotation = Quaternion.Euler(rotationX, transform.eulerAngles.y, 0.0f);

            lastMousePosition = Input.mousePosition;
        }
    }
}
