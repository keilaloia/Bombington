using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBetty : MonoBehaviour {

   // public Collider BouncyCollider;
    public float Bounciness;
    public Material stun;
    public Material[] Mats;
    //public Material otherPlayer;
    private Renderer rend; 

    private float crapTime = 2;
    private float Timer;
    private bool changedmat;
    private Movement Movement;

    //public Player thisplayer;
	void Awake ()
    {
        Mats = new Material[2];
        
        //StunMat[0] = GetComponent<Renderer>().
       // BouncyCollider = gameObject.GetComponent<BoxCollider>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        //rend.sharedMaterial = StunMat[0];
        Timer = crapTime;
        Movement = GetComponent<Movement>();


    }
    void Start()
    {
        Mats[0] = GetComponent<Renderer>().material;
        Mats[1] = stun;
    }
    //void Start()
    //{
    //    StunMat[0] =

    //}

    // Update is called once per frame
    void Update ()
    {
        Timez();
	}

    void OnTriggerEnter(Collider collision)
    {

       

        
        

        if(collision.gameObject.tag == "Player")
        {
            if (collision.transform.position.y > transform.position.y)
            {
                Rigidbody otherRb = collision.GetComponent<Rigidbody>();
                Stun();
                otherRb.velocity = new Vector3(otherRb.velocity.x, Bounciness, otherRb.velocity.z);

            }

        }

        //if(otherBetty != null) { otherBetty.Stun(); }


    }


    public void Stun()
    {
        var render = GetComponent<Renderer>();
       
        render.material = Mats[1];

        //rend.sharedMaterial = StunMat[1];
        changedmat = true;
    }

    void Timez()
    {

        if(changedmat == true)
        {
            Timer -= Time.deltaTime;
            Movement.isStunned = true;
            if(Timer <= 0)
            {
                changedmat = false;
                Movement.isStunned = false;
                Timer = crapTime;
                rend.sharedMaterial = Mats[0];
                Debug.Log("mat to default");
                
            }
        }

    }
}
