using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformButton : MonoBehaviour
{

    // Private.
    private RotatingPlatform rotatingPlatform;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        // Get rotating platform reference. We need to get component in parent because this object is child.  
        rotatingPlatform = GetComponentInParent<RotatingPlatform>();
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {        
        if(other.CompareTag(Tags.PLAYER_TAG)) {
            // Rotate platform.
            rotatingPlatform.ActivateRotation();
        }
    }
}
