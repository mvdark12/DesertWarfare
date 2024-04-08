using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDistance_Shoot : MonoBehaviour
{
    public GameObject CameraObj;

 
    public AK.Wwise.Event CameraDistanceEvent;



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
}

