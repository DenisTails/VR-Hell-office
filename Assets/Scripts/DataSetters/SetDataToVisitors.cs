using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDataToVisitors : MonoBehaviour, IVisitorsHolderSettable
{
    private List<DeadListHolder> visitors;

    public void Set(List<DeadListHolder> visitors)
    {
        this.visitors = visitors;
        Transform fields = transform.Find("Canvas/Image/Panel").transform;

        for(int i = 0; i < 7; i++){
            fields.GetChild(i).GetComponent<Text>().text = 
            visitors[i].Surname + " " + visitors[i].Name + " " + visitors[i].Patronymic + "\n" +
            "Свидетесльство №" + visitors[i].Id;
        }
    }
}
