
using UnityEngine;
using UnityEngine.Networking;

public class HeadPivotCameraController : MonoBehaviour {
    public float ySensitivity;
    public float pitchMinClamp;
    public float pitchMaxClamp;

    private float pitch = 0.0f;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        
        pitch = Mathf.Clamp(pitch, pitchMinClamp, pitchMaxClamp);
        transform.localRotation = Quaternion.Euler(pitch, 0, 0);
    }
}
