using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFeedBack : MonoBehaviour
{
    private AudioSource keyHitSound;
    public bool keyHit = false;
    public bool keyCanHitAgain = false;
    public static int keyHitted;
    public int teleportNumber;
    public bool teleportAltar = false;
    //private SoundHandler soundHandler;

    private float originalYposistion;
    // Start is called before the first frame update
    void Start()
    {
        keyHitSound = GetComponent<AudioSource>();
        originalYposistion = transform.position.y;
        //soundHandler = GameObject.FindGameObjectWithTag("SoundHandler").GetComponent<SoundHandler>();
    }

    // Update is called once per frame
    void Update()
    {

        if (keyHit)
        {
            if (teleportAltar == false)
            {
                keyHitSound.Play();
                //soundHandler.PlayKeyClick();
                keyCanHitAgain = false;
                keyHit = false;
                transform.position += new Vector3(0, -0.03f, 0);
            }
            else
            {
                transform.position += new Vector3(0, -3, 0);
            }
        }
        if (transform.position.y < originalYposistion)
        {
            transform.position += new Vector3(0, 0.0005f, 0);
        }
        else
        {
            keyCanHitAgain = true;
        }
    }


}
