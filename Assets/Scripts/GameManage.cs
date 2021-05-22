using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class GameManage : MonoBehaviour
{
    public GameObject playerPrefab;
    public Vector3 p1position;
    public Vector3 p2position;
    public GameObject player1;
    public GameObject player2;
    public GameObject botRoot;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos;
        if (PhotonNetwork.IsMasterClient)
        {
            pos = p1position;
        }
        else
        {
            pos = p2position;
        }
        GameObject player = PhotonNetwork.Instantiate(this.playerPrefab.name, pos, Quaternion.identity);
        if (PhotonNetwork.IsMasterClient)
        {
            player1 = player;
            player.name = "player1";
            foreach (Agent bot in botRoot.GetComponentsInChildren<Agent>())
            {
                bot.SetTarget(player.transform);
            } 

        }
        else
        {
            player2 = player;
            player.name = "player2";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
