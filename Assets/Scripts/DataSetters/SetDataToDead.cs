using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDataToDead : MonoBehaviour, IDeadListHolderSettable
{
    [SerializeField]
    private List<Sprite> sprites;

    private DeadListHolder deadListHolder;

    public void Set(DeadListHolder holder)
    {
        deadListHolder = holder;
        transform.Find("Canvas/Image/Fields").transform.GetChild(0).GetComponent<Text>().text = deadListHolder.Id.ToString();
        transform.Find("Canvas/Image/Fields").transform.GetChild(1).GetComponent<Text>().text = deadListHolder.Surname.ToString();
        transform.Find("Canvas/Image/Fields").transform.GetChild(2).GetComponent<Text>().text = deadListHolder.Name.ToString();
        transform.Find("Canvas/Image/Fields").transform.GetChild(3).GetComponent<Text>().text = deadListHolder.Patronymic.ToString();
        transform.Find("Canvas/Image/Fields").transform.GetChild(4).GetComponent<Text>().text = deadListHolder.Age.ToString();
        transform.Find("Canvas/Image/Fields").transform.GetChild(5).GetComponent<Text>().text = deadListHolder.Date.ToString();
        transform.Find("Canvas/Image/Fields").transform.GetChild(6).GetComponent<Text>().text = deadListHolder.Reason.ToString();
        transform.Find("Canvas/Image/Seal").GetComponent<Image>().sprite = sprites[deadListHolder.SealdId];
    }
}
