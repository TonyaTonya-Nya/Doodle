using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organ : MonoBehaviour
{
    public GameObject[] condition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isPass = true;
        for (int i = 0; i < condition.Length; i++)
        {
            if (!condition[i].GetComponent<Object>().flag)
            {
                isPass = false;
                break;
            }
        }


        if (isPass)
        {
            Event();
        }
    }


    void Event()
    {
        gameObject.SetActive(false);
    }
}
