using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDetector : MonoBehaviour
{
    public int valuePoints;
    public int skeeball;
    private static int ballsThrown = 0;
    public GameManager GM;
    public bool playerOneHasTrown = false;
    public bool playerTwoHasTrown = false;

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
                    if (ballsThrown == 9)
                    {
                        playerOneHasTrown = true;
                        Debug.Log("next player or end game");
                        ballsThrown = 0;
                        GM.EndOfFrame();
                    }
                    else
                    {
                        ballsThrown++;
                        GM.PlayerScore1 += valuePoints;
                    }
                    break;
                case 2:
                    if (ballsThrown == 9)
                    { 
                   
                        ballsThrown = 0;
                        playerTwoHasTrown = true;
                        GM.EndOfFrame();
                        Debug.Log("next player or end game");
                    }
                    else
                    {
                        ballsThrown++;
                        GM.PlayerScore2 += valuePoints;
                    }
                    break;
            }
        }
    }
}
