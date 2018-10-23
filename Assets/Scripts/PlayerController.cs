using UnityEngine;
using UnityEngine.Networking;
public class PlayerController : NetworkBehaviour
{
    public GameObject playerCamera;
    public float xSensitivity;
    private float yaw = 0.0f;

    public float xSpeed = 3.0f;
    public float ySpeed = 3.0f;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public int bulletSpeed = 6;

    private void Start()
    {
        if (!isLocalPlayer)
        {
            playerCamera.SetActive(false);
            return;
        }
    }

    void Update()
    {
    
        if (!isLocalPlayer)
        {
            return;
        }
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * xSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * ySpeed;
        yaw += xSensitivity * Input.GetAxis("Mouse X");
        transform.Translate(x, 0, 0);
        transform.Translate(0, 0, z);
        transform.rotation = Quaternion.Euler(0, yaw, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }
    }

    public override void OnStartLocalPlayer()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    [Command]
    private void CmdFire()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        NetworkServer.Spawn(bullet);

        Destroy(bullet, 2.0f);
    }
}