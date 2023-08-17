using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public float x;
    public float z;
    public float speed;
    void Update()
    {
        x = Input.GetAxis("Horizontal") * speed;
        z = Input.GetAxis("Vertical") * speed;
        transform.Translate(x, 0, z);
    }
    
}
