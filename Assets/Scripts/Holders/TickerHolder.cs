using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class TicketHolder
{
    public int Id {get; set;}

    public TicketHolder(){
        Id = Randomizer.GetRandomInt(1000, 10000);
    }
}
