using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Management;

public class AsymmControlHandler : MonoBehaviour
{
    public class XRChecker
    {
        public static bool isPresent()
        {
            var xrDisplaySubsystems = new List<XRDisplaySubsystem>();
            SubsystemManager.GetInstances<XRDisplaySubsystem>(xrDisplaySubsystems);
            foreach (var xrDisplay in xrDisplaySubsystems)
            {
                if (xrDisplay.running)
                {
                    return true;
                }
                else
                {
                    UnityEngine.XR.Management.XRGeneralSettings.Instance.Manager.DeinitializeLoader();
                    XRGeneralSettings.Instance.Manager.StopSubsystems();
                }
            }
            return false;
        }
    }
    public Camera asyCam;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        //if XR is present, loads into VRView Scene, otherwise, loads into Asymm Aspect
        if (!XRChecker.isPresent())
        {
            asyCam.enabled = true;
            asyCam = Camera.main;
        }
    }
}
