using UnityEngine;
using UnityEngine.Networking;
public class PlayerController : NetworkBehaviour
{
    public GameObject playerCamera;
    public float xSpeed = 3.0f;
    public float ySpeed = 3.0f;

    public float xSensitivity;
    private float yaw = 0.0f;
    void Update()
    {
    
        if (!isLocalPlayer)
        {
            playerCamera.SetActive(false);
            return;
        }
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * xSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * ySpeed;
        yaw += xSensitivity * Input.GetAxis("Mouse X");
        transform.Translate(x, 0, 0);
        transform.Translate(0, 0, z);
        transform.rotation = Quaternion.Euler(0, yaw, 0);
    }

    public override void OnStartLocalPlayer()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}