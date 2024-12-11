using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleController : MonoBehaviour
{

    [SerializeField]
    private GameObject listController;
    [SerializeField]
    public GameObject l1;
    [SerializeField]
    public GameObject l2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<HingeJoint>().angle > 44){
            Debug.Log("To Hell");
            listController.GetComponent<ListController>().FinalVerdict(false);
            l1.SetActive(false);
            l2.SetActive(false);
        }
        else if (gameObject.GetComponent<HingeJoint>().angle < -44){
            Debug.Log("To Heaven");
            listController.GetComponent<ListController>().FinalVerdict(true);
        }
        else
        {
            l1.SetActive(true);
            l2.SetActive(true);
        }
    }
}
