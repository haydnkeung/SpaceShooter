
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonConnect : MonoBehaviour
{

    public Version version;
    
    //By Deafult all are disabled except WelcomeScreen
    public GameObject WelcomeScreen, LobbyScreen, DisconnectedScreen,LoadingScreen;



    public void connectToPhoton() {
        PhotonNetwork.ConnectUsingSettings(version.versionNumber);
        WelcomeScreen.SetActive(false);
        LoadingScreen.SetActive(true);
        Debug.Log("Connecting to Photon");
    }


    private void OnConnectedToMaster()
    {
        Debug.Log("Connected to master");
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        
    }

    private void OnJoinedLobby() {
        WelcomeScreen.SetActive(false);
        LoadingScreen.SetActive(false);
        LobbyScreen.SetActive(true);
        Debug.Log("Joined Lobby");
    }


    private void OnDisconnectedFromPhoton()
    {
        WelcomeScreen.SetActive(false);
        LobbyScreen.SetActive(false);
        DisconnectedScreen.SetActive(true);
        
    }


    private void OnFailedToConnectToPhoton()
    {
        
    }
}
