﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayerIsSneezing : MonoBehaviour
{
    public Animator anim;
    
    private void Start()
    {
        anim.SetInteger("sneezed", 0);
    }

    public void playerSneezed()
    {
        StartCoroutine(CallSneezed());
    }
    
    public IEnumerator CallSneezed(){
        //Currently blinks forever
        anim.SetInteger("sneezed", 1); 
        yield return new WaitForSeconds(.1f);
        anim.SetInteger("sneezed", 0);
    }
}
