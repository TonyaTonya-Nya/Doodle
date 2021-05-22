using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class RoomList : MonoBehaviourPunCallbacks
{
    public Text roomName;
    public RoomInfo roomInf;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetRoomInfo(RoomInfo info)
    {
        roomInf = info;
        roomName.text = info.Name;
    }
    public void OnClickJoinRoom()
    {
        PhotonNetwork.JoinRoom(roomName.text);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
