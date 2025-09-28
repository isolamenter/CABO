using System.Collections.Generic;
using UnityEngine;

public class RoomUI : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform playerParent;
    public GameObject startButton;

    public void RefreshPanel(int count, int index, bool isServer)
    {
        Debug.Log("RoomPlayer count: " + count);
        
        // 清空子节点
        for (var i = 0; i < playerParent.childCount; i++)
        {
            Destroy(playerParent.GetChild(i).gameObject);
        }
        
        // 刷新player
        for (var i = 0; i < count; i++)
        {
            var player= Instantiate(playerPrefab, Vector3.zero, Quaternion.identity, playerParent);
            player.GetComponent<RoomPlayer>().RefreshPlayer(index, index == i);
        }

        //刷新按钮
        startButton.SetActive(isServer && count >= 2);
    }

    public void OnStartButtonClick()
    {
        Server.Instance.StartGame();
    }
}
