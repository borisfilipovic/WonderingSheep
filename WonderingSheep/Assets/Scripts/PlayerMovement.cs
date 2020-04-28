using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Public.
    public float moveSpeed = 3f;

    // Private.
    private Rigidbody rigidbody;
    private float smoothMovement = 15f;
    private bool canMove;
    private Vector3 targetForward;
    private Vector3 positionChange;
    private Camera mainCameraReference;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        targetForward = transform.forward;
        mainCameraReference = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateForward();
        GetInput();
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        MovePlayer();
    }

    private void GetInput() {
        // Get left mouse click.
        if (Input.GetMouseButtonDown(0)) {
            canMove = true;
        } else if (Input.GetMouseButtonUp(0)) {
            canMove = false;
        }
    }

    private void UpdateForward() {
        transform.forward = Vector3.Slerp(transform.forward, targetForward, Time.deltaTime * smoothMovement);
    }

    private void MovePlayer() {
        if (canMove) {
            // Delta position. Calculate how much we need to move player.
            positionChange = new Vector3(Input.GetAxisRaw(Axix.MOUSE_X), 0.0f, Input.GetAxisRaw(Axix.MOUSE_Y));
            positionChange.Normalize();
            positionChange *= moveSpeed * Time.fixedDeltaTime;
            positionChange = Quaternion.Euler(0f, mainCameraReference.transform.eulerAngles.y, 0f) * positionChange;

            // Move gameobjest - player.
            rigidbody.MovePosition(rigidbody.position + positionChange);

            if(positionChange != Vector3.zero) {
                // Model is faced the wrong way so that is why we have negative value here.
                targetForward = Vector3.ProjectOnPlane(-positionChange, Vector3.up);
            }
        }
    }
}
