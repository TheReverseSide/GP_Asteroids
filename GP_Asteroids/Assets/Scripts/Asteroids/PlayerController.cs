using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] private float maxVelocity = 5.0f;
        [SerializeField] private float rotationSpeed = 250.0f;
        [SerializeField] private float friction = .95f;
        [SerializeField] private float acceleration = 5.0f;

        private Vector3 velocity;
        private Vector3 clampedVelocity;
        
        void Awake()
        {
            Reset();
        }

        public void Reset()
        {
            velocity = Vector3.zero;
            clampedVelocity = Vector3.zero;
        }

        void Update()
        {
            float inputX = Input.GetAxis("Horizontal"); //Isnt it stupid + expensive to initailze them every frame?
            float inputY = Mathf.Clamp(Input.GetAxis("Vertical"), 0, 1);
            
            //Get opposite of horiz. input and use it for rotation * rotSpeed
            transform.Rotate(new Vector3(0,0, -inputX), rotationSpeed * Time.deltaTime); //Second parameter is angle?

            velocity += Time.deltaTime * (inputY * (transform.up * acceleration));

            // Applies friction if no user input
            if (inputY == 0.0f)
            {
                velocity *= friction;
            }

            clampedVelocity = Vector3.ClampMagnitude(velocity, maxVelocity); //Clamping, just with a vector
            transform.Translate(clampedVelocity * Time.deltaTime, Space.World);
        }
    }
}

