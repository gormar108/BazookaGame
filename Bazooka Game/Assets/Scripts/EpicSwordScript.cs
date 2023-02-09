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
    public Camera fpsCam;

    public float range = 50f;
    public float damage = 3f;


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
            Swing();
            Defend();

        }
    }
    void Defend()
    {
        if(Input.GetKey(KeyCode.Mouse1)&&!Input.GetKey(KeyCode.Mouse0))
                animator.SetBool(isDefendHash, true);
            else
                animator.SetBool(isDefendHash, false);
    }

    void Swing()
    {
        
        if(Input.GetKey(KeyCode.Mouse0)&&!Input.GetKey(KeyCode.Mouse1))
        {
            animator.SetBool(isAttackHash, true);
            DoDamage();
        }
        else {animator.SetBool(isAttackHash, false);}
    }
    void DoDamage()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.Damaged(damage);
            }
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
