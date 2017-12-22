using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Radius_Drop : NetworkBehaviour {

    public float BombRadius;
    public GameObject BombPrefab;
    private float crapTime = .75f;
    private float Timer;
    [SyncVar]
    private Vector3 CrapRange;


    // Update is called once per frame
    void Awake()
    {
        
        Timer = crapTime;
    }
    void Update ()
    {
        CrapSpawner();
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, BombRadius);
    }

    void SpawnBomb()
    {
        CrapRange = new Vector3(Random.Range(-6f, 6f), 0, Random.Range(-6f, 6f));
        GameObject spawnBaby = Instantiate(BombPrefab);
        Rigidbody rb = spawnBaby.GetComponent<Rigidbody>();
        spawnBaby.transform.position = transform.position + CrapRange;
        NetworkServer.Spawn(spawnBaby);



        //Rigidbody clone;
        //clone = Instantiate(BombPrefab, transform.position * CrapRange, transform.rotation).GetComponent<Rigidbody>();
        //clone.velocity = transform.TransformDirection(Vector3.down * 10);   
    }
    
    void CrapSpawner()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            SpawnBomb();
            Timer = crapTime;
        }
    }

   
}
