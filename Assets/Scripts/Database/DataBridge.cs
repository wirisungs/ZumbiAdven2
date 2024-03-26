using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using TMPro;
using Unity.VisualScripting;

public class DataBridge : MonoBehaviour {
    public TMP_Text playerNameInput, killsInput;
    private Player data;

    private string DATA_URL = "https://zadb1-d088c-default-rtdb.asia-southeast1.firebasedatabase.app";

    void Start(){
        
    }

}