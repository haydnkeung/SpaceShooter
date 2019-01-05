using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : Photon.MonoBehaviour
{

    public PhotonView photonview;
    public float speed;
    public float normalForce;
    Vector3 myPos;
    int interpolationConstant = 8;
    public bool debug = false;
    private GameObject mainCam;
    public GameObject myCam;


    private void Awake()
    {
        if (!debug && photonView.isMine) {
            mainCam = GameObject.Find("Main Camera");
            mainCam.SetActive(false);
            myCam.SetActive(true);
        }
    }

    private void Update()
    {
        if (!debug)
        {
            if (photonview.isMine)
            {
                checkInput();
            }
            else
            {
                smoothNetworkMovement();
            }
        }
        else {
            checkInput();
        }
    }

    private void smoothNetworkMovement()
    {
        transform.position = Vector3.Lerp(transform.position, myPos, Time.deltaTime * interpolationConstant);
    }

    private void checkInput()
    {
        float x = Input.GetAxis("Horizontal")*speed*Time.deltaTime;
        float y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector3 pos = new Vector3(x, y,0);
        transform.position += pos;

    }


    private void OnPhotonSerializeView(PhotonStream stream,PhotonMessageInfo info) {

        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
        }
        else {
            myPos = (Vector3)stream.ReceiveNext();
        }
    }

}