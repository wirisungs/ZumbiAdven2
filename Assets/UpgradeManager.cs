using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public Text playerCoins;

    // AtkUI
    public Text AtkLevel;
    public Text AtkDamage;
    public Text AtkPrice;

    // DefUI
    public Text DefLevel;
    public Text Def;
    public Text DefPrice;

    // Max level for Atk & Def
    public float maxLevel = 5f;

    private float AtkLevelNum = 1f;
    private float AtkDamageNum = 1f;
    private float AtkPriceNum = 2f;

    private float DefLevelNum = 1f;
    private float DefHealthNum = 1f;
    private float DefPriceNum = 2f;

    private float AtkDamageFromATKManager;
    private float DefFromPlayerLife;

    // From other script
    public AttackManager attackManager;
    public PlayerLife playerLife;
    public coinCollector CoinCollector;


    // Game Object
    [Header("Game Object")]
    public GameObject UpgradePanel;
    public GameObject HealthBar;
    public GameObject CoinCollectorGameObject;
    public GameObject ActionButton;
    public GameObject MoveButton;
    public GameObject UpgradeButton;


    private void Start()
    {
        attackManager = GetComponent<AttackManager>();
        AtkDamageFromATKManager = attackManager.getAtkDamage();

        playerLife = GetComponent<PlayerLife>();
        DefFromPlayerLife = playerLife.getStartingHealth();
    }

    private void Update()
    {
        // Upgrade Attack
        UpdateAttackButton();

        // Upgrade Defense
        UpdateDefenseButton();

        playerCoins.text = CoinCollector.coins.ToString() + " Coins";

        if (checkActive())
        {
            HealthBar.SetActive(false);
            CoinCollectorGameObject.SetActive(false);
            ActionButton.SetActive(false);
            MoveButton.SetActive(false);
            UpgradeButton.SetActive(false);
        }
        else
        {
            HealthBar.SetActive(true);
            CoinCollectorGameObject.SetActive(true);
            ActionButton.SetActive(true);
            MoveButton.SetActive(true);
        }
    }

    private void UpdateAttackButton()
    {
        AtkLevel.text = "Level: " + AtkLevelNum.ToString() + $" / {maxLevel}";

        if (AtkLevelNum < maxLevel)
        {
            AtkDamage.text = "Atk: +" + AtkDamageNum.ToString();
            AtkPrice.text = "Price: " + AtkPriceNum.ToString() + " Coins";
        }
        else
        {
            AtkDamage.text = "Atk: MAX LEVEL";
            AtkPrice.text = "Price: MAX LEVEL";
        }
    }

    public void UpgradeAttack()
    {
        if (AtkLevelNum < maxLevel)
        {
            if (CoinCollector.coins >= AtkPriceNum)
            {
                CoinCollector.coins -= AtkPriceNum; // Tiền người chơi bị trừ theo giá trị nâng cấp
                AtkPriceNum++; // Giá nâng cấp tiếp theo ++

                AtkDamageFromATKManager += AtkDamageNum; // Sức mạng thăng theo AtkDamageNum
                attackManager.setAtkDamage(AtkDamageFromATKManager);

                AtkLevelNum++; // Level++
            }
            else
                Debug.Log("Not enough money");
        }
        else
            Debug.Log("Đã đạt cấp độ tối đa");
    }
    private void UpdateDefenseButton()
    {
        DefLevel.text = "Level: " + DefLevelNum.ToString() + $" / {maxLevel}";

        if (DefLevelNum < maxLevel)
        {
            Def.text = "Def: +" + DefHealthNum.ToString();
            DefPrice.text = "Price: " + DefPriceNum.ToString() + " Coins";
        }
        else
        {
            Def.text = "Def: MAX LEVEL";
            DefPrice.text = "Price: MAX LEVEL";
        }
    }

    public void UpgradeDefense()
    {
        if (DefLevelNum < maxLevel)
        {
            if (CoinCollector.coins >= DefPriceNum)
            {
                CoinCollector.coins -= DefPriceNum; // Tiền người chơi bị trừ theo giá trị nâng cấp
                DefPriceNum++; // Giá nâng cấp tiếp theo ++

                DefFromPlayerLife += DefHealthNum; // Sức mạng thăng theo AtkDamageNum
                playerLife.setStartingHealth(DefFromPlayerLife);
                playerLife.currentHealth = DefFromPlayerLife;

                DefLevelNum++; // Level++
            }
            else
                Debug.Log("Not enough money");
        }
        else
            Debug.Log("Đã đạt cấp độ tối đa");
    }

    public bool checkActive()
    {
        return UpgradePanel.activeSelf ? true : false;
    }
}
