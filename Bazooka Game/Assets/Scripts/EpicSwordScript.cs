using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpicSwordScript : MonoBehaviour
{
    Animator animator;
    int isAttackHash;
    int isDefendHash;
    int isSheathedHash;
    public bool isSheathed = true;
    public Camera mainCam;
    public GameObject hotbarScript;

    public float attackCooldown = 3f;
    public float range = 50f;
    public float damage = 3f;

    float lastSwing;


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
        
        if(Input.GetKeyDown(KeyCode.Mouse0)&&!Input.GetKey(KeyCode.Mouse1))
        {
            animator.SetBool(isAttackHash, true);
            DoDamage();
        }
        else {animator.SetBool(isAttackHash, false);}
    }

    void DoDamage()
    {
        if(Time.time-lastSwing<attackCooldown){return;}
        lastSwing = Time.time;
        RaycastHit hit;
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                StartCoroutine(Delay());
            }
            IEnumerator Delay()
            {
                yield return new WaitForSeconds(0.3f);
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
