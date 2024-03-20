using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSTManager : MonoBehaviour
{

    public static OSTManager ost { get; private set; }
    private AudioSource source;

    private void Awake()
    {
        ost = this;
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip _sound)
    {
        ost.PlaySound(_sound);
    }
}
