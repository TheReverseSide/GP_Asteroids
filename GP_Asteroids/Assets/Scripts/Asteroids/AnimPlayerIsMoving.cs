using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayerIsMoving : MonoBehaviour
{
    //integer to be set to 1 as long as someone is pushing W, A, S or D.
    //Needs to be attached to the GameObject: GameHolder/Player/PlayerBody

    public Animator anim; 
    
    void Update()
    {
        if (Input.anyKey)
        {
            anim.SetInteger("moving", 1);
        }
        else
        {
            anim.SetInteger("moving", 0);
        }

    }
}
