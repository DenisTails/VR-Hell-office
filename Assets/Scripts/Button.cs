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
    private GameObject soulDest;

    private Animator animator;
    private bool isPressed = false;
    private bool isMoving = false;

    [SerializeField]
    private GameObject listToSpawn;

    [SerializeField]
    private GameObject placeforlistToSpawn;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(isMoving)
        {
            soul.transform.position = Vector3.MoveTowards(soul.transform.position, soulDest.transform.position, 1.0f * Time.deltaTime);
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
            SpawnList();
            StartCoroutine(Pressed());
        }
    }

    private void SpawnList(){
        DeadListHolder h = new DeadListHolder();
        GameObject instance = Instantiate(listToSpawn, placeforlistToSpawn.transform.position, new Quaternion(180,120,180,0));
        instance.GetComponent<IDeadListHolderSettable>().SetDeadList(h);
    }

    private IEnumerator Pressed()
    {
        animator.SetTrigger("pressed");
        yield return new WaitForSeconds(0.5f);
        // portal.SetActive(true);
        soul.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        isMoving = true;
        isPressed = false;
    }
}
