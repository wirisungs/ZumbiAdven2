using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public int health;
    public int damage;

    private float timeBtwDamage = 1.5f; //thoi gian nghi giua cac don danh cua boss

    private Animator anim;

    private void Start(){
        anim = GetComponent<Animator>();
    }

    private void Update(){
        if(health <= 0){
            anim.SetTrigger("death");
        }

        if(timeBtwDamage > 0){
            timeBtwDamage -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.tag == "Player")
            collider.GetComponent<PlayerLife>()?.TakeDamage(damage);
    }   
}
