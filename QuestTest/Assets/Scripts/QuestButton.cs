using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestButton : MonoBehaviour
{
    [SerializeField] Text _text;
    [SerializeField] int _id;

    [SerializeField] CardsDispalyer _cardsDispalyer;

    public void ShowText(string text)
    {
        _text.text = text;
    }

    public void StoreId(int id)
    {
        _id = id;
    }

    public void OnButtonClick()
    {
        _cardsDispalyer.Show(_id);
    }
}
