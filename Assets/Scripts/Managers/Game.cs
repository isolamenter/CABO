using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

[Serializable]
public class GameData
{
    public string discard;
    public PlayerData[] players;
}

[Serializable]
public class PlayerData
{
    public int index;
    public string[] cards;
}

public class Game
{
    public class GamePlayer
    {
        public int Index;
        public Dictionary<int, string> Cards;
    }
    
    public Queue<string> Deck;
    public List<GamePlayer> Players;
    public string DiscardPile;
    
    /// <summary>
    /// 获取打乱后的扑克牌（含大小王）
    /// </summary>
    private static List<string> GetShuffledDeck()
    {
        string[] suits = { "1", "2", "3", "4" };
        string[] ranks = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13" };
        
        // 1. 生成一副牌
        var deck = new List<string>();
        foreach (var suit in suits)
        {
            foreach (var rank in ranks)
            {
                deck.Add($"{suit}-{rank}");
            }
        }

        // 添加大小王
        deck.Add("0-1");
        deck.Add("0-2");

        // 2. Fisher-Yates 洗牌
        var random = new Random();
        for (var i = deck.Count - 1; i > 0; i--)
        {
            var j = random.Next(0, i + 1);
            (deck[i], deck[j]) = (deck[j], deck[i]);
        }

        return deck;
    }
    
    public void StartGame(int count)
    {
        Deck = new Queue<string>(GetShuffledDeck());
        
        Players = new List<GamePlayer>();
        for (int i = 0; i < count; i++)
        {
            Players.Add(new GamePlayer
            {
                Index = i + 1,
                Cards = DrawFromDeck(4)
                    .Select((value, index) => new { value, index })
                    .ToDictionary(x => x.index, x => x.value)
            });
        }

        DiscardPile = DrawFromDeck(1).First();
    }

    private List<string> DrawFromDeck(int count)
    {
        var res = new List<string>();
        for (var i = 0; i < count; i++)
        {
            res.Add(Deck.Dequeue());
        }

        return res;
    }

    public string GetGameData()
    {
        var data = new GameData()
        {
            discard = DiscardPile,
            players = Players.Select(p => new PlayerData
            {
                index = p.Index,
                cards = p.Cards.Values.ToArray()
            }).ToArray()
        };
        return JsonUtility.ToJson(data);
    }
}
