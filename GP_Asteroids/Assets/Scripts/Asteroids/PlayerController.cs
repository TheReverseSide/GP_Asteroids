using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] private float maxVelocity = 5.0f;
        // [SerializeField] private float rotationSpeed = 250.0f;
        [SerializeField] private float friction = .95f;
        // [SerializeField] private float acceleration = 5.0f;
        [SerializeField, Range(0f, 100f)] float maxSpeed = 7f;
        [SerializeField, Range(0f, 100f)] float maxAcceleration = 10f;

        private Vector3 velocity;
        private Vector3 clampedVelocity;
        
        private Transform playerBodyRot;
        
        void Awake()
        {
            Reset();
        }

        public void Reset()
        {
            playerBodyRot = transform.Find("PlayerBody").gameObject.transform;
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
            if (inputY == 0.0f && inputX == 0.0f)
            {
                // Debug.Log("Applying friction");
                velocity *= friction;
            }

            // Rotates player according to velocity
            if (velocity.x == 0.0f && velocity.y > 0.0f)
            {
                // Debug.Log("Point up");
                playerBodyRot.rotation = Quaternion.Euler(new Vector3(0,0,0));
            }else if (velocity.x < 0.0f && velocity.y > 0.0f)
            {
                // Debug.Log("Point upper left");
                playerBodyRot.rotation = Quaternion.Euler(new Vector3(0,0,45));
            }else if (velocity.x < 0.0f && velocity.y == 0.0f)
            {
                // Debug.Log("Point left");
                playerBodyRot.rotation = Quaternion.Euler(new Vector3(0,0,90));
            }else if (velocity.x < 0.0f && velocity.y < 0.0f)
            {
                // Debug.Log("Point lower left");
                playerBodyRot.rotation = Quaternion.Euler(new Vector3(0,0,135));
            }else if (velocity.x == 0.0f && velocity.y < 0.0f)
            {
                // Debug.Log("Point down");
                playerBodyRot.rotation = Quaternion.Euler(new Vector3(0,0,180));
            }else if (velocity.x > 0.0f && velocity.y < 0.0f)
            {
                // Debug.Log("Point lower right");
                playerBodyRot.rotation = Quaternion.Euler(new Vector3(0,0,225));
            }else if (velocity.x > 0.0f && velocity.y == 0.0f)
            {
                // Debug.Log("Point right");
                playerBodyRot.rotation = Quaternion.Euler(new Vector3(0,0,270));
            }else if (velocity.x > 0.0f && velocity.y > 0.0f)
            {
                // Debug.Log("Point upper right");
                playerBodyRot.rotation = Quaternion.Euler(new Vector3(0,0,315));
            }

            Vector3 displacement = velocity * Time.deltaTime;
            transform.localPosition += displacement;
        }
    }
}
