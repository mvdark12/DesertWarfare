using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwiseMusicIntro : MonoBehaviour
{

    public bool trigger;
    private bool state = true;
    public Collider player;

    private void OnTriggerEnter(Collider other)
    {
        if (other == player)
        {
            trigger = !trigger;
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (trigger && !state)
        {
            AkSoundEngine.SetState("MusicState", "Intense");
            state = true;
        }
        else if (!trigger && state)
        {
            AkSoundEngine.SetState("MusicState", "Exploration");
            state = false;
        }
    }
}
