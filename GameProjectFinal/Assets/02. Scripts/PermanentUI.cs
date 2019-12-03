using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// 모든 씬에 걸쳐 존재하는 UI의 관리 클래스. '...Loading', '네트워크 오류' 표시 //
/// </summary>

public class PermanentUI : MonoBehaviour
{
    //캔버스
    //public CanvasGroup loadingCanvas;
    //public CanvasGroup FadeCanvas;
    //public CanvasGroup DialogueCanvas;

    //패널
    public RectTransform FadeInPanel;
    public RectTransform FadeOutPanel;
    
    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);

        FadeInPanel.gameObject.SetActive(false);
        FadeOutPanel.gameObject.SetActive(false);
 
    }

    public void ShowFadeIn()
    {
        FadeInPanel.gameObject.SetActive(true);
        //imagefadeIn.StartFadeAnim();
    }

    public void HideFadeIn()
    {
        FadeInPanel.gameObject.SetActive(false);
    }

    public void ShowFadeOut()
    {
        FadeOutPanel.gameObject.SetActive(true);
        //imagefadeout.StartFadeAnim();
    }

    public void HideFadeOut()
    {
        FadeOutPanel.gameObject.SetActive(false);
    }
}