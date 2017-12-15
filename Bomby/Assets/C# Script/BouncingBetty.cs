using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBetty : MonoBehaviour {

    public Collider BouncyCollider;
    public float Bounciness;

    public Material[] StunMat;
    private Renderer rend; 

    private float crapTime = 5;
    private float Timer;
    private bool changedmat;
	void Awake ()
    {
        BouncyCollider = gameObject.GetComponent<Collider>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = StunMat[0];

        Timer = crapTime;

	}
	
	// Update is called once per frame
	void Update ()
    {
        Timez();
	}

    void OnTriggerEnter(Collider collision)
    {

        Rigidbody otherRb = collision.GetComponent<Rigidbody>();

        if (otherRb == null) { return; }

        otherRb.velocity = new Vector3(otherRb.velocity.x, Bounciness, otherRb.velocity.z);
        Stun();

    }

    void Stun()
    {
        rend.sharedMaterial = StunMat[1];
        changedmat = true;
    }

    void Timez()
    {

        if(changedmat == true)
        {
            Timer -= Time.deltaTime;
            if(Timer <= 0)
            {
                changedmat = false;
                Timer = crapTime;
                rend.sharedMaterial = StunMat[0];
                Debug.Log("mat to default");
                
            }
        }

    }
}
