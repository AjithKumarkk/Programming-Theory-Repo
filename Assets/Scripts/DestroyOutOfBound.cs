using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private float offScreenBound = 15f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -offScreenBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.y > offScreenBound)
        {
            Destroy(gameObject);
        }
    }
}
