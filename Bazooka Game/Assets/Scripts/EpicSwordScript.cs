using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpicSwordScript : MonoBehaviour
{
    Animator animator;
    int isAttackHash;
    public bool isSheathed;


    void Start()
    {
        animator = GetComponent<Animator>();
        isAttackHash = Animator.StringToHash("isAttack");
    }

    
    void Update()
    {
        bool isAttack = animator.GetBool(isAttackHash);
        Attack();
        Sheathed();
    }

    void Attack()
    {
        if(!isSheathed)
        {
            if(Input.GetKey(KeyCode.Mouse0))
                animator.SetBool(isAttackHash, true);
            else
                animator.SetBool(isAttackHash, false);
        }
    }
    void Sheathed()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            isSheathed = !isSheathed;
        }
        if(isSheathed)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = true;
        }

    }
    
}
