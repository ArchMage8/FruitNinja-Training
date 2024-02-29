using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private ParticleSystem Sparks1;
    [SerializeField] private ParticleSystem Sparks2;
    private GameObject BombSoundObject;
    private AudioSource BombSound;

    [SerializeField] private GameObject Structure;

    [Header ("Values")]
    public int TimeDecrease;
    public int ScoreDecrease;

    private void Awake()
    {
        BombSoundObject = GameObject.Find("BombSound");
        BombSound = BombSoundObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Blade blade = other.GetComponent<Blade>();
            Explode();
        }
    }

    private void Explode()
    {
        BombSound.Play();
        Structure.SetActive(false);
        Sparks1.Play();
        Sparks2.Play();
        Destroy(this.gameObject, 0.5f);

        FindObjectOfType<GameManager>().DecreaseScore(ScoreDecrease);
        FindAnyObjectByType<GameManager>().DecreaseTime(TimeDecrease);
    }
}
