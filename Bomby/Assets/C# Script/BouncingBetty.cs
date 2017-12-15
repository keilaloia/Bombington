using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBetty : MonoBehaviour {

    public Collider BouncyCollider;
    public float Bounciness;

	void Start ()
    {
        BouncyCollider = gameObject.GetComponent<Collider>();
      
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider collision)
    {
        Rigidbody otherRb = collision.GetComponent<Rigidbody>();

        if (otherRb == null) { return; }
            otherRb.velocity = new Vector3(otherRb.velocity.x, Bounciness, otherRb.velocity.z);
            Debug.Log("Dead");
      
      
    }
}
