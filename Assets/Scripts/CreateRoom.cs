using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _roomName;
    public PlayerList playerList;
    public void onClickCreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
        {
            Debug.Log("is not connect");
            return;
        }

        RoomOptions roomSetting = new RoomOptions();
        roomSetting.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(_roomName.text, roomSetting, TypedLobby.Default);
    }
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        Debug.Log("CreatedRoom");
        playerList.GetCurrentPlayer();

    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        Debug.Log("CreatedRoomFailed");
        playerList.GetCurrentPlayer();

    }
    public void OnClickJoinRoom()
    {
        if (!PhotonNetwork.IsConnected)
        {
            Debug.Log("is not connect");
            return;
        }
        PhotonNetwork.JoinRoom(_roomName.text);

    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("JoinedRoom" + PhotonNetwork.CurrentRoom.Name);
        playerList.GetCurrentPlayer();

    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        Debug.Log(message);
        playerList.GetCurrentPlayer();


    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
