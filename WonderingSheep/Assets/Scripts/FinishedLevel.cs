using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishedLevel : MonoBehaviour
{

    // Private.
    [SerializeField] private string nextLevelName;
    [SerializeField] private float timer = 2.0f;
    private bool levelFinished = false;
    private PlatformSoundFX soundFX;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        // Get sound fx component.
        soundFX = GetComponent<PlatformSoundFX>();
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        print("Trigger entered");
        if(other.CompareTag(Tags.PLAYER_TAG)) {
            if (!levelFinished) {
                levelFinished = true;
                //soundFX.PlayAudio(true);
print("Invoke methodTrigger entered");
                // Open next level.
                Invoke("LoadNewLevel", timer); 
            }
        }
    }

    private void LoadNewLevel() {
        print("Load new scene.");
        SceneManager.LoadScene(nextLevelName);
    }
}
