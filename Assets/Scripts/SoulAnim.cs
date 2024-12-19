using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulAnim : MonoBehaviour
{
    [SerializeField]
    private Animator Anim;
    [SerializeField]
    public float timeAnim = 10.0f;
    [SerializeField]
    public bool startTimer = true;

    void Start()
    {
        
    }


    void Update()
    {
        if(startTimer)
        timeAnim -= Time.deltaTime;

        if (timeAnim <= 0.0f)
        {
            makeAnim();
        }

    }

    public void makeAnim()
    {
        int rnd = Random.Range(1,3);
        if (rnd == 1)
        {
            Anim.Play("lookAround");
        }
        else if(rnd == 2)
        {
            Anim.Play("lookDown");
        }
        timeAnim = 10.0f;
    }
    
    public void toHell()
    {
        startTimer = false;
        Anim.Play("toHell");
    }

    public void toHeven()
    {
        startTimer = false;
        Anim.Play("toHeven");
    }


}


