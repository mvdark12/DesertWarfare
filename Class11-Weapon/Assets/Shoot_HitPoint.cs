using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;

public class Shoot_HitPoint : MonoBehaviour
{
    public AK.Wwise.Event shoot_damageEvent;
    public AK.Wwise.Event death_Event;
    public AK.Wwise.Event shoot_damage_AI_Event;
    public AK.Wwise.Event deathAI_Event;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void shootDamageconfirm()
    {
        shoot_damageEvent.Post(gameObject);
    }

    public void Death()
    {
        death_Event.Post(gameObject);
    }

    public void shootDamageAIconfirm()
    {
        shoot_damage_AI_Event.Post(gameObject);
    }

    public void Death_AI()
    {
        deathAI_Event.Post(gameObject);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
