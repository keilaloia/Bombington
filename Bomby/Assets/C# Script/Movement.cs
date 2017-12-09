using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   
    public float speed;
    private Rigidbody RB;
    private float horz;
    private float vert;
    private Vector3 Dir;
    private Collider Bounds;
    private CameraSingleTon cams;

    public bool isGrounded
    {
        get
        {
            Vector3 startPoint = transform.position - (Vector3.up * Bounds.bounds.extents.y * .9f);
            Vector3 endPoint = startPoint - (Vector3.up * Bounds.bounds.extents.y * .2f);
            Debug.DrawLine(startPoint, endPoint, Color.red);
            return Physics.Raycast(startPoint, -Vector3.up, Bounds.bounds.extents.y * .2f);
        }
    }

    // Use this for initialization
    void Start ()
    {
        RB = gameObject.GetComponent<Rigidbody>();
        Bounds = gameObject.GetComponent<Collider>();
        cams = CameraSingleTon.instance.GetComponent<CameraSingleTon>();
        
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Move();
        JumpyJump();
	}

    void Move()
    {
        if(Input.GetKey(KeyCode.D))
        {
            horz += 1.5f;
           
        }
        ///////////////////////////////
        if (Input.GetKey(KeyCode.A))
        {
            horz -= 1.5f;
        }
        ///////////////////////////////
        if (Input.GetKey(KeyCode.W))
        {
            vert += 1.5f;
        }
        /////////////////////////////////////
        if (Input.GetKey(KeyCode.S))
        {
            vert -= 1.5f;
        }

        if(Mathf.Abs(horz) > 10)
        {
            horz = 10;
        }
        if (Mathf.Abs(vert) > 10)
        {
            vert = 10;
        }

        Dir = new Vector3(horz * speed * Time.deltaTime, RB.velocity.y, vert * speed * Time.deltaTime);

        RB.velocity = Dir;

        
        //Debug.Log(horz.ToString() + " " + vert.ToString());

        vert *= .8f;
        horz *= .8f;
    }
    bool didPound = false;
    void JumpyJump()
    {

        if(Input.GetKey(KeyCode.Space)&& isGrounded)
        {
            RB.velocity = new Vector3(RB.velocity.x, 6.5f, RB.velocity.z);
            Debug.Log("JumpPressed");
        }

       if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Space))
        {
            RB.velocity = new Vector3(RB.velocity.x, -10f, RB.velocity.z);
            didPound = true;
            Debug.Log("called");
            
        }
        if (isGrounded && didPound)
        {
            cams.doShake = true;
            didPound = false;
        }
    }

    //public bool IsGrounded()
    //{
    //    Vector3 startPoint = transform.position - (Vector3.up * Bounds.bounds.extents.y * .9f);
    //    Vector3 endPoint = startPoint - (Vector3.up * Bounds.bounds.extents.y * .2f);
    //    Debug.DrawLine(startPoint, endPoint, Color.red);
    //    return Physics.Raycast(startPoint, -Vector3.up, Bounds.bounds.extents.y * .2f);
    //}

}
