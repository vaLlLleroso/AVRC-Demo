using UnityEngine;
using Unity.Netcode;
using UnityEngine.XR;
using System.Collections.Generic;
using UnityEngine.XR.Management;

public class PlayerHandling : NetworkBehaviour
{
    [SerializeField] private GameObject playerPrefabA; //add prefab in inspector
    [SerializeField] private GameObject playerPrefabB; //add prefab in inspector

    [ServerRpc(RequireOwnership = false)]
    public void OnNetworkSpawnServerRpc(ulong clientId)
    {
        int playerType = XRCheck();
        GameObject newPlayer;

        if (playerType == 0)
        {
            newPlayer = Instantiate((playerPrefabA));
        }
        else
        {
            newPlayer = Instantiate((playerPrefabB));
        }

        NetworkObject netObj = newPlayer.GetComponent<NetworkObject>();
        newPlayer.SetActive(true);
        netObj.SpawnAsPlayerObject(clientId);
    }

    public int XRCheck()
    {
        int integer = 0;
        bool isXREnabled = XRGeneralSettings.Instance.Manager.activeLoader != null;
        Debug.Log("Is XR Enabled: " + isXREnabled);

        var xrDisplaySubsystems = new List<XRDisplaySubsystem>();
        SubsystemManager.GetInstances(xrDisplaySubsystems);
        foreach (var xrDisplay in xrDisplaySubsystems)
        {
            if (xrDisplay.running)
            {
                integer = 0;
            }
            else
            {
                integer = 1;
            }
        }

        return integer;
    }
}
