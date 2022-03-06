using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDetector : MonoBehaviour
{
    public int valuePoints;
    public int skeeball;
    private static int ballsThrown = 0;
    public ScoreManager SM;
    public GameManager GM;
    public static bool playerOneHasTrown = false;
    public static bool playerTwoHasTrown = false;

    private void Start()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Ball")
        {
            switch (skeeball)
            {
                case 1:
                    if (ballsThrown == 2)
                    {
                        playerOneHasTrown = true;
                        Debug.Log("next player or end game");
                        GM.EndOfFrame();
                        ballsThrown = 0;
                    }
                    else
                    {
                        ballsThrown++;
                        SM.PlayerScore1 += valuePoints;
                        Debug.Log("Test");
                    }
                    break;
                case 2:
                    if (ballsThrown == 2)
                    { 
                        playerTwoHasTrown = true;
                        GM.EndOfFrame();
                        Debug.Log("next player or end game");
                        ballsThrown = 0;
                    }
                    else
                    {
                        ballsThrown++;
                        SM.PlayerScore2 += valuePoints;
                        Debug.Log("Test2");
                    }
                    break;
            }
            //Debug.Log(valuePoints);
            Debug.Log("Ballsthrown is" + ballsThrown);
        }
    }
}
