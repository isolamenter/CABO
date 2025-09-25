using Unity.Netcode;
using UnityEngine;

public class Player : NetworkBehaviour
{
    private Server server;
    
    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            server = new Server();
            server.Init();
        }
        
        if (IsOwner)
        {
            Debug.Log("本地玩家生成");
            LoginServerRpc(NetworkObjectId);
        }
    }

    // 从客户端 → 服务器
    [ServerRpc]
    void LoginServerRpc(ulong sourceNetworkObjectId)
    {
        server.Login(sourceNetworkObjectId);
        //LoginS2CRpc()
    }

    // 从服务器 → 所有客户端
    [ClientRpc]
    void LoginClientRpc(Vector3 pos)
    {
        if (!IsOwner) // 不是本地玩家时才更新
        {
            transform.position = pos;
        }
    }

    
}