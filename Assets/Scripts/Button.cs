using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private GameObject handler;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("hand"))
        {
            StartCoroutine(Pressed());
        }
    }

    private IEnumerator Pressed()
    {
        animator.SetTrigger("pressed");
        yield return new WaitForSeconds(0.5f);
        handler.GetComponent<Animator>().SetTrigger("lowered");

    }
}
