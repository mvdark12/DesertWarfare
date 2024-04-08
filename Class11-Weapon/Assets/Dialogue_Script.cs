using UnityEngine;
using UnityEngine.Events;
using AK.Wwise;
using System.Collections;

public class Dialogue_Script : MonoBehaviour
{
    public AK.Wwise.Event audioEvent; // Drag your AK Event from the Wwise Picker here
    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed && other.CompareTag("Player")) // assuming the player has a "Player" tag
        {
            PlayAudioEvent();
            hasPlayed = true;
            StartCoroutine(ResetAudioTrigger());
        }
    }

    private void PlayAudioEvent()
    {
        if (audioEvent != null)
        {
            audioEvent.Post(gameObject);
        }
    }

    private IEnumerator ResetAudioTrigger()
    {
        yield return new WaitForSeconds(10f); // ждем 10 секунд
        hasPlayed = false; // разрешаем воспроизведение звука снова
    }
}
