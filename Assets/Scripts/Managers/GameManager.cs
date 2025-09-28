using UnityEngine;

public class GameManager : BaseManager<GameManager>
{
    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        Debug.Log("进入游戏");
        
        UIManager.Instance.Show("Main");
    }
}