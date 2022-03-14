using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    private GameObject player;
    public GameObject playerPrefab;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player);
        if (player == null)
        {
            Instantiate(playerPrefab, new Vector3(0, 0.003f, 0), Quaternion.identity);
            Debug.Log("Spawn Player");
        }
        else
        {
            player.transform.position = new Vector3(0, 0.003f, 0);
        }
    }
}
