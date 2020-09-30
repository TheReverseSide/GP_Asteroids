using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class DestroyWeaponOffscreen : TransformOffscreen {

        public event Action EventDestroy;
        
        public override void Update() {
            base.Update();

            // if IsOffscreen, dispatch or manually destroy.
            if( isOffscreen ) {
                if( EventDestroy != null ) {
                    EventDestroy();
                } else {
                    Destroy( gameObject );
                }
            }
        }
    }
}

