using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDataToTicket : MonoBehaviour, ITicketHolderSettable
{
    private TicketHolder ticketHolder;

    public void Set(TicketHolder holder)
    {
        ticketHolder = holder;
        transform.Find("Canvas/Image/Id").GetComponent<Text>().text = ticketHolder.Id.ToString();
    }
}
