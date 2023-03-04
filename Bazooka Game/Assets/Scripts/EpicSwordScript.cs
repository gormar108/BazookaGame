using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpicSwordScript : MonoBehaviour
{
    Animator animator;
    int isAttackHash;
    int isAttackComboHash;
    int isDefendHash;
    int isSheathedHash;
    public bool isSheathed = true;
    public Camera mainCam;
    public GameObject slot2Script;

    public float attackCooldown = 3f;
    public float range = 50f;
    public float damage = 3f;

    float lastSwing;
    float lastClick;


    void Start()
    {
        animator = GetComponent<Animator>();
        isAttackHash = Animator.StringToHash("isAttack");
        isAttackComboHash = Animator.StringToHash("Combo");
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
            if(Time.time-lastClick<1f)
            {
                animator.SetBool(isAttackComboHash, true);
            }
            lastClick = Time.time;
        }
        else {
            animator.SetBool(isAttackHash, false);
            animator.SetBool(isAttackComboHash, false);
        }
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
                StartCoroutine(AttackDelay());
            }
            IEnumerator AttackDelay()
            {
                yield return new WaitForSeconds(0.2f);
                target.Damaged(damage);
            }
        }
    }
    void Sheathed()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            isSheathed = !isSheathed;
            slot2Script.GetComponent<ThrowingTutorial>().isNotEquipped = true;
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
