using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleController : MonoBehaviour
{

    [SerializeField]
    private GameObject listController;
    [SerializeField]
    public AudioSource soul;
    [SerializeField]
    public GameObject hl;
    private bool scream = true;
    [SerializeField]
    private GameObject soulobj;
    [SerializeField]
    private GameObject soulStartPos;
    [SerializeField]
    private GameObject soulDest;
    [SerializeField]
    private GameObject soulDest2;
    [SerializeField]
    private GameObject lever;
    [SerializeField]
    private GameObject leverStart;
    [SerializeField]
    private Animator Anim;
    [SerializeField]
    public bool isMoving = false;
    [SerializeField]
    public int toHell = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (toHell==1 && soulobj.activeSelf==true)
        {
            if (isMoving)
            {
                soulobj.transform.position = Vector3.MoveTowards(soulobj.transform.position, soulDest.transform.position, 2.5f * Time.deltaTime);
                if (soulobj.transform.position == soulDest.transform.position)
                {
                    isMoving = false;

                    lever.transform.rotation = leverStart.transform.rotation;
                    Debug.Log("STOP");
                    
                    soulobj.transform.position = soulStartPos.transform.position;

                    toHell = 0;
                    listController.GetComponent<ListController>().FinalVerdict(false);

                    Anim.Play("close");
                    soulobj.SetActive(false);
                }
                
            }
        }
        else if( toHell == 2 && soulobj.activeSelf == true )
        {
            if (isMoving) { 
                hl.SetActive(true);
                soulobj.transform.position = Vector3.MoveTowards(soulobj.transform.position, soulDest2.transform.position, 5.0f * Time.deltaTime);
                if (soulobj.transform.position == soulDest2.transform.position)
                {
                    isMoving = false;
                    
                    lever.transform.rotation = leverStart.transform.rotation;
                    Debug.Log("STOP");
                    
                    soulobj.transform.position = soulStartPos.transform.position;
                    
                    hl.SetActive(false);
                    listController.GetComponent<ListController>().FinalVerdict(true);

                    toHell = 0;
                    soulobj.SetActive(false);
                }
                
            }
        }

        if (gameObject.GetComponent<HingeJoint>().angle > 44){
            Debug.Log("To Hell");
            
            if (scream) soul.Play();
            scream = false;
            isMoving = true;
            toHell = 1;
            Anim.Play("open");
        }
        else if (gameObject.GetComponent<HingeJoint>().angle < -44){
            Debug.Log("To Heaven");
            
            
            isMoving = true;
            toHell = 2;
        }
        else
        {
            
            Debug.Log(toHell);
            
            if (!isMoving)
            {
                toHell = 0;
                hl.SetActive(false);
                Anim.Play("close");
                scream = true;
            }
            
        }
    }
}
