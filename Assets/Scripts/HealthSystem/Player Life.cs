using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float numDeaths = 0f;

    public float getStartingHealth()
    {
        return startingHealth;
    }

    public void setStartingHealth(float startingHealth)
    {
        this.startingHealth = startingHealth;
    }

    public float currentHealth { get; set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRenderer;

    [Header("SFX")]
    [SerializeField] private AudioClip deathSound;

    [Header("Component")]
    [SerializeField] private Behaviour[] component;
    private bool invulnerable;

    


    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("HurtTrigger");
            StartCoroutine(Invulnerability());
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("DeathTrigger");


                foreach(Behaviour component in component)
                    component.enabled = false;


                dead = true;

                SFXManager.instance.PlaySound(deathSound);
            }
           
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        for(int i = 0; i < numberOfFlashes; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes));
        }
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }

    public void Respawn()
    {
        dead = false;
        numDeaths++;
        AddHealth(startingHealth);
        anim.ResetTrigger("DeathTrigger");
        anim.Play("player_idle");
        StartCoroutine(Invulnerability());
        foreach (Behaviour component in component)
            component.enabled = true;
        
    }

    
}

