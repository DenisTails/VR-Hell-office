using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleController : MonoBehaviour
{

    [SerializeField]
    private GameObject listController;

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
        }
        else if (gameObject.GetComponent<HingeJoint>().angle < -44){
            Debug.Log("To Heaven");
            listController.GetComponent<ListController>().FinalVerdict(true);
        }
    }
}
