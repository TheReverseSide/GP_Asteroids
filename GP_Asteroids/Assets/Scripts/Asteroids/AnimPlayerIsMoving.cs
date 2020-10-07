﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayerIsMoving : MonoBehaviour
{
    //integer to be set to 1 as long as someone is pushing W, A, S or D.
    //Needs to be attached to the GameObject: GameHolder/Player/PlayerBody
    
    public Animator anim; 
    //TODO - Fix anyKey
    //TODO - Add sneezing integer

    private void Start()
    {
        anim.SetInteger("sneezed", 0);
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0.0f || Input.GetAxis("Vertical") != 0.0f)
        {
            anim.SetInteger("moving", 1);
            // Debug.Log(this + "Player moving");
        }
        else
        {
            anim.SetInteger("moving", 0);
            // Debug.Log(this + "Player still");
        }

    }

    public void playerSneezed()
    {
        anim.SetInteger("sneezed", 1);
        Debug.Log("Called sneezed correctly");
    }
}
