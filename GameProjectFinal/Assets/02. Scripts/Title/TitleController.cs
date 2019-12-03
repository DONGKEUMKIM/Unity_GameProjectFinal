using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    public RectTransform LogoCanvas;
    public RectTransform TitleCanvas;

    private Main main;
    private void Awake()
    {
        LogoCanvas.gameObject.SetActive(true);
        TitleCanvas.gameObject.SetActive(false);
    }

    private void Start()
    {
        main = Main.Instance;

        StartCoroutine(ShowLogo());
    }

    // 로고 화면을 비추는 코루틴
    private IEnumerator ShowLogo()
    {
        //로고 페이드인 코루틴 시작
        main.ShowFadeinPanel();
        yield return StartCoroutine(ImageFadeIn.Instance.PlayFadeIn());

        main.HideFadeinPanel();

        //로고화면을 비추는 코루틴 시작
        yield return StartCoroutine(LogoCanvasShow());

        //로고 페이드아웃 코루틴 시작
        main.ShowFadeOutPanel();
        yield return StartCoroutine(ImageFadeOut.Instance.PlayFadeOut());

        main.HideFadeOutPanel();

        //로고 캔버스 비활성화 -> 타이틀캔버스 활성화
        LogoCanvas.gameObject.SetActive(false);
        TitleCanvas.gameObject.SetActive(true);

        //타이틀화면 페이드인 코루틴 시작
        main.ShowFadeinPanel();
        yield return StartCoroutine(ImageFadeIn.Instance.PlayFadeIn());

        main.HideFadeinPanel();
    }

    //로고화면을 비추는 코루틴
    private IEnumerator LogoCanvasShow()
    {
        //로고화면 1.5초 지속
        yield return new WaitForSeconds(1.5f);
    }

    //타이틀화면 페이드아웃 코루틴
    private IEnumerator TitleFadeOut()
    {
        yield return StartCoroutine(ImageFadeOut.Instance.PlayFadeOut());

        main.OnBattle();
    }


    //////////////////////////버튼이벤트///////////////////////////
    public void OnClickStartButton()
    {
        main.ShowFadeOutPanel();

        StartCoroutine(TitleFadeOut());

    }

    public void OnClickExitButtn()
    {
        Application.Quit();
    }
}
