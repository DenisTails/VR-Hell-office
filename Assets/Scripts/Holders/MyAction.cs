using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class MyAction
{
    public string Desc {get; set;}
    public int IndexOfGood {get; set;}

    public static List<MyAction> ListOfActions = new List<MyAction>(){
        new MyAction("Срывал листься с деревьев", -3),
        new MyAction("Достал кошку с дерева", 3),
        new MyAction("Пил", 4),
        new MyAction("Не ходил на пары", -5),
        new MyAction("Кормил бездомных котят", 2),
        new MyAction("Украл тапок в магазине", -1),
        new MyAction("Безработный", -2),
    };

    public MyAction(string desc, int index){
        Desc = desc;
        IndexOfGood = index;
    }
}

