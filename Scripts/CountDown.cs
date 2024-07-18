using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField] float setTime = 300f;
    [SerializeField] Text countdownText;

    bool isCounting = false;

    // Start is called before the first frame update
    void Start()
    {
        countdownText.text = setTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(isCounting)
        {
            if (setTime > 0)
            {
                setTime -= Time.deltaTime;
            }
            else
            {
                // GameOver ¾À ·Îµå
                SceneManager.LoadScene("GameOver");
            }

            countdownText.text = Mathf.Round(setTime).ToString();
        }
    }

    public void StartCountdown()
    {
        isCounting = true;
        StartCoroutine(CountdownRoutine());
    }

    public void IncreaseTime(float amount)
    {
        setTime += amount;
        countdownText.text = Mathf.Round(setTime).ToString();
    }

    IEnumerator CountdownRoutine()
    {
        while(setTime > 0) 
        {
            yield return null;
        }
    }
}
