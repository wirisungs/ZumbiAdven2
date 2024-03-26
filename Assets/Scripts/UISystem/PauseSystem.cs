using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    [SerializeField] public GameObject pausePanel;
    [SerializeField] private AudioClip pauseSFX;
    [SerializeField] private AudioClip resumeSFX;

    public void PauseGame(){
        SFXManager.instance.PlaySound(pauseSFX);
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume(){
        SFXManager.instance.PlaySound(resumeSFX);
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
