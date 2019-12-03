using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    public AudioClip soundIngameBGM;
    public AudioClip soundEndingfailBgm;
    public AudioClip soundEndingSuBgm;
    public AudioClip soundScoreUP;

    AudioSource myAudio;

    public void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    public void PlayIngameBGM()
    {
        myAudio.PlayOneShot(soundIngameBGM);
    }

    public void PlayEndingfailBGM()
    {
        myAudio.PlayOneShot(soundEndingfailBgm);
    }

    public void PlayEndingsucBGM()
    {
        myAudio.PlayOneShot(soundEndingSuBgm);
    }

    public void PlayScoreupBGM()
    {
        myAudio.PlayOneShot(soundScoreUP);
    }

    public void PlayStop()
    {
        myAudio.Stop();
    }
}
