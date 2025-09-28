using System.Collections.Generic;
using UnityEngine;

public class HoleCards : MonoBehaviour
{
    public List<Card> Cards;

    public void Refresh(PlayerData playerData)
    {
        for (var index = 0; index < Cards.Count; index++)
        {
            var card = Cards[index];
            card.Show(playerData.cards[index]);
        }
    }
}