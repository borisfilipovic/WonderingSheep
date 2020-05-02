using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{

    // Private.
    [SerializeField] private Vector3 rotatingAngles;    
    [SerializeField] private float smoothRotation = 1.0f;
    [SerializeField] private bool canRotate;
    [SerializeField] private float deactivateTimer = 5.0f;
    private PlatformSoundFX soundFX;
    private Quaternion initialRotation;
    private bool backToInitialRotation;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        // Save initial default rotation so we can reset it later on if necessary.
        initialRotation = transform.rotation;

        // Get audio platform sound fx component reference.
        soundFX = GetComponent<PlatformSoundFX>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlatform();
    }

    private void RotatePlatform() {
        // Check if we should rotate platform.
        if (!canRotate) {return;}

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotatingAngles.x, rotatingAngles.y, rotatingAngles.z), smoothRotation * Time.deltaTime);
    }

    public void ActivateRotation() {
        if (!canRotate) {
            canRotate = true;
            soundFX.PlayAudio(true);
            Invoke("DeactivateRotation", deactivateTimer);
        }
    }

    private void DeactivateRotation() {
        canRotate = false;
        soundFX.PlayAudio(false);
    }
}
