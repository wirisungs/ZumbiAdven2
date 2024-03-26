using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreElement : MonoBehaviour
{

    public TMP_Text usernameText;
    public TMP_Text timesText;
    public TMP_Text deathsText;

    public void NewScoreElement (string _username, int _times, int _deaths)
    {
        usernameText.text = _username;
        timesText.text = _times.ToString();
        deathsText.text = _deaths.ToString();
    }

}
