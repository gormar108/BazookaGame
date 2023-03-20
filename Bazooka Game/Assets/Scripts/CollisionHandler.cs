using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    public bool touchingWall;

    void Start()
    {

    }

    void Update()
    {
        if (touchingWall)
        {
            Debug.Log("Touching a wall");
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Tags>() != null)
        {
            foreach(string tagStr in other.gameObject.GetComponent<Tags>().objTags)
            {
                switch (tagStr)
                {
                    case "wall":
                        touchingWall = true;
                        break;
                }
            }
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.GetComponent<Tags>() != null)
        {
            foreach(string tagStr in other.gameObject.GetComponent<Tags>().objTags)
            {
                switch (tagStr)
                {
                    case "wall":
                        touchingWall = false;
                        break;
                }
            }
        }
    }

}
