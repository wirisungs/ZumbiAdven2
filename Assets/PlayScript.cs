using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    private PlayerTempData tempData;
    private void Start()
    {
        tempData = mainCam.GetComponent<PlayerTempData>();
    }
    public void OnClickStart()
    {
        if (CheckPlayerState())
            SceneManager.LoadSceneAsync("Level1");
        else Debug.Log("Login first, Please!");
    }
    public bool CheckPlayerState()
    {
        return tempData.GetState();
    }
}
