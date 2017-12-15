using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDrop : MonoBehaviour {

    private Rigidbody RB;

    // Use this for initialization
    public GameObject Ring;

    void Awake()
    {
        RB = gameObject.GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update () {
		
	}


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            Destroy(RB.gameObject);
            GameObject Ringading = Instantiate(Ring);
            Ringading.transform.position = transform.position;
        }
    }
}
