using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class ActionsListHolder
{
    private List<MyAction> actions = new List<MyAction>();

    public List<MyAction> Actions {get {return this.actions;}}
    public int SealId {get; set;}

    public ActionsListHolder(){
        this.actions = FindActions();
        SealId = CreateSealId();
    }

    public bool IsCorrectSeal(){
        return SealId == 0;
    }

    private int Karma(){
        int sum = 0;
        for (int i = 0; i < actions.Count; i++){
            sum += actions[i].IndexOfGood;
        }
        return sum;
    }

    public bool IsPositiveKarma(){
        return Karma() >= 0;
    }

    private int CreateSealId(){
        int chance =  Randomizer.GetRandomInt(1, 100);

        if (chance >= 50) return 0;
        
        return (chance + 10) / 10;
    }

    private List<MyAction> FindActions(){
        List<MyAction> list = new List<MyAction>();

        int i = -1;
        while (list.Count < 5){

            i = (i + Randomizer.GetRandomInt(1,10)) % MyAction.ListOfActions.Count;
            
            if (list.IndexOf(MyAction.ListOfActions[i]) != -1) continue;

            if (Randomizer.GetRandomInt(0,2) == 1){
                list.Add(MyAction.ListOfActions[i]);
            }
        }

        return list;
    }
}

