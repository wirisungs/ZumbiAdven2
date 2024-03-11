using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField] private float attackCD;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damange;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    [Header("SFX")]
    [SerializeField] private AudioClip attackSound;

    private PlayerLife playerLife;
    private Animator animator;

    private EnemyPatrol enemyPatrol;

    private bool isTakeDamage = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;


        if(PlayerInSight())
        {
            if(cooldownTimer >= attackCD && playerLife.currentHealth > 0)
            {
                cooldownTimer = 0;
                animator.SetTrigger("attack");
                SFXManager.instance.PlaySound(attackSound);
            }

        }

        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();

    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            playerLife = hit.transform.GetComponent<PlayerLife>();



        return hit.collider != null;
    }


    private void OnDrawGizmos()
    {
        if(isTakeDamage == true)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
                new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
            isTakeDamage = false;
        }
        
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            playerLife.TakeDamage(damange);
            isTakeDamage = true;
        }    
    }
}
