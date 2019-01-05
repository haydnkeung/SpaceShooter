using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonButtons : MonoBehaviour
{

    public InputField joinServerInput, createServerInput;
    public MyHandler handler;

    public void createRoom() {
        handler.createRoom();

    }

    public void joinRoom() {
        Debug.Log("Joinging Room "+joinServerInput.text);
        handler.joinRoom(joinServerInput.text);
    }


    
}
