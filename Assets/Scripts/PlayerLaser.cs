using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{

    public int laserDamage = 1;
    public float laserRange = 100f;
    public Transform gunBarrel;

    private Camera mainCamera;

    LineRenderer laserLine;
    AudioSource laserAudio;

    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        laserAudio = GetComponent<AudioSource>();
        mainCamera = GetComponentInParent<Camera>();
        laserLine.enabled = false;
    }

    void Update()
    {
    
        // Create a vector at the center of our camera's viewport
        Vector3 rayOrigin = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        RaycastHit hit;

        laserLine.SetPosition(0, gunBarrel.position);
        // Check if our raycast has hit anything
        if (Physics.Raycast(rayOrigin, mainCamera.transform.forward, out hit, laserRange))
        {
            //! set where thing turn
            gameObject.transform.LookAt(hit.point);
            // Set the end position for our laser line 
            laserLine.SetPosition(1, hit.point);

            if (Input.GetButton("Fire1"))
            {
                Firing();
            }
            else
            {
                NotFiring();
            }
        }
        else
        {
            laserLine.SetPosition(1, rayOrigin + (mainCamera.transform.forward * laserRange));
        }
    }

    void Firing()
    {
        laserLine.enabled = true;
        //add more effects here later
    }

    void NotFiring()
    {
        laserLine.enabled = false;
    }

}
