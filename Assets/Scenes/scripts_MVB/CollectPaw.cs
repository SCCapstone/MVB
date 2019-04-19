using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPaw : MonoBehaviour
{
    public AudioSource collectSound;

    public void Collect()
    {
        
        {
            collectSound.Play();
            ScoringSystem.theScore += 1;
            Destroy(gameObject);
        }
    }
}
