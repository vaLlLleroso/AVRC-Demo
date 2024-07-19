using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using Unity.Netcode;
using UnityEngine;

public class AsymmNetworkPlayer : NetworkBehaviour
{
    public Transform body;
    public Renderer[] meshToDisable;
    // Start is called before the first frame update
    void Start()
    {
        if (IsOwner)
        {
            foreach (var item in meshToDisable)
            {
                item.enabled = true;
            }
        }
    }
    void Update()
    {
        if (IsOwner)
        {
            body.position = transform.position;
            body.rotation = transform.rotation;
        }

    }
}
