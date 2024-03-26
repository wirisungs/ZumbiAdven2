using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuLoader : MonoBehaviour
{
    void OnEnable(){
        SceneManager.LoadScene("MainMenu");
    }
}
