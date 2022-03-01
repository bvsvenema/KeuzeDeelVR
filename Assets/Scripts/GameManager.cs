using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class GameManager : MonoBehaviour
{

    public void Start()
    {
        //Testing data trough scrips
        if(TeleportPoint.teleportName == "TeleportPoint 2Player")
        {
            Debug.Log("2player Game");
        }else if(TeleportPoint.teleportName == "TeleportPoint SinglePlayer")
        {
            Debug.Log("SinglePlayerGame");
        }
        else
        {
            Debug.Log(TeleportPoint.teleportName);
            Debug.Log("Nothing found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
