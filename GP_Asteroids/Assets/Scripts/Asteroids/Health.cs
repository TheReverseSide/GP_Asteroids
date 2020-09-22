using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Health : MonoBehaviour {

        public event Action<int> EventHeathChange;

        [SerializeField]
        private int health = 1;
        public int Value {
            get { return health; }
            private set { health = value; }
        }
        
        public void IncreaseHealth( int value ) {
            Value += value;
            DispatchChangedEvent();
        }
        
        public void ReduceHealth( int value ) {
            Value -= value;
            DispatchChangedEvent();
        }
        
        private void DispatchChangedEvent() {
            if( EventHeathChange != null ) {
                EventHeathChange( Value );
            }
        }
    }
    
}

