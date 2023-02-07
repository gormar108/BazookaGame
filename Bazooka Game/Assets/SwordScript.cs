using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    Animator animator;
    int isAttackHash;

    void Start()
    {
        animator = GetComponent<Animator>();
        isAttackHash = Animator.StringToHash("isAttack");
    }

    
    void Update()
    {
        bool isAttack = animator.GetBool(isAttackHash);
        if(Input.GetMouseButtonDown(0))
            animator.SetBool(isAttackHash, true);
        else
            animator.SetBool(isAttackHash, false);
    }
    
}
