using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

    public float health;
    public float currentHealth {get; private set;}
    private BossHealth bossHealth;
    public int damage;
    private float timeBtwDamage = 1.5f;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRenderer;

    private bool invulnerable;

    [SerializeField] private Behaviour[] component;




    private Animator anim;
    public bool isDead;

    private void Awake(){
        currentHealth = health;
    }

    private void TakeDamage(float _damage){
        currentHealth = Mathf.Clamp(health - _damage, 0, health);
        StartCoroutine(Invulnerability());

        if (health <= 25) {
            anim.SetTrigger("stageTwo");
        }

        if (health <= 0) {
            anim.SetTrigger("death");
            foreach(Behaviour component in component)
            {
                component.enabled = false;
            }
        }

       
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    private void Update()
    {

        if (health <= 25) {
            anim.SetTrigger("stageTwo");
        }

        if (health <= 0) {
            anim.SetTrigger("death");
        }

        // give the player some time to recover before taking more damage !
        if (timeBtwDamage > 0) {
            timeBtwDamage -= Time.deltaTime;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // deal the player damage ! 
        if (other.CompareTag("Player") && isDead == false) {
            if (timeBtwDamage <= 0) {
                other.GetComponent<PlayerLife>()?.TakeDamage(damage);
            }
        } 
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes));
        }
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }
}
