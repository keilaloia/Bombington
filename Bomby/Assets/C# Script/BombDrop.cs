using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class BombDrop : NetworkBehaviour {

    private Rigidbody RB;

    // Use this for initialization
    public GameObject Ring;

    void Awake()
    {
        RB = gameObject.GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update ()
    {
		
	}

    
     
    

    void  OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            GameObject Ringading = Instantiate(Ring);
            Ringading.transform.position = transform.position;
            NetworkServer.Spawn(Ringading);

            Destroy(RB.gameObject);
        }
    }
}
