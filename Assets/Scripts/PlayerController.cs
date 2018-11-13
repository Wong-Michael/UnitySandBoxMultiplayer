using UnityEngine;
using UnityEngine.Networking;
public class PlayerController : MonoBehaviour
{
    public NetworkPlayerController networkPlayerController;
    private INetworkController networkController;
    
    private float yaw = 0.0f;

    public float xSpeed = 9.0f;
    public float zSpeed = 9.0f;
    public float xSensitivity;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public int bulletSpeed = 6;

    private void Start()
    {
        if (networkPlayerController is INetworkController)
        {
            networkController = networkPlayerController;
            Debug.Log("NetworkPlayerController does implement INetworkController");
        } else
        {
            Debug.Log("NetworkPlayerController does not implement INetworkController");
        }
    }

    void Update()
    {
        if (networkController == null)
        {
            return;
        }
        var xInput = networkController.HorizontalInputMovement * xSpeed;
        var zInput = networkController.VerticalInputMovement * zSpeed;
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * xSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * zSpeed;
        yaw += xSensitivity * Input.GetAxis("Mouse X");
        transform.Translate(xInput, 0, 0);
        transform.Translate(0, 0, zInput);
        transform.rotation = Quaternion.Euler(0, yaw, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("x = " + xInput.ToString());
            Debug.Log("z = " + zInput.ToString());
            CmdFire();
        }
    }

    //public override void OnStartLocalPlayer()
    //{
      //  if (!isLocalPlayer)
        //{
        //    return;
        //}

        //GetComponent<MeshRenderer>().material.color = Color.blue;
    //}
    private void CmdFire()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        NetworkServer.Spawn(bullet);

        Destroy(bullet, 2.0f);
    }
}