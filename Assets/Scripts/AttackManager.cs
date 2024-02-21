using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField] private int atkDamage = 2;

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
