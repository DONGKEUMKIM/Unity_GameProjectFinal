using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class Main : MonoSingleton<Main>
{
    private PermanentUI permanentUI;

	protected override void Awake()
	{
		base.Awake();

		permanentUI = (PermanentUI)FindObjectOfType(typeof(PermanentUI));
	}

    public void OnTitle()
    {
        SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
    }

    public void OnBattle()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void OnEnd_fail()
    {
        SceneManager.LoadScene("EndScene_fail", LoadSceneMode.Single);
    }
    public void OnEnd_suc()
    {
        SceneManager.LoadScene("EndScene_suc", LoadSceneMode.Single);
    }

    //페이드인
    public void ShowFadeinPanel()
    {
        permanentUI.ShowFadeIn();
    }

    public void HideFadeinPanel()
    {
        permanentUI.HideFadeIn();
    }

    //페이드아웃
    public void ShowFadeOutPanel()
    {
        permanentUI.ShowFadeOut();
    }

    public void HideFadeOutPanel()
    {
        permanentUI.HideFadeOut();
    }
}