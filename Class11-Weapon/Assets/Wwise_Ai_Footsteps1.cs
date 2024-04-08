using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController.AI;

public class Wwise_Ai_Footsteps1 : MonoBehaviour
{
    public GameObject footLeft;  // это объект левой ноги. перетаскиваем в компонент
    public GameObject footRight; // объект правой ноги
    public AK.Wwise.Event footevent; // выбираем ивент Wwise
    public LayerMask lm;
    public GameObject CameraObj;


    public vControlAIShooter AIController;

    void Start()
    {

        AIController = GetComponent<vControlAIShooter>();
    }

    void Update()
    {
        Debug.Log(CameraObj.transform.position.y);
        AkSoundEngine.SetRTPCValue("RTPC_ext_Camera_High", CameraObj.transform.position.y);
    }


    void FootstepWalk(string arg) // вызываем эту функцию из аниматора.  Аргумент стринг - строчка стринг для каждой функции. Её нужно прописать в анимции
    {

            if (arg == "left") // если вызвали функцию с аргументом Left
            {
                Playfootstep(footLeft); // запускаем функцию для объекта левой ноги
            }
            else if (arg == "right") // то же самое для правой ноги
            {
                Playfootstep(footRight);
            }
        
    }




    void Playfootstep(GameObject footObject) // функция проверки поверхности для  нужного геймобъекта
    {
        if (Physics.Raycast(footObject.transform.position, Vector3.down, out RaycastHit hit, 0.3f, lm)) // запускаем рейкаст из объекта нужной ноги вниз
        {
            AkSoundEngine.SetSwitch("SurfaceType", hit.collider.tag, footObject);  // выставляем свитч нужной свитч-группы в положение такое же как тэг поверхности,  на которую наступила нога, применяем свитч для нужной ноги

            if (AIController.isSprinting)
            {
                AkSoundEngine.SetSwitch("LocomotionType", "Run", footObject);
            }
            else if (AIController.isCrouching) // Добавлено условие для проверки приседания
            {
                AkSoundEngine.SetSwitch("LocomotionType", "Crouch", footObject);
            }
            else AkSoundEngine.SetSwitch("LocomotionType", "Walk", footObject);

            footevent.Post(footObject); // запускаем ивент для из нужной ноги
        }


    }

}
