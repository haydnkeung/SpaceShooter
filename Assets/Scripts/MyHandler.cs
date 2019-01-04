using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyHandler : MonoBehaviour
{


    public PhotonButtons photonButton;
    public GameObject Player;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
        DontDestroyOnLoad(this.transform);
        
    }


    public void createRoom() {
        RoomOptions options = new RoomOptions { MaxPlayers = 3 };


        PhotonNetwork.CreateRoom(photonButton.joinServerInput.text, options, TypedLobby.Default);
    }

    public void changeScene(string level) {
        PhotonNetwork.LoadLevel(level);
        Debug.Log("Entered Scene " + level);
    }
    public  void joinOrCreateRoom() {
        RoomOptions options = new RoomOptions { MaxPlayers = 3 };

        PhotonNetwork.JoinRoom(photonButton.joinServerInput.text);
        //PhotonNetwork.JoinOrCreateRoom(photonButton.joinServerInput.text, options, TypedLobby.Default);

    }

    private void OnJoinedRoom()
    {
        /*if (photonButton.joinServerInput.text==("game"))
        {
            Debug.Log("true");
        }
        else
        {
            Debug.Log("false");
        }*/
        Debug.Log("Joined room " + photonButton.joinServerInput.text);
        changeScene("Game");

    }

    private void OnSceneFinishedLoading(Scene scene,LoadSceneMode mode) {
        if (scene.name.Equals("Game")) {//==?
            spawnPlayer();
        }
    }

    private void spawnPlayer() {

        PhotonNetwork.Instantiate(Player.name, Player.transform.position, Player.transform.rotation, 0);
    }
}
