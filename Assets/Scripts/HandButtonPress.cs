using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HandButtonPress : MonoBehaviour
{
    public static int teleportInt;

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
                    if (other.tag == "Button")
                    {
                        if (key.text == "Single Player")
                        {
                            teleportInt = keyFeedBack.teleportNumber;
                            SceneManager.LoadScene(sceneName: "SkeeBall");
                        }
                        else if (key.text == "2 Player")
                        {
                            teleportInt = keyFeedBack.teleportNumber;
                            SceneManager.LoadScene(sceneName: "SkeeBall");
                        }else if (key.text == "Main Menu")
                        {
                            SceneManager.LoadScene(sceneName: "SampleScene");
                        }
                    }
                }
            }
        }
    }
}
