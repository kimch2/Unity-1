using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using wxb;

public class Player : MonoBehaviour
{

    public Text uitext;

 
    public void ActionW()
    {
        UnityEngine.Debug.Log("W");
    }

    public void ActionS()
    {
        UnityEngine.Debug.Log("S");
    }

    public void ActionA()
    {
        UnityEngine.Debug.Log("A");
    }

    public void ActionD()
    {
        UnityEngine.Debug.Log("D");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ActionW();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            ActionS();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            ActionA();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            ActionD();
        }
    }
}
