using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonButtons : MonoBehaviour
{

    public InputField joinServerInput, createServerInput;
    //public MenuScript menuScript;
    public MyHandler handler;

    public void createRoom() {
        handler.createRoom();

    }

    public void joinRoom() {
        //PhotonNetwork.JoinRoom(joinServerInput.text);
        handler.joinOrCreateRoom();
    }


    
}
