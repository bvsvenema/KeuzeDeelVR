using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    //TekstMeshPro's
    public TextMeshProUGUI playerTextOutput1;
    public TextMeshProUGUI playerTextOutput2;
    public TextMeshProUGUI playerSkeeOutput1;
    public TextMeshProUGUI playerSkeeOutput2;
    public TextMeshProUGUI scorePlayer1;
    public TextMeshProUGUI scorePlayer2;
    public TextMeshProUGUI ballsThrownpP1Text;
    public TextMeshProUGUI ballsThrownpP2Text;
    public TextMeshProUGUI frameP1Text;
    public TextMeshProUGUI frameP2Text;

    //private variables
    private int score1;
    private int score2;
    private int frame;
    private int ballsThrown1;
    private int ballsThrown2;

    private const int maxLength = 10;


    public string CappedString
    {
        get { return playerTextOutput1.text; }
        set
        {
            playerTextOutput1.text = value != null && value.Length > maxLength ? value.Substring(0, maxLength) : value;
            playerSkeeOutput1.text = value != null && value.Length > maxLength ? value.Substring(0, maxLength) : value;
        }
    }

    public string CappedString2
    {
        get { return playerTextOutput2.text; }
        set
        {
            playerTextOutput2.text = value != null && value.Length > maxLength ? value.Substring(0, maxLength) : value;
            playerSkeeOutput2.text = value != null && value.Length > maxLength ? value.Substring(0, maxLength) : value;
        }
    }

    public int PlayerScore1
    {
        get { return score1; }
        set
        {
            score1 = value;
            UpdatePlayer1Score();
        }
    }

    public int PlayerScore2
    {
        get { return score2; }
        set
        {
            score2 = value;
            UpdatePlayer2Score();
        }
    }

    public int BallsThrownP1
    {
        get { return ballsThrown1; }
        set { ballsThrown1 = value;
            UpdateBallsThrownP1(); }
    }

    public int BallsThrownP2
    {
        get { return ballsThrown2; }
        set { ballsThrown2 = value;
            UpdateBallsThrownP2(); }
    }

    public int Frame
    {
        get { return frame; }
        set { frame = value;
            UpdateFrameP1(); }
    }


    public void UpdateBallsThrownP1()
    {
        ballsThrownpP1Text.text = "BallsThrown: " + ballsThrown1;
    }

    public void UpdateBallsThrownP2()
    {
        ballsThrownpP2Text.text = "BallsThrown: " + ballsThrown2;
    }
    
    public void UpdateFrameP1()
    {
        frameP1Text.text = "Frame: " + frame;
        frameP2Text.text = "Frame: " + frame;
    }

    //updates score to text
    public void UpdatePlayer1Score()
    {
        scorePlayer1.text = "Score: " + score1;
        Debug.Log("Player 1: " + score1);
    }

    public void UpdatePlayer2Score()
    {
        scorePlayer2.text = "Score: " + score2;
        Debug.Log("Player 2: " + score2);
    }

}
