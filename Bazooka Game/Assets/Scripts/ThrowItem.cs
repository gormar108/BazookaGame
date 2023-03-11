using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowItem : MonoBehaviour
{
    public bool kunaiActive = false;
    public bool shurikenActive = false;
    public GameObject Kunai;
    public GameObject Shuriken;
    void Start()
    {
        
    }

    void Update()
    {
        if(kunaiActive==true)
        {
            Kunai.active = true;
            shurikenActive = false;
        }
        else
        {
            Kunai.active = false;
        }
        if(shurikenActive==true)
        {
            Shuriken.active = true;
            kunaiActive = false;
        }
        else
        {
            Shuriken.active = false;
        }
    }
}
