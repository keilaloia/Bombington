using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Person
//{
//    public static Person President;
//    string name;

//    Person()
//    {
//        if (President == null)
//            President = this;
//    }
//}

public class DELETEME : MonoBehaviour {

    private static DELETEME _instance;
    public static DELETEME instance
    { get { return _instance; } }

    bool test;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
            Destroy(gameObject);

        GameSettings.ipAddress = "whatever";
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
