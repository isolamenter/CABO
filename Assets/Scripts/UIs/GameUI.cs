using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public Card deck;
    public Card discardPile;
    public Card showCard;
    public List<HoleCards> holes;

    public void Refresh(GameData data)
    {
        showCard.Hide();
        deck.ShowBack();
        discardPile.Show(data.discard);
        RefreshPlayer(data.players);
    }

    private void RefreshPlayer(PlayerData[] playerData)
    {
        for (var index = 0; index < holes.Count; index++)
        {
            var hole = holes[index];
            var player = playerData.ElementAtOrDefault(index);
            if (player != null)
            {
                hole.gameObject.SetActive(true);
                hole.Refresh(player);
            }
            else
            {
                hole.gameObject.SetActive(false);
            }
        }
    }
}