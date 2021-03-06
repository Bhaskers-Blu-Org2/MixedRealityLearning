﻿using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GenericNetworkManager : MonoBehaviour
{
    public static GenericNetworkManager instance;
    public static event Action OnReadyToStartNetwork;

    private bool isConnected;

    [HideInInspector]
    public PhotonView localUser;
    [HideInInspector]
    public string AzureAnchorID = "";

    void Awake()
    {
        if (GenericNetworkManager.instance == null)
        {
            GenericNetworkManager.instance = this;
        }
        else
        {
            if (GenericNetworkManager.instance != this)
            {
                Destroy(GenericNetworkManager.instance.gameObject);
                GenericNetworkManager.instance = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        ConnectToNetwork();
    }

    // For non Photon Networking solutions
    void StartNetwork(string ipaddress, string port)
    {
    }

    void ConnectToNetwork()
    {
        OnReadyToStartNetwork?.Invoke();
    }
}
