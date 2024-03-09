using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private PlayerLife playerHealh;
    [SerializeField] private Image totalHealthbar;
    [SerializeField] private Image currentHealthbar;

    private void Start()
    {
        totalHealthbar.fillAmount = playerHealh.currentHealth /10;
    }

    private void Update()
    {
        totalHealthbar.fillAmount = playerHealh.getStartingHealth() / 10;
        currentHealthbar.fillAmount = playerHealh.currentHealth /10;
    }
}
