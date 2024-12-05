using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class DeadListHolder
{
    private Random gen = new Random();
    public int Id {get; set;}
    public string Surname {get; set;}
    public string Name {get; set;}
    public int Age {get; set;}
    public string Patronymic {get; set;}
    public DateTime Date {get; set;}
    public string Reason {get; set;}
    public int SealdId {get; set;}

    public DeadListHolder(){
        Id = gen.Next(0, 1000);
        Surname = surnames[gen.Next(0, surnames.Count)];
        Name = names[gen.Next(0, names.Count)];
        Patronymic = patronymics[gen.Next(0, patronymics.Count)];
        Age = gen.Next(0, 140);
        Reason = reasons[gen.Next(0, reasons.Count)];
        Date = RandomDay();
        SealdId = CreateSealId();
    }

    private int CreateSealId(){
        int chance =  gen.Next(1, 100);

        if (chance >= 50) return 0;
        
        return (chance + 10) / 10;
    }

    private DateTime RandomDay()
    {
        DateTime start = new DateTime(2024, 1, 1);
        int range = (DateTime.Today - start).Days;
        return start.AddDays(gen.Next(range));
    }

    private List<string> surnames = new List<string>(){
        "Петров", "Иванов", "Сидоров"
    };

    private List<string> names = new List<string>(){
        "Петр", "Иван", "Тимур"
    };

    private List<string> patronymics = new List<string>(){
        "Петрович", "Иванович", "Тимурович"
    };

    private List<string> reasons = new List<string>(){
        "Упал на лестнице", "Сбила машина", "Съела акула"
    };
}
