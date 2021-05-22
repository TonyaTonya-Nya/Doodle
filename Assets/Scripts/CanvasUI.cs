using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class CanvasUI : MonoBehaviour
{
    public GameObject lobby;
    public GameObject startBtn;
    // Start is called before the first frame update
    void Start()
    {
        startBtn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!PhotonNetwork.IsConnectedAndReady)
        {
            lobby.SetActive(false);
            return;
        }
        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)
        {
            lobby.SetActive(true);
        }
        else
        {
            lobby.SetActive(false);
            if (PhotonNetwork.IsMasterClient)
            {
                startBtn.SetActive(true);
            }
        }
    }
    public void OnClickStartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.LoadLevel(1);
        }
    }
}
