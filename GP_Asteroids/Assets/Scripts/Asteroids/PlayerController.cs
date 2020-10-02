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
        [SerializeField, Range(0f, 100f)] float maxSpeed = 7f;
        [SerializeField, Range(0f, 100f)] float maxAcceleration = 10f;

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
            float inputY = Mathf.Clamp(Input.GetAxis("Vertical"), -1, 1);

            Vector3 desiredVelocity = new Vector3(inputX, inputY,0f) * maxSpeed;
            float maxSpeedChange = maxAcceleration * Time.deltaTime;

            velocity.x =
                Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
            velocity.y =
                Mathf.MoveTowards(velocity.y, desiredVelocity.y, maxSpeedChange);
            
            // Applies friction if no user input
            if (inputY == 0.0f)
            {
                velocity *= friction;
            }
            
            Vector3 displacement = velocity * Time.deltaTime;
            transform.localPosition += displacement;
        }
    }
}

