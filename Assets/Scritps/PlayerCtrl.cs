using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


// ���(Inheritance)
public class PlayerCtrl : MonoBehaviour
{
    // Class Member Variables
    private Transform tr = null;
    private Rigidbody rb = null;

    [SerializeField, Range(10f, 50f)] private float moveSpeed = 10f;
    [SerializeField, Range(50f, 100f)] private float rotSpeed = 50f;


    private void Awake()
    {
        tr = GetComponent<Transform>(); // == tr = transform;
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //Vector3 newPos = transform.position;
            ////newPos.z += moveSpeed * Time.deltaTime;
            //newPos = transform.position + (tr.forward * moveSpeed * Time.deltaTime);
            //transform.position = newPos;
            rb.velocity = tr.forward * moveSpeed;

        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            rb.velocity = Vector3.zero;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 newPos = transform.position;
            newPos = transform.position + (-tr.forward * moveSpeed * Time.deltaTime);
            transform.position = newPos;

        }

        if (Input.GetKey(KeyCode.D))
        {
            tr.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            tr.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Vector3 newRot = tr.rotation.eulerAngles;
            newRot.y -= rotSpeed * Time.deltaTime;
            tr.rotation = Quaternion.Euler(newRot);
        }

        if (Input.GetKey(KeyCode.E))
        {
            // Function Overloading
            tr.Rotate(Vector3.up, rotSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            tr.localScale = Vector3.one * 2f;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            tr.localScale = Vector3.one;
        }
    }

    private void OnCollisionEnter(Collision _collision)
    {
        Debug.Log(_collision.gameObject.name);
    
    }
}


