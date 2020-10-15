using System;
using System.Collections;
using System.Collections.Generic;
using Asteroids;
using UnityEngine;

public class AnimPlayerIsMoving : MonoBehaviour
{
    //integer to be set to 1 as long as someone is pushing W, A, S or D.
    //Needs to be attached to the GameObject: GameHolder/Player/PlayerBody

    public Animator anim;
    public GameObject playerHead;
    public AudioManager audioManager;
    [SerializeField] private PlayerController playerController;

    [SerializeField] private AudioClip runningClip; //steps_loop_longNEW2
    [SerializeField] private AudioClip slidingClip; //Skwik1_short

    
    void Update()
    {
        CalculateHeadBodyAngle();

        if (Input.GetAxis("Horizontal") != 0.0f || Input.GetAxis("Vertical") != 0.0f)
        {
            anim.SetInteger("moving", 1);
            audioManager.PlaySFX(runningClip, .5f);
            // Debug.Log("moving");
        }
        else if(playerController.velocity.x != 0.0f || playerController.velocity.y != 0.0f) // If player is not adding to velocity but still moving
        {
            anim.SetInteger("moving", 0);
            audioManager.PlaySFX(slidingClip);
            // Debug.Log("slidign");
        }
        else
        {
            anim.SetInteger("moving", 0);
            audioManager.StopSound();
        }
    }

    void CalculateHeadBodyAngle()
    {
        Vector3 dir = playerHead.transform.localPosition - transform.localPosition;
        dir = playerHead.transform.InverseTransformDirection(dir);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (angle >= 110) // Super far to right
        {
            // print("Turned far to right");
            anim.SetInteger("turnedFarRight", 1);
        }
        else if (angle <= -110) // Super far to left
        {
            // print("Turned far to left");
            anim.SetInteger("turnedFarLeft", 1); 
        }
        else
        {
            anim.SetInteger("turnedFarLeft", 0); 
            anim.SetInteger("turnedFarRight", 0);
        }
    }
}
