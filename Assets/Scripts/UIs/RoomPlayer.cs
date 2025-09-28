using UnityEngine;
using UnityEngine.UI;

public class RoomPlayer : MonoBehaviour
{
    public Text playerName;

    public void RefreshPlayer(int index,bool inLocalPlayer)
    {
        playerName.text = $"Player {index + 1}";
        playerName.color = inLocalPlayer? Color.darkRed : Color.white;
    }
}

