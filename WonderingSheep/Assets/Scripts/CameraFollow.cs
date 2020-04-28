using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Public.
    public float moveSmoothing = 10f;
    public float rotationSmoothing = 15f;

    // Private.
    private Transform target;
    private Vector3 targetForward;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        target = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        targetForward = transform.forward;
        targetForward.y = 0f;
        SnapToPlayerPosition(); // On start we want camer to snap to players position.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Snap camera to players(target) location.
    private void SnapToPlayerPosition() {
        // Check for null value.
        if(target != null) {
            transform.position = target.position;
        }
        Vector3 forward = targetForward;
        forward.y = transform.forward.y;
        transform.forward = forward;
    }

    // Camere should follow player method.
    private void FollowPlayer() {
        if(target != null) {
            // Slowly move to new position.
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * moveSmoothing);
        }
        Vector3 forward = transform.forward;
        forward.y = 0f;
        forward = Vector3.Slerp(forward, targetForward, Time.deltaTime * rotationSmoothing);
        forward.y = transform.forward.y;
        transform.forward = forward;
    }
}
