using System;
using UnityEngine;

public class BossSpawn : MonoBehaviour{

    [SerializeField] GameObject boss;

    public void Spawn(){
        boss.SetActive(true);
        Time.timeScale = 0f;
    }

}