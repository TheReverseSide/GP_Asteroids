using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    
    public class PlayerShield : MonoBehaviour
    {

        [SerializeField] private GameObject shield;
        
        [SerializeField] private float duration = 1.0f;

        [SerializeField] private bool isInvincible;

        // public bool IsInvincible //NOTICE: This is an accessor,  how it is Caps here, but lowercase below
        // {
        //     get {return isInvincible;}
        //     private set {isInvincible = value;}
        // }// public bool isInvincible {get; set;} is a valid alternative,
        //  // but will not work with a previously defined variable
        //  // (such as what we currently have)
        //  // So, we use longhand cause isInvincible is previously defined
        //  // (cause we want it to be serialized as well)
        //
        //  public void Show()
        //  {
        //      shield.SetActive(true);
        //      SetInvincible(true);
        //      
        //      CancelInvoke("DisableGameObject");
        //      Invoke("DisableShield", duration); //Why disable shield on its queue to activat?
        //  }
        //
        //  void SetInvincible(bool b)
        //  {
        //      isInvincible = b;
        //  }
        //
        //  void DisableGameObject()
        //  {
        //      shield.SetActive(false);
        //  }
        //
        //  void DisableShield() //I dont get this disable loop going on
        //  {
        //      SetInvincible(false);
        //      Invoke("DisableGameObject", 1.0f);
        //  }
    }
}

