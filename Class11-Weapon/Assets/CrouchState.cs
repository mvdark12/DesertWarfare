using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CrouchState : MonoBehaviour
{
    public vThirdPersonInput tpInput;
    public vThirdPersonController tpController;
    // Start is called before the first frame update
    void Start()
    {
        tpController = GetComponent<vThirdPersonController>();
        tpInput = GetComponent<vThirdPersonInput>();

        AkSoundEngine.SetState("Player_State", "Standing");
    }

    // Update is called once per frame
    void Update()
    {
        if (tpController.isCrouching)
        {
            AkSoundEngine.SetState("Player_State", "Crouch");
        }
        else AkSoundEngine.SetState("Player_State", "Standing");
    }
}
