using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchObject : MonoBehaviour
{
    private Renderer rend;
    public Transform target;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = Color.cyan;
    }

    private void OnCollisionEnter(Collision col)
    {
        //  gameObject.SetActive(false);
        if(target != null)
        Destroy(target.gameObject);
    }
}
