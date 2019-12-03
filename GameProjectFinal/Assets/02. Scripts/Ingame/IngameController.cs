using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameController : MonoBehaviour
{
    private PlayerMotor player;

    public Text timer;
    public float time;

    //플레이어에게 타이머가 0이 됐음을 알림
    public delegate void InformGoal();
    public static event InformGoal informGoal;

    public bool restart = false;

    private void Start()
    {
        player = (PlayerMotor)FindObjectOfType(typeof(PlayerMotor));
        Main.Instance.HideFadeOutPanel();

        StartCoroutine(IngameLogic());

        //PlayerMotor.informUp += ;
        timer.enabled = false;
    }


    public IEnumerator IngameLogic()
    {
        yield return StartCoroutine(MenuFadeIn());

        countdownText.InformCountDown += GameStart;

        
        PlayerMotor.informDie += Die;

        //yield return StartCoroutine(StartTimer());

        //TileManager.informGoal += Goal;
    }

    public void GameStart()
    {

            SoundManager.Instance.PlayIngameBGM();

            player.StartRunning();
            StartCoroutine(StartTimer());
    }
    private IEnumerator MenuFadeIn()
    {
        Main.Instance.ShowFadeinPanel();
        yield return ImageFadeIn.Instance.PlayFadeIn();

        Main.Instance.HideFadeinPanel();
    }

    //인게임화면 페이드아웃 코루틴
    private IEnumerator IngameFadeOut_fail()
    {
        yield return StartCoroutine(ImageFadeOut.Instance.PlayFadeOut());

        Main.Instance.OnEnd_fail();
    }

    private IEnumerator StartTimer()
    {
        time = 10.0f;

        while (time > 0.0f)
        {
            time -= Time.deltaTime;

            timer.text = Mathf.Ceil(time).ToString();

            yield return null;
        }

        if (time <= 0.0f)
        {
            informGoal();
            yield break;
        }
    }

    public void Die()
    {
        SoundManager.Instance.PlayStop();
        Main.Instance.ShowFadeOutPanel();
        StartCoroutine(IngameFadeOut_fail());
    }

    //public void Goal()
    //{
    //    Main.Instance.ShowFadeOutPanel();
    //    StartCoroutine(IngameFadeOut_suc());
    //}

    //게임씬 전환후 로직
    //1. 카운트다운 시작
    //2. 게임스타트

}
