using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elfeneri : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis ("Horizontal") > 0)
        {
            transform.localEulerAngles = new Vector3 (0, 0, 0);
        }
        if (Input.GetAxis ("Horizontal") < 0)
        {
            transform.localEulerAngles = new Vector3 (0, 0, 180);
        }
        if (Input.GetAxis ("Vertical") > 0) 
        {
            transform.localEulerAngles = new Vector3 (0, 0, 90);    
        }
        if (Input.GetAxis ("Vertical") < 0) 
        {
            transform.localEulerAngles = new Vector3 (0, 0, -90);    
        }
    }
}
