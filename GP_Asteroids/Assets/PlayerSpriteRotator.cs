using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteRotator : MonoBehaviour
{
    Vector3 mousePosition = new Vector3();
    float angle = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 relative = transform.InverseTransformPoint(mousePosition);
        angle = Mathf.Atan2(relative.x, relative.y)*Mathf.Rad2Deg;
        transform.Rotate(0,0, -angle);
    }
}
