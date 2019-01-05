using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    //public PhotonView photonview;
    public Vector3 missilePos;
    int interpolationConstant = 8;


    public float speed = 10;

    private void Update()
    {


        if (transform.position.x < -100 || transform.position.x > 100 || transform.position.y < -100 || transform.position.y > 100) {
            Destroy(this.gameObject);
        }

        transform.position += transform.up*Time.deltaTime*speed;
    }

    private void smoothNetworkMovement()
    {
        transform.position = Vector3.Lerp(transform.position, missilePos, Time.deltaTime * interpolationConstant);
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
        }
        else
        {
            missilePos = (Vector3)stream.ReceiveNext();
        }
    }

}
