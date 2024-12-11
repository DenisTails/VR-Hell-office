using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class Randomizer
{
    private static Random gen = new Random();

    public static int GetRandomInt(int a){
        return gen.Next(a);
    }

    public static int GetRandomInt(int a, int b){
        return gen.Next(a, b);
    }

    public static float GetRandomFloat(float a, float b){
        return (float) gen.NextDouble() * (b-a) + a;
    }
}
