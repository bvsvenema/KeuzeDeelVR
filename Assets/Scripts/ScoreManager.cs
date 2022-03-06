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

    //private variables
    private int score1;
    private int score2;
    private const int maxLength = 10;


    public string CappedString
    {
        get { return playerTextOutput1.text; }
        set
        {
            playerTextOutput1.text = value != null && value.Length > maxLength ? value.Substring(0, maxLength) : value;
            playerSkeeOutput1.text = value != null && value.Length > maxLength ? value.Substring(0, maxLength) : value + " Score:";
        }
    }

    public string CappedString2
    {
        get { return playerTextOutput2.text; }
        set
        {
            playerTextOutput2.text = value != null && value.Length > maxLength ? value.Substring(0, maxLength) : value;
            playerSkeeOutput2.text = value != null && value.Length > maxLength ? value.Substring(0, maxLength) : value + " Score:";
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

    //updates score to text
    public void UpdatePlayer1Score()
    {
        scorePlayer1.text = "" + score1;
        Debug.Log("Player 1: " + score1);
    }

    public void UpdatePlayer2Score()
    {
        scorePlayer2.text = "" + score2;
        Debug.Log("Player 2: " + score2);
    }

}
