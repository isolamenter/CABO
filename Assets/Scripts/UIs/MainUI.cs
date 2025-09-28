using Unity.Netcode;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public void OnHostClick()
    {
        NetworkManager.Singleton.StartHost();
        Debug.Log("Host");
    }
    
    public void OnJoinClick()
    {
        NetworkManager.Singleton.StartClient();
        Debug.Log("Join");
    }
}