using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [Header("Fruit Reference")]
    public GameObject whole;
    public GameObject sliced;

    [Space(10)]

    private GameObject SliceSoundObject;
    private AudioSource SliceSound;

    private Rigidbody fruitRigidbody;
    private Collider fruitCollider;

    private ParticleSystem Juices;
   

    private bool Sliced;

    private void Awake()
    {
        fruitRigidbody = GetComponent<Rigidbody>();
        fruitCollider = GetComponent<Collider>();
        Juices = GetComponentInChildren<ParticleSystem>();
        SliceSoundObject = GameObject.Find("SliceSound");

        SliceSound = SliceSoundObject.GetComponent<AudioSource>();
    }
    private void Slice(Vector3 direction, Vector3 position, float force)
    {

        Sliced = true;


        whole.SetActive(false);
        sliced.SetActive(true);

        fruitCollider.enabled = false;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        sliced.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Rigidbody[] slices = sliced.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody slice in slices)
        {
            slice.velocity = fruitRigidbody.velocity;
            slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
        }

        Juices.Play();
        
        SliceEffect();

        FindObjectOfType<GameManager>().IncreaseScore(1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SliceSound.Play();
            Blade blade = other.GetComponent<Blade>();
            Slice(blade.direction, blade.transform.position, blade.sliceForce);
        }
    }

    private void SliceEffect()
    {
        if (Sliced)
        {

            transform.Rotate(90f, 0f, 0f);
            Invoke("DelayedDisable", 0.1f);
        }
    }

    void DelayedDisable()
    {
        DisableColliders(transform);
    }

    void DisableColliders(Transform parent)
    {
        foreach (Transform child in parent)
        {
            
            BoxCollider boxCollider = child.GetComponent<BoxCollider>();
            if (boxCollider != null)
            {
                boxCollider.enabled = false;
            }

            
            DisableColliders(child);
        }
    }
}
