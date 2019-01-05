using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController2 : Photon.MonoBehaviour
{


    private Rigidbody2D rb;

    //public GameObject missile;

    public float forwardSpeed = 0.1f;
    public float rotationSpeed = 5;

    public float missileDelay = 1;
    public float timeLastFired = 0;


    public PhotonView photonview;
    Vector3 myPos;
    Quaternion myRotation;
    int interpolationConstant = 8;
    //public bool debug = false;
    private GameObject mainCam;
    public GameObject myCam;


    void Awake()
    {
        if (photonView.isMine)
        {
            mainCam = GameObject.Find("Main Camera");
            mainCam.SetActive(true);
            myCam.SetActive(false);
        }
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (photonview.isMine)
        {
            checkInput();
        }else{

            smoothNetworkMovement();
        }
           
    }

    private void rotate(float amount)
    {

        transform.Rotate(0, 0, amount);

    }


    private void checkInput()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");


        rotate(xInput * -rotationSpeed);
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            transform.position += transform.up * forwardSpeed;


        //Missile
        if (Input.GetKey(KeyCode.Space) && Time.time - timeLastFired > missileDelay)
        {
            PhotonNetwork.Instantiate("Missile", transform.position + transform.up, transform.rotation,0);
            timeLastFired = Time.time;
        }


    }

    private void smoothNetworkMovement()
    {
        transform.position = Vector3.Lerp(transform.position, myPos, Time.deltaTime * interpolationConstant);
        transform.rotation = Quaternion.Lerp(transform.rotation, myRotation, Time.deltaTime * interpolationConstant);
    }


    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            myPos = (Vector3)stream.ReceiveNext();
            myRotation = (Quaternion)stream.ReceiveNext();

            float lag = Mathf.Abs((float)(PhotonNetwork.time - info.timestamp));
            rb.position += rb.velocity * lag;
        }
    }
}
