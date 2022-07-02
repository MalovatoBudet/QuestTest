using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestButton : MonoBehaviour
{
    [SerializeField] Text _text;

    int _id;

    public void ShowText(string text)
    {
        _text.text = text;
    }

    public void StoreId(int id)
    {
        _id = id;
    }
}
