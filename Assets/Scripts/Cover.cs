using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Cover : MonoBehaviour
{
    private Animator animator;
    private bool isOpened;

    private void Start()
    {
        animator = GetComponent<Animator>();
        isOpened = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.ToString());

        if (collision.gameObject.CompareTag("hand") && isOpened == false)
        {
            isOpened = true;
            animator.SetBool("isOpened", true);
        }
    }

}