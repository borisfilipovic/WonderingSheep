using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Public.
    
    // Private.
    [SerializeField] private Transform movePoint;
    [SerializeField] private float smoothMovement = 0.3f;    
    [SerializeField] private float halfDistance = 15f;
    [SerializeField] private float timer = 1f;
    [SerializeField] private bool activateMovementInStart;
    [SerializeField] private bool deactivateDoors;
    private float initialMovement;
    private Vector3 startPosition;
    private bool smoothMovementHalfed;
    private bool canMove;
    private bool moveToInitial;
    private DoorController doorController;
    private PlatformSoundFX soundFX;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        startPosition = transform.position;
        initialMovement = smoothMovement;

        // Activate doors.
        doorController = GetComponent<DoorController>();

        // Add sound.
        soundFX = GetComponent<PlatformSoundFX>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(activateMovementInStart) {
            Invoke("ActiveMovement", timer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    // Move gameobject aka platform
    private void MovePlatform() {
        if(canMove) {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, smoothMovement);

            // If platform already moved more than half distance.
            if(Vector3.Distance(transform.position, movePoint.position) <= halfDistance) {
                if(!smoothMovementHalfed) {
                    smoothMovement *= 0.5f; // Make half value.
                    smoothMovementHalfed = true;
                }
            }

            // If platform reached destination.
            if (Vector3.Distance(transform.position, movePoint.position) == 0f) {
                // Reset can move flag so it stop moving.
                canMove = false;

                // Reset smooth movement to full value (it was halfed).
                if (smoothMovementHalfed) {
                    smoothMovement = initialMovement;
                    smoothMovementHalfed = false;
                }

                // Deactivate doors.
                if (deactivateDoors) {
                    doorController.OpenDoors();
                }

                // Stop playing audio.
                soundFX.PlayAudio(false);
            }
        }
    }

    // Start platform movement.
    public void ActiveMovement() {
        canMove = true;
        // Play sound fx.
        soundFX.PlayAudio(true);
        // Roate.
    }
}
