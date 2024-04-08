using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;
using static UnityEditor.Profiling.RawFrameDataView;

public class WwiseJump : MonoBehaviour
{
    public AK.Wwise.Event jumpEvent;
    public AK.Wwise.Event landingEvent;
    public AK.Wwise.Event jumpMoveEvent;
    public AK.Wwise.Event footevent;
    string SurfaceType;
    public vThirdPersonInput tpInput;
    public vThirdPersonController tpController;
    public LayerMask lm;
    bool wasAirborne = false;
    // Start is called before the first frame update
    void Start()
    {
        tpInput = GetComponent<vThirdPersonInput>();
        tpController = GetComponent<vThirdPersonController>();

    }

    // Update is called once per frame
    void Update()
    {
        MaterialCheck();
        CheckAirborneState();
    }

    void Jump()
    {
        jumpEvent.Post(gameObject);
    }

    void JumpMove()
    {
        jumpMoveEvent.Post(gameObject);
    }

    void CheckAirborneState()
    {
        bool isAirborne = !tpController.isGrounded;

        if (wasAirborne && !isAirborne)
        {
            MaterialCheck();
            AkSoundEngine.SetSwitch("LocomotionType", "Jump", gameObject);
            AkSoundEngine.SetSwitch("SurfaceType", SurfaceType, gameObject);
            landingEvent.Post(gameObject);
            footevent.Post(gameObject);
        }

        wasAirborne = isAirborne;
    }
    //void Landing()
   // {
      //  MaterialCheck();
      //  AkSoundEngine.SetSwitch("LocomotionType", "Jump", gameObject);
      //  AkSoundEngine.SetSwitch("SurfaceType", SurfaceType, gameObject);
       // landingEvent.Post(gameObject);
   // }

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
