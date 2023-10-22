using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float horizontalInput;
    [SerializeField] float speed = 10f;
    private float zBoundRange = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > zBoundRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundRange);
        }
        if (transform.position.z < -zBoundRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBoundRange);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
       
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
