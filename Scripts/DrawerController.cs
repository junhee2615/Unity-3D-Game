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

        // PlayerMovement 스크립트를 찾아서 참조
        playerMovement = FindObjectOfType<PMoveXZ>();
    }

    private void OnMouseDown()
    {
        // 플레이어의 움직임이 활성화된 경우에만 서랍을 열거나 닫음.
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