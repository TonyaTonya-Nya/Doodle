using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonConnecting : MonoBehaviourPunCallbacks
{
    public string version = "0.1";
    public void ConnectToPhoton()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.GameVersion = version;
        PhotonNetwork.SendRate = 20;
        PhotonNetwork.SerializationRate = 10;
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = "Test" + Random.Range(0, 999);
        ConnectToPhoton();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("connect to " + PhotonNetwork.CloudRegion + "server");
        PhotonNetwork.JoinLobby();
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        Debug.Log("Disconnect reason:" + cause.ToString());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
