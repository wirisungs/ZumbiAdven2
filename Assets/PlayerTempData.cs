using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTempData : MonoBehaviour
{
    private string Username = null;
    private string Password = null;
    private bool State = false;

    public void SetUsername(string Username)
    {
        this.Username = Username;
    }
    public void SetPassword(string Password)
    {
        this.Password = Password;
    }
    public bool GetState () => State;
    public void SetState(bool State)
    {
        this.State = State;
    }
    public PlayerTempData(string username, string password, bool state = false)
    {
        Username = username;
        Password = password;
        State = state;
    } 
    
}
