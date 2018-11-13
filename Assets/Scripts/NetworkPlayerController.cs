using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayerController : NetworkBehaviour, INetworkController {

    public GameObject playerCamera;

    [SyncVar(hook = "KeyboardHorizontalInput")] public float horizontalInputMovement = 0.0f;
    [SyncVar(hook = "KeyboardVerticalInput")] public float verticalInputMovement = 0.0f;
    [SyncVar(hook = "MouseHorizontalInput")] public float horizontalMouseMovement = 0.0f;
    [SyncVar(hook = "MouseVerticalInput")] public float verticalMouseMovement = 0.0f;

    // Use this for initialization
    void Start () {
        if (!isLocalPlayer)
        {
            playerCamera.SetActive(false);
            return;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (isLocalPlayer)
        {
            horizontalInputMovement = Input.GetAxis("Horizontal") * Time.deltaTime;
            verticalInputMovement = Input.GetAxis("Vertical") * Time.deltaTime;
            horizontalMouseMovement = Input.GetAxis("Mouse X") * Time.deltaTime;
            verticalMouseMovement = Input.GetAxis("Mouse Y") * Time.deltaTime;
        }
    }

    void KeyboardHorizontalInput(float _horizontalInputMovement)
    {
        horizontalInputMovement = _horizontalInputMovement;
    }

    void KeyboardVerticalInput(float _verticalInputMovement)
    {
        verticalInputMovement = _verticalInputMovement;
    }

    void MouseHorizontalInput(float _horizontalMouseMovement)
    {
        horizontalMouseMovement = _horizontalMouseMovement;
    }

    void MouseVerticalInput(float _verticalMouseMovement)
    {
        verticalMouseMovement = _verticalMouseMovement;
    }

    public float HorizontalInputMovement
    {
        get
        {
            return horizontalInputMovement;
        }
    }

    public float VerticalInputMovement
    {
        get
        {
            return verticalInputMovement;
        }
    }

    public float HorizontalMouseMovement
    {
        get
        {
            return horizontalMouseMovement;
        }
    }

    public float VerticalMouseMovement
    {
        get
        {
            return verticalMouseMovement;
        }
    }
}
