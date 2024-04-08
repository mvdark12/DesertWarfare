using UnityEngine;
using AK;
using Invector.vCharacterController;

public class SnapshotDamage : MonoBehaviour
{
    public vThirdPersonInput tpInput;
    public vThirdPersonController tpController;
    public AK.Wwise.Event HeartBeatevent;


    private bool snapPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        tpController = GetComponent<vThirdPersonController>();
        tpInput = GetComponent<vThirdPersonInput>();
        HeartBeatevent.Post(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (tpController.currentHealth <= 50)
        {
            AkSoundEngine.SetState("HealthDamage", "Damage");
        }
        else AkSoundEngine.SetState("HealthDamage", "Normal");
 
    }
}
