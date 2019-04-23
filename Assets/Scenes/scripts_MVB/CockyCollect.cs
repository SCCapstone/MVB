using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockyCollect : MonoBehaviour
{
    public AudioSource collectSound;
    public AudioSource allCockysCollected;
    private static int IDCounter = 0;
    public int thisCockyID = -1;
    public void Reset()
    { // after you first add this script, run Reset on every Cocky; when creating new Cockys it should assign new numbers as you create them
        thisCockyID = IDCounter;
        IDCounter++;
    }
    public static Dictionary<int, bool> cockyCollectedDatabase;

    void Awake()
    {
        if (cockyCollectedDatabase == null) cockyCollectedDatabase = new Dictionary<int, bool>();
    }

    void Start()
    {
        if (cockyCollectedDatabase.ContainsKey(thisCockyID))
        { //we're reloading the scene
            if (cockyCollectedDatabase[thisCockyID]) Destroy(gameObject); //we've been collected already; destroy ourself
        }
        else
        {
            cockyCollectedDatabase.Add(thisCockyID, false);
        }
    }
    public void CallThisWhenCollected()
    {
        cockyCollectedDatabase[thisCockyID] = true;
        collectSound.Play();
        ScoringSystem.theScore += 1;
        Destroy(gameObject);
        if (cockyCollectedDatabase.ContainsKey(thisCockyID = 0) && cockyCollectedDatabase.ContainsKey(thisCockyID = 1)
            && cockyCollectedDatabase.ContainsKey(thisCockyID = 2) && cockyCollectedDatabase.ContainsKey(thisCockyID = 3)
            && cockyCollectedDatabase.ContainsKey(thisCockyID = 4))
        {
            allCockysCollected.Play();
        }

    }
}