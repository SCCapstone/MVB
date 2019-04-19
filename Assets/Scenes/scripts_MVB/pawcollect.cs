using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pawcollect : MonoBehaviour
{
    public AudioSource collectSound;
    public AudioSource allPawsCollected;
    private static int IDCounter = 0;
    public int thisPawID = -1;
    public void Reset()
    { // after you first add this script, run Reset on every paw; when creating new paws it should assign new numbers as you create them
        thisPawID = IDCounter;
        IDCounter++;
    }
    public static Dictionary<int, bool> pawCollectedDatabase;

    void Awake()
    {
        if (pawCollectedDatabase == null) pawCollectedDatabase = new Dictionary<int, bool>();
    }

    void Start()
    {
        if (pawCollectedDatabase.ContainsKey(thisPawID))
        { //we're reloading the scene
            if (pawCollectedDatabase[thisPawID]) Destroy(gameObject); //we've been collected already; destroy ourself
        }
        else
        {
            pawCollectedDatabase.Add(thisPawID, false);
        }
    }
    public void CallThisWhenCollected()
    {
        pawCollectedDatabase[thisPawID] = true;
        collectSound.Play();
        ScoringSystem.theScore += 1;
        Destroy(gameObject);
        if(pawCollectedDatabase.ContainsKey(thisPawID = 0) && pawCollectedDatabase.ContainsKey(thisPawID = 1))
        {
            allPawsCollected.Play();
            GameObject rewardImage = Instantiate(Resources.Load("vidal"),
                                     new Vector3(-20, 0, -9),
                                     Quaternion.identity) as GameObject;

        }
            

    }
}
