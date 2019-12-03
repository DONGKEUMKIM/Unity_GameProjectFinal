using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdownText : MonoBehaviour
{
    public Text counttext;

    private ArrayList countdownTextArray;

    private int icount;

    //카운트다운이 끝났음을 알리는 핸들러
    public delegate void InformCountDownHandler();
    public static event InformCountDownHandler InformCountDown;

    private void Start()
    {
        countdownTextArray = new ArrayList();

        countdownTextArray.Add("3");
        countdownTextArray.Add("2");
        countdownTextArray.Add("1");
        countdownTextArray.Add("Start");

        counttext.text = (string)countdownTextArray[icount];

        StartCoroutine(Countdown());
    }

    public IEnumerator Countdown()
    {
        icount = 0;

        while (icount < 4)
        {
            yield return seconddown();

            icount++;

            if (icount > 3)
            {
                counttext.gameObject.SetActive(false);

                InformCountDown();

                yield break;
            }

            counttext.text = (string)countdownTextArray[icount];
        }

    }

    IEnumerator seconddown()
    {
        yield return new WaitForSeconds(1f);
    }

    public void ReSettings()
    {
        this.icount = 0;
    }

}
