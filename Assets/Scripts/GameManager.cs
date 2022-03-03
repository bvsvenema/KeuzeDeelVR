using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    PointDetector pointDetector;

    //plublic Gameobject callings
    public TextMeshProUGUI playerTextOutput1;
    public TextMeshProUGUI playerTextOutput2;
    public TextMeshProUGUI scorePlayer1;
    public TextMeshProUGUI scorePlayer2;
    public int rounds = 3;
    public int roundCount;

    private bool Testing;

    public List<GameObject> singleplayer;
    public List<GameObject> twoPlayer;

    //private vaireables
    private GameObject player;


    //private data
    private const int maxLength = 10;

    public void Start()
    {

        Debug.Log(TeleportPoint.teleportInt);
        //Testing data trough scrips

    }

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (Testing == true)
        {
            player.transform.position = new Vector3(0, 0.036f, 0);
        }
        else
        {
            player.transform.position = new Vector3(30, 0.036f, 0);

            switch (TeleportPoint.teleportInt)
            {
                default:
                    Debug.Log("Nothing Happend");
                    break;

                case 1:
                    Debug.Log("SinglePlayer");
                    for (int i = 0; i < twoPlayer.Count; i++)
                    {
                        twoPlayer[i].SetActive(false);
                    }
                    for (int i = 0; i < singleplayer.Count; i++)
                    {
                        singleplayer[i].SetActive(true);
                    }
                    break;
                case 2:
                    Debug.Log("2 Player Game");
                    for (int i = 0; i < singleplayer.Count; i++)
                    {
                        singleplayer[i].SetActive(false);
                    }
                    for (int i = 0; i < twoPlayer.Count; i++)
                    {
                        twoPlayer[i].SetActive(true);
                    }
                    break;
                case 3:
                    Debug.Log("Multiplayer");
                    break;
            }
        }
    }

    public void EndOfFrame()
    {
        if (roundCount == rounds)
        {
            //end of game
        }
        else
        {
            switch (TeleportPoint.teleportInt)
            {
                case 1:
                    roundCount++;
                    //ResetBalls And Next Frame
                    break;
                case 2:
                    //to second player and then next frame
                    if(pointDetector.playerOneHasTrown || pointDetector.playerTwoHasTrown)
                    {
                        roundCount++;
                        pointDetector.playerOneHasTrown = false;
                        pointDetector.playerTwoHasTrown = false;
                        player.transform.position = new Vector3(0.26f, 0.036f, 1);
                    }
                    else if (pointDetector.playerOneHasTrown)
                    {
                        player.transform.position = new Vector3(0.26f, 0.036f, 1);
                    }
                    break;
            } 
        }
    }

    //set the string for the name('s) or scores
    public string CappedString
    {
        get { return playerTextOutput1.text; }
        set { playerTextOutput1.text = value != null && value.Length > maxLength ? value.Substring(0, maxLength) : value; }
    }

    public string CappedString2
    {
        get { return playerTextOutput2.text; }
        set { playerTextOutput2.text = value != null && value.Length > maxLength ? value.Substring(0, maxLength) : value; }
    }

    public int PlayerScore1
    {
        get { return pointDetector.valuePoints; }
        set { pointDetector.valuePoints = value;
            UpdatePlayer1Score(); }
    }

    public int PlayerScore2
    {
        get { return pointDetector.valuePoints; }
        set
        { pointDetector.valuePoints = value;
            UpdatePlayer2Score(); }
    }

    //updates score to text
    public void UpdatePlayer1Score()
    {
        scorePlayer1.text = scorePlayer1 + " " + roundCount;
    }

    public void UpdatePlayer2Score()
    {
        scorePlayer1.text = scorePlayer2 + " " + roundCount;
    }





}
