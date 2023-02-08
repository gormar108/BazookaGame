using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpicSwordScript : MonoBehaviour
{
    Animator animator;
    int isAttackHash;
    int isDefendHash;
    int isSheathedHash;
    public bool isSheathed = false;


    void Start()
    {
        animator = GetComponent<Animator>();
        isAttackHash = Animator.StringToHash("isAttack");
        isDefendHash = Animator.StringToHash("isDefend");
        isSheathedHash = Animator.StringToHash("isSheathed");

    }

    
    void Update()
    {
        Attack();
        Sheathed();
    }

    void Attack()
    {
        if(!isSheathed)
        {
            if(Input.GetKey(KeyCode.Mouse0)&&!Input.GetKey(KeyCode.Mouse1))
                animator.SetBool(isAttackHash, true);
            else
                animator.SetBool(isAttackHash, false);
            if(Input.GetKey(KeyCode.Mouse1)&&!Input.GetKey(KeyCode.Mouse0))
                animator.SetBool(isDefendHash, true);
            else
                animator.SetBool(isDefendHash, false);
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
            animator.SetBool(isSheathedHash, true);
        }
        else
        {
            animator.SetBool(isSheathedHash, false);
        }

    }
    
}
