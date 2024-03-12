using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterScript : MonoBehaviour
{
    [SerializeField] private InputField CfmPasswordInputField;
    [SerializeField] private InputField UsernameInputField;
    [SerializeField] private InputField PasswordInputField;
    [SerializeField] private GameObject RegisPanel;
    
    private List<PlayerTempData> playerTempDatas = new List<PlayerTempData>();

    public List<PlayerTempData> GetPlayerTempDatas() { return playerTempDatas; }

    public void Register()
    {
        CreateAccount(UsernameInputField.text, PasswordInputField.text, CfmPasswordInputField.text);
    }

    public void CreateAccount(string Username, string Password, string CfmPassword)
    {
        if(Username != "" && Password != "" && CfmPassword != "")
        {
            if (Password != CfmPassword)
                Debug.Log("Mật khẩu không trùng khớp");
            else
            {
                PlayerTempData newUser = new PlayerTempData(Username, Password);
                playerTempDatas.Add(newUser);
                Debug.Log("Đăng ký thành công");

                RegisPanel.SetActive(false);
            }
        }
        else
            Debug.Log("Không được để trống");
    }

}
