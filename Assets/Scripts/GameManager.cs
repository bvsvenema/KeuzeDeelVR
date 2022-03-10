using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    private ScoreManager SM;
    //public varaibles
    public int rounds = 3;
    public bool Testing = false;
    private const int maxLength = 10;

    //Gameobject callings
    public List<GameObject> singleplayer;
    public List<GameObject> twoPlayer;
    private GameObject player;
    public GameObject canvas2P;
    public GameObject canvasSingle;

    public void Start()
    {
        canvas2P.SetActive(false);
        SM = GetComponent<ScoreManager>();
        if (Testing == true)
        {
            TeleportPoint.teleportInt = 2;
        }
        Debug.Log(TeleportPoint.teleportInt);
        //Testing data trough scrips

    }

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (Testing == true)
        {
            player.transform.position = new Vector3(2.9f, 0, 1.171f);
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = new Vector3(30, 0, 0);

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

    private void Update()
    {
        if (SM.Frame == rounds)
        {
            Debug.Log("End of Game");
            switch (TeleportPoint.teleportInt)
            {
                case 1: /*set score canvas 1 active */
                    canvasSingle.SetActive(true);
                    player.transform.position = new Vector3(-6.4f, 0, 1.158f);
                    break;
                case 2:
                    //Debug.Log(SM.PlayerScore1, SM.playerTextOutput1);
                    //Debug.Log(SM.PlayerScore2, SM.playerTextOutput2);
                    canvas2P.SetActive(true);
                    player.transform.position = new Vector3(-6.4f, 0, 1.158f);
                    break;
            }
            rounds = -1;
        }
    }

    public void EndOfFrame()
    {
        //Debug.Log("this script");
        if (SM.Frame == rounds)
        {
        //    Debug.Log("End of Game");
        //    switch (TeleportPoint.teleportInt)
        //    {
        //        case 1: /*set score canvas 1 active */
        //            player.transform.position = new Vector3(-6.4f, 0, 1.158f);
        //            break;
        //        case 2: canvas2P.SetActive(true);
        //            player.transform.position = new Vector3(-6.4f, 0, 1.158f);
        //            break;
        //    }
        }
        else
        {
            switch (TeleportPoint.teleportInt)
            {
                case 1:
                    SM.Frame++;
                    Debug.Log("Round is" + SM.Frame);
                    //ResetBalls And Next Frame
                    break;
                case 2:
                    //to second player and then next frame
                    if(PointDetector.playerOneHasTrown == true && PointDetector.playerTwoHasTrown == true)
                    {
                        //player one is again
                        Debug.Log("Both has thrown");
                        SM.Frame++;
                        PointDetector.playerOneHasTrown = false;
                        PointDetector.playerTwoHasTrown = false;
                        player.transform.position = new Vector3(2.9f, 0, 1.171f);
                    }
                    else if (PointDetector.playerOneHasTrown == true)
                    {
                        Debug.Log("one has thrown");
                        //player 2 is
                        player.transform.position = new Vector3(-0.2f, 0, 1);
                    }
                    break;
            } 
        }
    }
}
