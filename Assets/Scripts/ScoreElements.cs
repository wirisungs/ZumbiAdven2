using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreElements : MonoBehaviour
{
    public TMP_Text usernameText;
    public TMP_Text timesText;
    public TMP_Text deathsText;

    public void NewScoreElement(string _username, int _kills, int _deaths)
    {
        usernameText.text = _username;
        timesText.text = _kills.ToString();
        deathsText.text = _deaths.ToString();

    }
}