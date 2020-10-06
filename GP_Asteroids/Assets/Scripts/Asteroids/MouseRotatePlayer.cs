using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MouseRotatePlayer : MonoBehaviour
{
     public void Update()
     {
         Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
         Quaternion rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
         transform.rotation = rotation;
     }
}
