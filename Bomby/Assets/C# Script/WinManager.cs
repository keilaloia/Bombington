using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class WinManager : NetworkBehaviour {

    //private BoxCollider BC;
    public List<Player> players;
    public Player[] findPlayers;

    //[SyncVar]
    string example;
    public Text winner;
    public GameObject menuState;
    private NetworkTimer matchtime;
    // Use  this for initialization

     
    void Awake()
    {
        matchtime = FindObjectOfType<NetworkTimer>();
        gameObject.SetActive(true);
    }
	void Start ()
    {
        players = new List<Player>();
        findPlayers = FindObjectsOfType<Player>();
        for(int i =0; i < findPlayers.Length; i++)
        {
            players.Add(findPlayers[i]);
            players[i].gameObject.name = "P" + (i+1).ToString();
        }
      
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            var playerThatFell = other.GetComponent<Player>();
            players.Remove(playerThatFell);
            Debug.Log("deleted");
            checkwinner();
        }

    }

	// Update is called once per frame
	void Update ()
    {
        winner.text = example;
        //matchtime
       // matchtime = gameObject.GetComponent<NetworkTimer>().matchTime;
        Debug.Log(matchtime.matchTime);
        // checkwinner();
    }

    void checkwinner()
    {
        if(matchtime.matchTime <= 0 || players.Count == 1)
        {
            
                winner.text = players[0].GetComponent<Player>().name.ToString() + " Wins!";
                menuState.SetActive(true);
                Debug.Log("win");
            
        }
        
    }
}
