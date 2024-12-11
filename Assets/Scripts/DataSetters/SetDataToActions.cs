using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDataToActions : MonoBehaviour, IActionsHolderSettable
{
    [SerializeField]
    private List<Sprite> sprites;
    private ActionsListHolder actionsList;

    public void Set(ActionsListHolder actionsList)
    {
        this.actionsList = actionsList;
        Transform fields = transform.Find("Canvas/Image/Texts").transform;

        for(int i = 0; i < 5; i++){
            fields.GetChild(i).GetComponent<Text>().text = actionsList.Actions[i].Desc;
        }

        transform.Find("Canvas/Image/Seal").GetComponent<Image>().sprite = sprites[actionsList.SealId];
    }
}
