using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController.AI;
using static Invector.vCharacterController.AI.vAIMotor;
using static UnityEditor.Profiling.RawFrameDataView;

public class Wwise_AI_Footsteps : MonoBehaviour
{
    public AK.Wwise.Event footstepEvent;
    public AK.Wwise.Event runEvent;
    string SurfaceType;
    public vControlAIShooter AIController;
    public LayerMask lm;
    // Start is called before the first frame update
    void Start()
    {
        AIController = GetComponent<vControlAIShooter>();
    }

    // Update is called once per frame
    void Update()
    {
        MaterialCheck();
    }

    void FootstepWalk()
    {

        MaterialCheck();
        AkSoundEngine.SetSwitch("LocomotionType", "Walk", gameObject);
        AkSoundEngine.SetSwitch("SurfaceType", SurfaceType, gameObject);
        footstepEvent.Post(gameObject);
            
        
    }

    void FootstepRun()
    {
        MaterialCheck();
        AkSoundEngine.SetSwitch("LocomotionType", "Run", gameObject);
        AkSoundEngine.SetSwitch("SurfaceType", SurfaceType, gameObject);
        runEvent.Post(gameObject);
    }

    void MaterialCheck()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit rH, 0.05f, lm))
        {
            Debug.Log(rH.collider.tag);
            if (rH.collider.tag == "Asphalt") SurfaceType = "Asphalt";
            else if (rH.collider.tag == "Water") SurfaceType = "Water";
            else if (rH.collider.tag == "Tile") SurfaceType = "Tile";
            else if (rH.collider.tag == "Concrete") SurfaceType = "Concrete";
            else if (rH.collider.tag == "Stairs") SurfaceType = "Stairs";
            else if (rH.collider.tag == "Sand") SurfaceType = "Sand";
            else if (rH.collider.tag == "Dirt") SurfaceType = "Dirt";
            else if (rH.collider.tag == "Metal") SurfaceType = "Metal";
        }
    }

}

