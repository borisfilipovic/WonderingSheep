using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    // Private.
    private Transform[] childred;
    [SerializeField] private bool deactiveInStart;

    // Start is called before the first frame update
    void Start()
    {
        // Get all objects, so we get access to doors.
        childred = transform.GetComponentsInChildren<Transform>();

        // If we want to deactive doors at start time.
        if(deactiveInStart) {
            OpenDoors();
        }
    }

    public void OpenDoors() {
        foreach(Transform c in childred) {
            if(c.CompareTag(Tags.DOOR_TAG)) { // Find objects with door tag.
                c.gameObject.GetComponent<Collider>().isTrigger = true;
            }
        }
    }
}
