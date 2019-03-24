using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CREAT empty object, use FOLLOW script, place it at center of player, have it
// rotate/face same direction as camera, then have that object dictate movedirection
//Use this on the Follow object
/*    RaycastHit2D[] hits;

//We raycast down 1 pixel from this position to check for a collider
Vector2 positionToCheck = transform.position;
hits = Physics2D.RaycastAll (positionToCheck, new Vector2 (0, -1), 0.01f);

//if a collider was hit, we are grounded
if (hits.Length > 0) {
    Grounded = true;
    */

       

public class CameraBoy : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float xSensitivity = 1.0f;
    public float ySensitivity = 1.0f;
    //  private float distance = 5f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    float x;
    float y;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    void LateUpdate()
    {
        x += Input.GetAxis("Mouse X") * xSensitivity * distance;
        y -= Input.GetAxis("Mouse Y") * ySensitivity;

        y = ClampAngle(y, yMinLimit, yMaxLimit);

        Quaternion rotation = Quaternion.Euler(y, x, 0);

        /*      
        if (Physics.Linecast(target.position, transform.position, out RaycastHit hit))
        {
            distance -= hit.distance;
        }
        else
        {
            distance = florp;
        }
        */
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 position = rotation * negDistance + target.position;

        transform.rotation = rotation;
        transform.position = position;
        
        OccludeRay();
    }

    void OccludeRay ()
    {
        // Stolen from: https://forum.unity.com/threads/complete-camera-collision-detection-third-person-games.347233/
        RaycastHit wallHit = new RaycastHit();
        //linecast from your player (targetFollow) to your cameras mask (camMask) to find collisions.
        if (Physics.Linecast(target.position, transform.position, out wallHit))
        {
            print("hit");
            //the x and z coordinates are pushed away from the wall by hit.normal.
            //the y coordinate stays the same.
            transform.position = new Vector3(wallHit.point.x + wallHit.normal.x * 0.5f, transform.position.y, wallHit.point.z + wallHit.normal.z * 0.5f);
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
