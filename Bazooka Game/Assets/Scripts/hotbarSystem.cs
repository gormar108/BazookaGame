using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotbarSystem : MonoBehaviour
{
    public GameObject slot1Script;
    public GameObject slot2Script;
    public GameObject slot3Script;
    public GameObject slot4Script;

    public bool slot1NotEquipped;
    public bool slot2NotEquipped;
    public bool slot3NotEquipped;
    public bool slot4NotEquipped;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sheathedCheck();
    }

    void sheathedCheck()
    {
        if(slot1Script.GetComponent<EpicSwordScript>().isSheathed == false)
        {
            slot1NotEquipped = false;
            slot2NotEquipped = true;
            slot3NotEquipped = true;
            slot4NotEquipped = true;
        }
        else{slot1NotEquipped=true;}
        if(slot2Script.GetComponent<ThrowingTutorial>().isNotEquipped == false)
        {
            slot1NotEquipped = true;
            slot2NotEquipped = false;
            slot3NotEquipped = true;
            slot4NotEquipped = true;
        }
        else{slot2NotEquipped=true;}

    }
}
