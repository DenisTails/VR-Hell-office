using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField]
    private GameObject handler;
    private void FixedUpdate()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(handler);
    }

    private void OnTriggerStay(Collider other)
    {
    }
}
