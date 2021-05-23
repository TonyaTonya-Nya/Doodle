using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class GamePlayer : MonoBehaviour
{
    public static int goal = 210;
    public static int score = 0;
    float speed = 3f;
    private PhotonView photonView;
    public VariableJoystick variableJoystick;

    public AudioClip[] audioArr;
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }

        if (Input.GetKey(KeyCode.RightArrow) || variableJoystick.Horizontal > 0)
        {
            gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || variableJoystick.Horizontal < 0)
        {
            gameObject.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow) || variableJoystick.Vertical > 0)
        {
            gameObject.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) || variableJoystick.Vertical < 0)
        {
            gameObject.transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }

       if(score== goal)
        {
            SceneManager.LoadScene(2);
        }
    }

  

    public void playCoinAudio()
    {
        gameObject.GetComponent<AudioSource>().clip = audioArr[0];
        gameObject.GetComponent<AudioSource>().Play();
    }
 

}
