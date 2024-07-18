using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerController : MonoBehaviour
{
    private bool drawerOpened;
    private bool coroutineAllowed;
    private Vector3 initialPosition;
    public float openNum = 0.5f;

    private PMoveXZ playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        drawerOpened = false;
        coroutineAllowed = true;
        initialPosition = transform.position;

        // PlayerMovement ��ũ��Ʈ�� ã�Ƽ� ����
        playerMovement = FindObjectOfType<PMoveXZ>();
    }

    private void OnMouseDown()
    {
        // �÷��̾��� �������� Ȱ��ȭ�� ��쿡�� ������ ���ų� ����.
        if (coroutineAllowed && playerMovement != null && playerMovement.IsMovementEnabled())
        {
            StartCoroutine("OpenOrCloseDrawer");
        }
    }

    private IEnumerator OpenOrCloseDrawer()
    {
        coroutineAllowed = false;

        Vector3 targetPosition = drawerOpened ? initialPosition : new Vector3(initialPosition.x + openNum, initialPosition.y, initialPosition.z);

        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.1f);
            yield return null;
        }

        if (drawerOpened)
        {
            drawerOpened = false;
        }
        else
        {
            drawerOpened = true;
        }

        coroutineAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}