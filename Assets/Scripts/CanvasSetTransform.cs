using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class CanvasSetTransform : MonoBehaviour
{
    public SteamVR_Input_Sources m_Source = SteamVR_Input_Sources.RightHand;
    public SteamVR_Action_Boolean m_Click = null;

    public Pointer pointerScript;

    public GameObject canvas;
    public LineRenderer pointer;
    public MeshRenderer pointerDot;
    public GameObject telporter;
    public Camera cameraPlayer;
    //[Range(0, 1)]
    public int smoothFactor = 45;
    public bool isClicked = false;
    public float offsetRaduis = 0.3f;
    public float distanceToHead = 4;
    // Update is called once per frame


    public void Update()
    {
        if (m_Click.GetStateDown(m_Source))
        {
            if(isClicked == false)
            {
                isClicked = true;
                canvas.SetActive(false);
                pointer.enabled = false;
                pointerDot.enabled = false;
                if (telporter != null)
                    telporter.SetActive(true);
            }
            else
            {
                isClicked = false;
                canvas.SetActive(true);
                pointer.enabled = true;
                pointerDot.enabled = true;
                pointerScript.UpdateLine();
                if (telporter != null)
                    telporter.SetActive(false);
            }
        }


            // make the UI always face towards the camera
        canvas.transform.rotation = cameraPlayer.transform.rotation;

        var cameraCenter = cameraPlayer.transform.position + cameraPlayer.transform.forward * distanceToHead;

        var currentPos = canvas.transform.position;

        // in which direction from the center?
        var direction = currentPos - cameraCenter;

        // target is in the same direction but offsetRadius
        // from the center
        var targetPosition = cameraCenter + direction.normalized * offsetRaduis;

        // finally interpolate towards this position
        canvas.transform.position = Vector3.Lerp(currentPos, targetPosition, smoothFactor);
    }
}
