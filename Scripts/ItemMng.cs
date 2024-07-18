using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMng : MonoBehaviour
{
    private void Update()
    {
        // 마우스 좌클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 레이캐스트를 이용하여 마우스 클릭 지점에서 충돌하는 오브젝트 확인
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "Clock")  // "Clock" 이름을 가진 아이템과 충돌했을 때
                {
                    // 시간을 늘리고 아이템을 파괴
                    CountDown countdownScript = GameObject.FindObjectOfType<CountDown>();
                    if (countdownScript != null)
                    {
                        countdownScript.IncreaseTime(30f);
                    }

                    Destroy(hit.collider.gameObject);
                }

            }
        }
    }
}
