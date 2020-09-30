using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    
    public class WrapScreen : TransformOffscreen {

        public override void Update() {
            base.Update();

            // if IsOffscreen, convert viewport pos back to world pos and apply to transform.
            if( isOffscreen ) {
                transform.position = Camera.main.ViewportToWorldPoint( viewportPos );
            }
        }
    }
}

