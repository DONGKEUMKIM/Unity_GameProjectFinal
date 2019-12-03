using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneController : MonoBehaviour
{
    private void Start()
    {
        Main.Instance.HideFadeOutPanel();

        SoundManager.Instance.PlayEndingfailBGM();

        StartCoroutine(EndLogic());
    }

    IEnumerator EndLogic()
    {
        yield return StartCoroutine(EndFadeIn());

    }

    private IEnumerator EndFadeIn()
    {
        Main.Instance.ShowFadeinPanel();
        yield return StartCoroutine(ImageFadeIn.Instance.PlayFadeIn());

        Main.Instance.HideFadeinPanel();
    }

    //엔딩화면 페이드아웃 코루틴
    private IEnumerator EndGameFadeOut()
    {
        yield return StartCoroutine(ImageFadeOut.Instance.PlayFadeOut());

        Main.Instance.OnTitle();
    }

    ////////////////버튼이벤트//////////////////////
    public void RegameBtn()
    {
        Main.Instance.ShowFadeOutPanel();
        StartCoroutine(EndGameFadeOut());
    }
}
