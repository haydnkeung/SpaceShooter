
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonConnect : MonoBehaviour
{
    public string versionName = "1.0";

    public GameObject Sectionview1, Sectionview2, Sectionview3;


    public void connectToPhoton() {
        PhotonNetwork.ConnectUsingSettings(versionName);
        Debug.Log("Connecting to Photon");
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected to master");
    }

    private void OnJoinedLobby() {
        Sectionview1.SetActive(false);
        Sectionview2.SetActive(true);
        Debug.Log("Joined Lobby");
    }


    private void OnDisconnectedFromPhoton()
    {
        Sectionview1.SetActive(false);
        Sectionview2.SetActive(false);
        Sectionview3.SetActive(true);
        
    }


    private void OnFailedToConnectToPhoton()
    {
        
    }
}
