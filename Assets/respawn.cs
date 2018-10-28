using UnityEngine;
using System.Collections;

public class respawn : MonoBehaviour
{
    //public float threshold;

    void FixedUpdate()
    {
        if (transform.position.y < -10)
            transform.position = new Vector3(0, 0, 0);
    }
}