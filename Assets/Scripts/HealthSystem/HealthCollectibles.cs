using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectibles : MonoBehaviour
{
    [SerializeField] private float healthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerLife>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}
