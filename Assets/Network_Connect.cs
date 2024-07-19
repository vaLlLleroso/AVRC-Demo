using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.XR;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class Network_Connect : MonoBehaviour
{
    public void Create()
    { 
        NetworkManager.Singleton.StartHost();
    }
    public void Join()
        {
        NetworkManager.Singleton.StartClient();
        }
}
