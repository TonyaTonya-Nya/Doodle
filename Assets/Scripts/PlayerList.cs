using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerList : MonoBehaviourPunCallbacks
{
    public Text list;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        GetCurrentPlayer();
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        GetCurrentPlayer();
    }
    public void GetCurrentPlayer()
    {
        list.text = "";
        if (!PhotonNetwork.IsConnected)
            return;
        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)
            return;
        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            list.text += "\n" + player.Value.NickName;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
