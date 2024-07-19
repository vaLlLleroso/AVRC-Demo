using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Management;
using UnityEngine.XR;

public class LoadingSliderControl : MonoBehaviour
{
    public GameObject loadingScreenObj;
    public Slider slider;
    public Text text;
    AsyncOperation async;
    
    //Check for VR Inputs
    private void Start()
    {
        /*
         *         bool isXREnabled = XRGeneralSettings.Instance.Manager.activeLoader != null;
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
            if(XRGeneralSettings.Instance.Manager.isInitializationComplete)
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
            async = SceneManager.LoadSceneAsync(2);
        }
         */

    }
    public void CallLoad()
    {
        StartCoroutine(LoadingScreen());

    }
    
      IEnumerator LoadingScreen()
    {
        //sets the loading bar to the asynchronous scene loading progress
        loadingScreenObj.SetActive(true);
        async = SceneManager.LoadSceneAsync(1);
        while (!async.isDone) 
        {
            slider.value = async.progress;
            Debug.Log("Pro: " + async.progress);
            if (async.progress == 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
