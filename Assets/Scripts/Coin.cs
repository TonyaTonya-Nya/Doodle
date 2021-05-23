﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    static int totalCoinCount=210;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GamePlayer.score++;
            collision.gameObject.GetComponent<GamePlayer>().playCoinAudio();
            totalCoinCount--;
            Debug.Log(totalCoinCount);
            if (totalCoinCount == 0)
            {
                Debug.Log("Win");
            }
            gameObject.SetActive(false);
            
        }
    }
}
