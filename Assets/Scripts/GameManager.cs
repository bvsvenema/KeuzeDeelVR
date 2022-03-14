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
    private const int maxLength = 10;

    //Gameobject callings
    public List<GameObject> singleplayer;
    public List<GameObject> twoPlayer;
    public Balls[] ballp1;
    public Balls[] ballp2;
    private GameObject player;
    public GameObject canvas2P;
    public GameObject canvasSingle;
    //public GameObject teleport;
    public GameObject tabletSetname;
    public GameObject tabletP1;
    public GameObject tabletP2;

    public void Start()
    {
        //teleport.SetActive(false);
        canvas2P.SetActive(false);
        canvasSingle.SetActive(false);
        SM = GetComponent<ScoreManager>();
        Debug.Log(HandButtonPress.teleportInt);
    }

    void Awake()
    {
        //set player to right position entering the game
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(30, 0, -0.5f);

        //set the gamemode single player or 2 player
        switch (HandButtonPress.teleportInt)
        {
            default:
                Debug.Log("Nothing Happend");
                break;

            case 1:

                //set singleplayer objects active
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
                //set twoplayer objects active
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
        }
    }

    private void Update()
    {
        //see if the end of the game is
        if (SM.Frame == rounds)
        {
            //teleport.SetActive(true);
            Debug.Log("End of Game");
            switch (HandButtonPress.teleportInt)
            {
                case 1: 
                    //teleport to highscore canvas for singlepayer
                    canvasSingle.SetActive(true);
                    //teleport.SetActive(true);
                    player.transform.position = new Vector3(-6.4f, 0, 0.9f);
                    break;
                case 2:
                    //teleport to highscore canvas for 2 player
                    canvas2P.SetActive(true);
                    //teleport.SetActive(true);
                    player.transform.position = new Vector3(-6.4f, 0, 0.9f);
                    break;
            }
            rounds = -1;
        }
    }

    public IEnumerator EndOfFrame()
    {
        //see if the round are not over yet
        if (SM.Frame != rounds)
        {
            switch (HandButtonPress.teleportInt)
            {
                //see if you have to telport for the second player
                case 1:
                    SM.Frame++;
                    Debug.Log("Round is" + SM.Frame);
                    foreach (var Ball in ballp1)
                    {
                        Ball.ResetBalls();
                    }
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
                        foreach (var Ball in ballp1)
                        {
                            Ball.ResetBalls();
                        }
                        yield return new WaitForSeconds(1);
                        player.transform.position = new Vector3(2.9f, 0, 1.171f);
                        tabletP1.SetActive(true);
                    }
                    else if (PointDetector.playerOneHasTrown == true)
                    {
                        Debug.Log("one has thrown");
                        //player 2 is
                        foreach (var Ball in ballp2)
                        {
                            Ball.ResetBalls();
                        }
                        yield return new WaitForSeconds(1);
                        player.transform.position = new Vector3(-0.2f, 0, 1);
                        tabletP2.SetActive(true);
                    }
                    break;
            } 
        }
    }
}
