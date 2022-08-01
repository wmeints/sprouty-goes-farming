using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float smoothingSpeed;
    public Transform target;
    
    void LateUpdate()
    {
        var position = target.position;

        // The value for the clam operation I gathered by moving the camera around in the scene and recording
        // the values. Not the best way to do it, but it works.

        var leftEdge = -7.03f;
        var rightEdge = 8.08f;
        var topEdge = -10.82f;
        var bottomEdge = 9.94f;

        // The distance is a fixed value, we want to see the tiles from a preconfigured distance.
        
        var cameraDistance = -10f;
        
        transform.position = new Vector3(
            Mathf.Clamp(position.x,leftEdge, rightEdge), 
            Mathf.Clamp(position.y, topEdge, bottomEdge), 
            cameraDistance);
    }
}
