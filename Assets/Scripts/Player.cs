using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float rotationSensitivity = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float rotationThisFrame = rotationSensitivity * Time.deltaTime;
        //
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Rotate(Vector3.up * rotationThisFrame);
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Rotate(-Vector3.up * rotationThisFrame);
        //}
    }
}
