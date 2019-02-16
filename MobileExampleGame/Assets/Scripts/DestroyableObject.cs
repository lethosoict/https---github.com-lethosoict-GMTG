using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    public float forceRequireed = 3.0f;

    private void OnCollisionEnter(Collision col)
    {
        if (col.impulse.magnitude > forceRequireed)
            Destroy(gameObject);
        else
            Debug.Log("Not enough force to destroy wall " + col.impulse.magnitude);


    }
}
