using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns_Oneshot : MonoBehaviour
{
    public AK.Wwise.Event pistol_oneshotEvent;
    public AK.Wwise.Event pistolreloadEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void pistol_oneshot()
    {
        pistol_oneshotEvent.Post(gameObject);
    }

    void PistolReload()
    {
        pistolreloadEvent.Post(gameObject);
    }
}
