using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectClemPaws : MonoBehaviour
{
    public AudioSource collectSound;

    public void Collect()//(Collider other)
    {
        collectSound.Play();
        ScoreSystem.theScore += 1;
        Destroy(gameObject);
    }
}