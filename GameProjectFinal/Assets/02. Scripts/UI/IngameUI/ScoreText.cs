using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text scoreText;

    int score = 0;

    public void Start()
    {
        scoreText.text = score.ToString();
        PlayerMotor.informUp += ScoreUp;
    }

    public void ScoreUp()
    {
        SoundManager.Instance.PlayScoreupBGM();
        score += 10;
        scoreText.text = score.ToString();

    }


}
