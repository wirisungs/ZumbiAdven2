using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{

    private bool isAttacking = false;    

   
    public Animator animator;

    [Header("SFX")]
    [SerializeField] private AudioClip attackSound;

    [Header("Attack")]
    [SerializeField] private int atkDamage = 2;
    public float attackRange = 0.5f;
    public Transform AttackPoint;
    public LayerMask enemyLayers;
    [SerializeField]private float cooldownAttack = 2f;

    public void Attack()
    {
        if (!isAttacking)
        {
            SFXManager.instance.PlaySound(attackSound);
            animator.SetTrigger("AttackTrigger");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);
            foreach(Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<MonsterLife>().TakeDamage(atkDamage);
            }

            isAttacking = true;
            StartCoroutine(ResetAttackAbility());

            //Debug.Log("Hit");
        }

        Invoke("ResetAttackAbility", cooldownAttack);
    }
    private IEnumerator ResetAttackAbility()
    {
        yield return new WaitForSeconds(cooldownAttack);
        isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {

        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }
}
