using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private GameObject portal;
    [SerializeField]
    private GameObject soul;
    [SerializeField]
    private Animator soulAnimController;
    [SerializeField]
    private SoulAnim soulAnimScript;
    [SerializeField]
    private GameObject soulDest;
    [SerializeField]
    private AngleController angleCont;

    private Animator animator;
    private bool isPressed = false;
    private bool isMoving = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(isMoving)
        {
            soul.transform.position = Vector3.MoveTowards(soul.transform.position, soulDest.transform.position, 2.0f * Time.deltaTime);
            if (soul.transform.position == soulDest.transform.position)
            {
                isMoving = false;
                Debug.Log("STOP");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("hand") && isPressed == false)
        {
            isPressed = true;
            gameObject.GetComponent<ListController>().Generate();
            Pressed();
        }
    }

    public void pPress()
    {
        isPressed = true;
        gameObject.GetComponent<ListController>().Generate();
        Pressed();
    }

    private void Pressed()
    {
        angleCont.toHell = 0;
        angleCont.isMoving = false;
        animator.SetTrigger("pressed");
        portal.SetActive(true);
        soul.SetActive(true);
        soulAnimScript.timeAnim = 10.0f;
        soulAnimScript.startTimer = true;
        soulAnimController.Play("lookAround");
        isMoving = true;
        isPressed = false;
    }
}
