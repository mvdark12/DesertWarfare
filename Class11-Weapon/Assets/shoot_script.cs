using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;
using Invector.vShooter;

public class shoot_script : MonoBehaviour
{
    public vShooterMeleeInput tpinput;
    public AK.Wwise.Event startEvent;
    public AK.Wwise.Event stopEvent;
    public AK.Wwise.Event reloadEvent;
    public GameObject CameraObj;
    bool prevButtonPressed = false;
    bool prevReload = false;
    bool eventStarted = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
       var buttonPressed = tpinput.shotInput.GetButton();

        if (buttonPressed != prevButtonPressed)
        {
            if (buttonPressed)
            {
                Debug.Log("EventStart");
                startEvent.Post(gameObject);
                eventStarted = true;

            }
            else if(eventStarted)
            {
                Debug.Log("EventStop");
                stopEvent.Post(gameObject);
                eventStarted = false;
            }

        }
        else if (buttonPressed)
        {
            if (tpinput.isReloading && eventStarted)
            {
                Debug.Log("EventStop");
                eventStarted = false;
                stopEvent.Post(gameObject);
            }
            else if (!tpinput.isReloading && !eventStarted)
            {
                Debug.Log("EventStart");
                eventStarted = true;
                startEvent.Post(gameObject);
            }
        }


        prevButtonPressed = buttonPressed;
        prevReload = tpinput.isReloading;

        Debug.Log(CameraObj.transform.position.y);
        AkSoundEngine.SetRTPCValue("RTPC_Distance", CameraObj.transform.position.y);

    }

    void ReloadRiffle()
    {
        reloadEvent.Post(gameObject);
    }
}
