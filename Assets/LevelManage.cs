using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManage : MonoBehaviour
{
    public static LevelManage main;

    public Transform SpawningPoint;

    private void Awake()
    {
        main = this;
    }
}
