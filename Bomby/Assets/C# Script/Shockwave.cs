using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour {

   
	void Awake()
    {
        

    }
	void Update ()
    {
        shockwave();
	}

   

    void shockwave()
    {

       
        transform.localScale += new Vector3(8f * Time.deltaTime, 0, 8f * Time.deltaTime);
        Destroy(gameObject.transform.parent.gameObject,3);

    }

    void OnCollisionEnter(Collision collision)
    {
        Rigidbody PlayerRB = collision.collider.GetComponent<Rigidbody>();

        Vector3 Dir = PlayerRB.position - transform.parent.position;
        //Debug.Log(Dir);
        PlayerRB.position += (Dir.normalized * 2) * Time.deltaTime * 2;
 


    }
}
