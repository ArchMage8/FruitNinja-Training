using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Camera mainCamera;
    private Collider bladeCollider;
    private TrailRenderer bladeTrail;
    private bool slicing;
    public bool Slicing => slicing;

    public float sliceForce = 5f;
    public Vector3 direction { get; private set; }
    public float minSliceVelocity = 0.01f;


    private void Awake()
    {
        mainCamera = Camera.main;
        bladeCollider = GetComponent<Collider>();
        bladeTrail = GetComponentInChildren<TrailRenderer>();
    }

    private void OnEnable()
    {
        StopSlicing();
    }

    private void OnDisable()
    {
        StopSlicing();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            StartSlicing();
        }

        else if (Input.touchCount == 0)
        {
            StopSlicing();
        }

        else if (slicing)
        {
            ContinueSlicing();
        }
    }

    private void StartSlicing()
    {
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);


            Vector3 newPosition = mainCamera.ScreenToWorldPoint(touch.position);
            newPosition.z = 0f;


            transform.position = newPosition;


            slicing = true;


            bladeCollider.enabled = true;
            bladeTrail.enabled = true;

        }
       
    }

    private void StopSlicing()
    {
        bladeTrail.Clear();
        slicing = false;
        bladeCollider.enabled = false;
    }

    private void ContinueSlicing()
    {
       
        if (Input.touchCount > 0)
        {
           
            Touch touch = Input.GetTouch(0);

           
            Vector3 newPosition = mainCamera.ScreenToWorldPoint(touch.position);
            newPosition.z = 0f;

           
            direction = newPosition - transform.position;

          
            float velocity = direction.magnitude / Time.deltaTime;

            bladeCollider.enabled = velocity > minSliceVelocity;

           
            transform.position = newPosition;
        }
    }

}
