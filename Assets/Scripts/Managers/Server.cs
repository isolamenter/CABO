using System.Collections.Generic;
using UnityEngine;

public class Server : Singleton<Server>
{
    private List<ulong> idList;
    private Game cabo;
    
    public void Init()
    {
        Debug.Log("Server Init");
        idList = new List<ulong>();
    }

    public ulong[] Login(ulong sourceNetworkObjectId)
    {
        idList.Add(sourceNetworkObjectId);
        Debug.Log($"Login: {sourceNetworkObjectId}");
        return idList.ToArray();
    }

    public void StartGame()
    {
        cabo = new Game();
        cabo.StartGame(idList.Count);
        Network.Instance.StartGameClientRpc(cabo.GetGameData());
    }
}
