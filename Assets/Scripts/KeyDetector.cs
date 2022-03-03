using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Valve.VR.InteractionSystem;

public class KeyDetector : MonoBehaviour
{
    //dont look here just some messy code ;(

    //Script Calling
    public GameManager GM;

    //priate variables
    private GameObject player;
    private bool secondPlayer = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {

        var key = other.GetComponentInChildren<TextMeshProUGUI>();
        if (key != null)
        {
            var keyFeedBack = other.gameObject.GetComponent<KeyFeedBack>();

            if (keyFeedBack.keyCanHitAgain)
            {

                if (other.gameObject.GetComponent<KeyFeedBack>().keyCanHitAgain)
                {
                    if (other.tag == "KeyBoard1")
                    {
                        if (key.text == "SPACEBARE" /*&& KeyFeedBack.keyHitted != 10*/)
                        {
                            if (secondPlayer == false)
                            {
                                GM.CappedString += " ";
                            }
                            else
                            {
                                GM.CappedString2 += " ";
                            }
                        }
                        else if (key.text == "<--")
                        {
                            if (secondPlayer == false)
                            {
                                GM.CappedString = GM.CappedString.Substring(0, GM.CappedString.Length - 1);
                                KeyFeedBack.keyHitted--;
                            }
                            else
                            {
                                GM.CappedString2 = GM.CappedString2.Substring(0, GM.CappedString2.Length - 1);
                                KeyFeedBack.keyHitted--;
                            }
                        }
                        else if (key.text == "Submit")
                        {
                            if (TeleportPoint.teleportInt == 1)
                            {
                                Debug.Log("Just one player go to game");
                                //transform rig to game
                                player.transform.position = new Vector3(2.85f, 0.036f, 1);
                            }
                            else
                            {

                                if (secondPlayer == false)
                                {
                                    secondPlayer = true;
                                    Debug.Log("Set SecondPlayer");
                                }
                                else
                                {
                                    if (GM.CappedString2 == null)
                                    {
                                        Debug.Log("Set Player First"); 
                                    }
                                    else
                                    {
                                        Debug.Log("Start Game");
                                        //transform rig to game
                                        player.transform.position = new Vector3(2.85f, 0.036f, 1);
                                    }
                                }
                            }
                            Debug.Log("sumbit");
                           // GM.StartBowlingMiniGame();
                        }
                        else /*if (KeyFeedBack.keyHitted != 10)*/
                        {
                            if (secondPlayer == false)
                            {
                                GM.CappedString += key.text;
                            }
                            else
                            {
                                GM.CappedString2 += key.text;
                            }

                        }
                        keyFeedBack.keyHit = true;
                    }
                   
                }
               
            }
        }
    }
}
