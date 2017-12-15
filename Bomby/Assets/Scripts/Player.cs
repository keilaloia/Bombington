using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Collider))]


public class Player : NetworkBehaviour {

    public enum Team : int
    { P1, P2, P3, P4 }


    [SyncVar(hook = "SetMaterial")]
    public Team team;

    private Action NetUpdate = null;
    private Action Movement = null;


    new private Rigidbody rigidbody;
    new private Collider collider;
    new private Renderer renderer;


    public Material material1;
    public Material material2;
    public Material material3;
    public Material material4;

    private float inputTimer = 0;

    private float timeBetweenInputs = 0.075f;

    private void Awake()
    {
        GetComponents();

        AddToPlayerList();
    }

    private void Start ()
    {
        NetworkSetup();
	}

    public override void OnStartClient()
    {
        base.OnStartClient();

        SetMaterial(team);
    }

    private void Update()
    { NetUpdate(); }

    private void OnDestroy()
    { RemoveFromPlayerList(); }

    void GetComponents()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider  = GetComponent<Collider> ();
        renderer  = GetComponent<Renderer> ();
    }

    void NetworkSetup()
    {
        if (isLocalPlayer)
        {
            PlayerManager.localPlayer = this;

            SetLocalDelegetes();

            InitializeTeam();
        }

        else
        {
            SetRemoteDelegates();
        }
    }

    void SetLocalDelegates()
    {
        NetUpdate += LocalUpdate;

        //if(GameSettings.serverAuthoritative)
        //{
        //}
    }

    void SetRemoteDelegates()
    { 
        NetUpdate += RemoteUpdate;
    }

    void SetMaterial(Team t)
    {
        if (!isLocalPlayer)
        {
            switch (t)
            {
                case Team.P1:
                    renderer.material = 
            }
        }
    }


}
