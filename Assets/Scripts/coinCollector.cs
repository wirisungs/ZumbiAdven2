using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class coinCollector : MonoBehaviour
{
    public float coins = 0f;

    [SerializeField] private Text coinText;

    private void Update()
    {
        coinText.text = "Coins: " + coins.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coins++;
        }
    }


}
