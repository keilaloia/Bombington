using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBetty : MonoBehaviour {

    public Collider BouncyCollider;
    public Rigidbody PoorRb;
    public float Bounciness;
	// Use this for initialization


    public bool isOnTop
    {
        get
        {
            Vector3 startPoint = transform.position + (Vector3.up * BouncyCollider.bounds.extents.y * 100);
            Vector3 endPoint = startPoint + (Vector3.up * BouncyCollider.bounds.extents.y * 100f);
            Debug.DrawLine(startPoint, endPoint, Color.blue);
            return Physics.Raycast(startPoint, Vector3.up, BouncyCollider.bounds.extents.y * 100f);
        }
    }
	void Start ()
    {
        BouncyCollider = gameObject.GetComponent<Collider>();
       // PoorRb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        //ContactPoint contact = collision.contacts[0];
        //Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        //Vector3 pos = contact.point;
        if(isOnTop)
        PoorRb.velocity = new Vector3(PoorRb.velocity.x, Bounciness, PoorRb.velocity.z);
    }
}
