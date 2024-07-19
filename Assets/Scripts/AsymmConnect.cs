using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsymmConnect : MonoBehaviour
{
    public void Join()
    {
        SceneManager.LoadScene("VRView");
        NetworkManager.Singleton.StartClient();
    }
}
