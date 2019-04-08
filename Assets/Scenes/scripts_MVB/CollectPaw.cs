using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPaw : MonoBehaviour
{
    public AudioSource collectSound;

    public void Collect()//(Collider other)
    {
        collectSound.Play();
        ScoringSystem.theScore += 1;
        Destroy(gameObject);
    }
}
