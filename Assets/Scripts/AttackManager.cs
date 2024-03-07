using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField] private float atkDamage = 2f;

    public float getAtkDamage()
    {
        return atkDamage;
    }

    public void setAtkDamage(float atkDamage)
    {
        this.atkDamage = atkDamage;
    }

    private bool isAttacking = false;
    private float cooldownAttack = 0.5f;
    public Animator animator;

  

    public void Attack()
    {
        if (!isAttacking)
        {
            animator.SetTrigger("AttackTrigger");
            isAttacking = true;
            StartCoroutine(ResetAttackAbility());
        }

        Invoke("ResetAttackAbility", cooldownAttack);
    }
    private IEnumerator ResetAttackAbility()
    {
        yield return new WaitForSeconds(cooldownAttack);
        isAttacking = false;
    }
}
