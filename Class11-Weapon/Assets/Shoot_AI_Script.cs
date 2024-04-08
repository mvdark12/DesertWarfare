using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController.AI;

public class Shoot_AI_Script : MonoBehaviour
{
    public AK.Wwise.Event rifle_oneshotEvent;
    public AK.Wwise.Event rifle_reloadEvent;
    public GameObject CameraObj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(CameraObj.transform.position.y);
        AkSoundEngine.SetRTPCValue("RTPC_Distance", CameraObj.transform.position.y);
    }


    void rifle_oneshot()
    {
        rifle_oneshotEvent.Post(gameObject);
    }

    void ReloadRiffle()
    {
        rifle_reloadEvent.Post(gameObject);
    }
}
