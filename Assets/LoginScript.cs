using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginScript : MonoBehaviour
{
    [SerializeField] private InputField Username;
    [SerializeField] private InputField Password;
    [SerializeField] private GameObject LoginPanel;
    [SerializeField] private GameObject WelcomeBox;
    [SerializeField] private Text WelcomeText;
    [SerializeField] private GameObject LoginButton;

    [SerializeField] private GameObject Register;
    [SerializeField] private Camera cameraMain;

    private PlayerTempData playerData;
    private RegisterScript registerScript;
    private List<PlayerTempData> playerTempDatas;
    private void Start()
    {
        registerScript = Register.GetComponent<RegisterScript>();
        playerTempDatas = registerScript.GetPlayerTempDatas();
        playerData = cameraMain.GetComponent<PlayerTempData>();
    }
    public void Login()
    {
        string username = Username.text;
        string password = Password.text;
        string nameToShow = null;

        bool isLoggedIn = false;

        foreach (PlayerTempData player in playerTempDatas)
        {
            if (player.GetUsername() == username && player.GetPassword() == password)
            {
                isLoggedIn = true;
                player.SetState(true);
                nameToShow = player.GetUsername();
                break;
            }
            if (player.GetUsername() != username)
            {
                Debug.Log("Tài khoản không tồn tại");
                break;
            }
            if (player.GetPassword() != password)
            {
                Debug.Log("Sai mật khẩu");
                break;
            }
        }
        if (isLoggedIn)
        {
            Debug.Log("Đăng nhập thành công");
            playerData.SetState(true);
            WelcomeBox.SetActive(true);
            LoginButton.SetActive(false);
            LoginPanel.SetActive(false);
            WelcomeText.text = $"Welcome, {nameToShow}";
        }
    }
}
