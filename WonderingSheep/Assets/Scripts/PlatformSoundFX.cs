using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSoundFX : MonoBehaviour
{
    // Private.
    private AudioSource audioFX;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        
    }

    public void PlayAudio(bool play) {
        switch (play) {
        case true:
            audioFX.Play();
            break;
        case false:
            audioFX.Stop();
            break;
        }
    }
}
