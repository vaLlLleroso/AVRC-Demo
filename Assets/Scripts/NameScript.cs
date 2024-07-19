using System;
using UnityEngine;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Vivox;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Management;
using UnityEngine.XR;

public class NameScript : MonoBehaviour
{
    [SerializeField] private Button loginButton;
    [SerializeField] private TMP_InputField userInput;

    private async void InitializeAsync()
    {
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        await VivoxService.Instance.InitializeAsync();
        // Don't log in here, we'll do it in OnLoginButtonClicked
    }

    private void Awake()
    {
        InitializeAsync();
        loginButton.onClick.AddListener(OnLoginButtonClicked); // Add this line
    }


    private async void OnLoginButtonClicked()
    {
        var username = userInput.text;
        LoginOptions options = new LoginOptions();
        if (string.IsNullOrEmpty(username))
        {
            System.Random rand = new System.Random();
            int rng = rand.Next(0, 255);
            options.DisplayName = "user" + rng;
            await VivoxService.Instance.LoginAsync(options);
        }
        else
        {
            options.DisplayName = username;
            options.EnableTTS = true;
            await VivoxService.Instance.LoginAsync(options);
        }
        bootInto();
    }

    public void bootInto()
    {
        bool isXREnabled = XRGeneralSettings.Instance.Manager.activeLoader != null;
        Debug.Log("Is XR Enabled: " + isXREnabled);

        var xrDisplaySubsystems = new List<XRDisplaySubsystem>();
        SubsystemManager.GetInstances(xrDisplaySubsystems);
        foreach (var xrDisplay in xrDisplaySubsystems)
        {
            if (!xrDisplay.running)
            {
                Debug.Log("VR RUNNING");
                break;
            }
        }
        //if XR is present, loads into VRView Scene, otherwise, loads into MainMenu
        if (isXREnabled == false)
        {
            Debug.Log("VR NOT SEEN!!! LOADING INTO MAIN MENU");
            if (XRGeneralSettings.Instance.Manager.isInitializationComplete)
            {
                Debug.Log("DISABLING XR...");
                XRGeneralSettings.Instance.Manager.StopSubsystems();
                UnityEngine.XR.Management.XRGeneralSettings.Instance.Manager.DeinitializeLoader();
            }
            SceneManager.LoadScene(1);
            PlayerPrefs.DeleteAll(); // Reset PlayerPrefs
        }
        else
        {
            SceneManager.LoadSceneAsync(2);
        }
    }
}
