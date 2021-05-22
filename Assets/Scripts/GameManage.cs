using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class GameManage : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        int posX = Random.Range(-5, 5);
        GameObject player =  PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(posX, 0, 0), Quaternion.identity);
        //player.GetComponent<Tank>().bulletPrefab = bulletPrefab;
        player.name = PhotonNetwork.LocalPlayer.NickName;
        //int col = Random.Range(0, 255);
        //player.GetComponent<SpriteRenderer>().color = new Color(col / 255.0f, col / 255.0f, col / 255.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
