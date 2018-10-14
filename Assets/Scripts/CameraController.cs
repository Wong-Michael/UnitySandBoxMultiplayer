using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraController : MonoBehaviour {

    public float xSensitivity = 1.0f;
    public float ySensitivity = 1.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    GameObject objectFollowing = null;
    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        if (objectFollowing != null)
        {
            yaw += xSensitivity * Input.GetAxis("Mouse X");
            pitch -= ySensitivity * Input.GetAxis("Mouse Y");
            transform.position = (new Vector3(pitch, 0.0f, yaw)); 
        }
	}

    public void setFollowGameObject(GameObject objectToFollow)
    {
        objectFollowing = objectToFollow;
    }
}
