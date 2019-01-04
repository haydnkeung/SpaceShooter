using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject connectedMenu;


    public void disableMenuUI() {
        PhotonNetwork.LoadLevel("Game");

    }
}
