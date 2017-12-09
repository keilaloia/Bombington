using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSingleTon : MonoBehaviour {

    [HideInInspector]
    new public Camera camera;
    //voodoo magic instance for one object better way to find objects
	private static CameraSingleTon _instance;
    public static CameraSingleTon instance
    {
        get
        {
            return _instance;
        }
    }
    public float shakeDuration;
    public float shakeDecrease;
    public float shakeForce;

    public bool doShake;

    Vector3 originalPos;
    //safety check
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
            Destroy(gameObject);
    }
    void Start()
    {
        doShake = false;
        camera = GetComponent<Camera>();
        originalPos = camera.transform.localPosition;
    }

    public void cameraShake()
    {
        if(doShake)
        {
            if (shakeDuration > 0)
            {
                Vector3 rando = Random.insideUnitCircle * shakeForce;
                camera.transform.localPosition = Vector3.Lerp(camera.transform.localPosition, camera.transform.localPosition + rando, Time.deltaTime * shakeDecrease);
                shakeDuration -= Time.deltaTime * shakeDecrease;
            }
            else
            {
                doShake = false;

                shakeDuration = 1;
                camera.transform.localPosition = originalPos;
            }
        }
        
    }
    void Update()
    {
        cameraShake();
    }
    
    // Look into making a random direction vector property
    // Look into making a co-routine for shaking camera for a set amount of seconds
}
