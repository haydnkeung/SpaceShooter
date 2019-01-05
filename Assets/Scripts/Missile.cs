using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{


    public float speed = 10;

    private void Update()
    {


        if (transform.position.x < -100 || transform.position.x > 100 || transform.position.y < -100 || transform.position.y > 100) {
            Destroy(this.gameObject);
        }

        transform.position += transform.up*Time.deltaTime*speed;
    }


}
