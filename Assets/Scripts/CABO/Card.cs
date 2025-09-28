using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Image cardImage;
    
    private static readonly Dictionary<string, Sprite> Dict = new();
    
    public void ShowBack()
    {
        gameObject.SetActive(true);
        cardImage.sprite = GetCard("card-back");
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show(string cardName)
    {
        gameObject.SetActive(true);
        cardImage.sprite = GetCard("card-" + cardName);
    }

    private static Sprite GetCard(string name)
    {
        if (Dict.Count == 0)
        {
            var sprites = Resources.LoadAll<Sprite>($"Card");
            foreach (var s in sprites)
            {
                Dict[s.name] = s;
            }
        }

        return Dict.GetValueOrDefault(name);
    }
}