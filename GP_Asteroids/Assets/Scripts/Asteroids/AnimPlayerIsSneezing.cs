using System.Collections;
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
        anim.SetInteger("sneezed", 1);
        // Debug.Log("Called sneezed correctly");
        anim.SetInteger("sneezed", 0);
    }
}
