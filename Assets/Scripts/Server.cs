using System.Collections.Generic;
using UnityEngine;

public class Server
{
    public List<ulong> IDList;
    
    public void Init()
    {
        Debug.Log("Server Init");
        IDList = new List<ulong>();
    }

    public void Login(ulong sourceNetworkObjectId)
    {
        IDList.Add(sourceNetworkObjectId);
        Debug.Log($"Login: {sourceNetworkObjectId}");
    }
}
