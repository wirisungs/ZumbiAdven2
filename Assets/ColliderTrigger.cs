using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
   
    [SerializeField] GameObject boss;
    private void OnTriggerEnter2D(Collider2D collider){
            if(collider.tag == "Player"){
                boss.SetActive(true);
            }
        }
    }

