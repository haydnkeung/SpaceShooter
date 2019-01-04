using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonButtons : MonoBehaviour
{

    public InputField joinServerInput, createServerInput;
    public MenuScript menuScript;

    public void createRoom() {
        RoomOptions options = new RoomOptions { MaxPlayers = 3 };
        
            PhotonNetwork.CreateRoom(joinServerInput.text, options, null);//Null?
       
        
    }

    public void joinRoom() {
        PhotonNetwork.JoinRoom(joinServerInput.text);
    }


    private void OnJoinedRoom() {
        menuScript.disableMenuUI();
        Debug.Log("Joined room " + joinServerInput.text);
    }


    private void OnCreateRoom() {
       
        Debug.Log("Created room " + createServerInput.text);
        //Debug.Log("Joined room " + joinServerInput.text);
    }

}
