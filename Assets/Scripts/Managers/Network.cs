using System;
using Unity.Netcode;
using UnityEngine;

public class Network : NetworkBehaviour
{
    public static Network Instance;
    
    public override void OnNetworkSpawn()
    {
        Instance = this;
        
        if (IsOwner)
        {
            if (IsServer)
            {
                Server.Instance.Init();
            }
            
            Debug.Log("本地玩家生成");
            LoginServerRpc(NetworkObjectId);
        }
    }
    
    [ServerRpc]
    public void LoginServerRpc(ulong playerId)
    {
        var idList = Server.Instance.Login(playerId);
        LoginClientRpc(idList, playerId);
    }

    [ClientRpc]
    public void LoginClientRpc(ulong[] idList, ulong playerId)
    {
        var index = Array.IndexOf(idList,playerId);
        var count = idList.Length;
        
        UIManager.Instance.Hide("Main");
        var roomUI = UIManager.Instance.Show("Room");
        roomUI.GetComponent<RoomUI>().RefreshPanel(count, index, IsServer);
    }
    
    [ClientRpc]
    public void StartGameClientRpc(string dataJson)
    {
        UIManager.Instance.Hide("Room");
        UIManager.Instance.Show("Game");
        var gameUI = UIManager.Instance.Show("Game");
        Debug.Log(dataJson);
        var data = JsonUtility.FromJson<GameData>(dataJson);
        gameUI.GetComponent<GameUI>().Refresh(data);
    }
}