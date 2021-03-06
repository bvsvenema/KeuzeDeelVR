using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDetector : MonoBehaviour
{
    public int valuePoints;
    public int skeeball;
    public ScoreManager SM;
    public GameManager GM;
    private AudioSource Sound;
    public static bool playerOneHasTrown = false;
    public static bool playerTwoHasTrown = false;

    private void Start()
    {
        Sound = GetComponent<AudioSource>();
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Ball")
        {
            switch (skeeball)
            {
                case 1:
                    if (SM.BallsThrownP1 == 4)
                    {
                        SM.PlayerScore1 += valuePoints;
                        playerOneHasTrown = true;
                        SM.BallsThrownP1 = 0;
                        Debug.Log("next player or end game");
                        StartCoroutine(GM.EndOfFrame());
                    }
                    else
                    {
                        SM.BallsThrownP1++;
                        Sound.Play();
                        SM.PlayerScore1 += valuePoints;
                        Debug.Log("Test");
                    }
                    break;
                case 2:
                    if (SM.BallsThrownP2 == 4)
                    {
                        SM.PlayerScore1 += valuePoints;
                        SM.BallsThrownP2 = 0;
                        playerTwoHasTrown = true;
                        StartCoroutine(GM.EndOfFrame());
                        Debug.Log("next player or end game");
                    }
                    else
                    {
                        SM.BallsThrownP2++;
                        Sound.Play();
                        SM.PlayerScore2 += valuePoints;
                        Debug.Log("Test2");
                    }
                    break;
            }
        }
    }
}
