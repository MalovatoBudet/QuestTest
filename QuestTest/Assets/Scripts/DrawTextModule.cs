using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawTextModule : MonoBehaviour
{
    [SerializeField] GameObject[] _textModules;
    Text _text;

    public void DrawModule(int id)
    {
        for (int i = 0; i < _textModules.Length; i++)
        {
            if (_textModules[i] != null)
            {
                _textModules[i].gameObject.SetActive(false);
            }
        }

        _textModules[id].gameObject.SetActive(true);

        _text = _textModules[id].GetComponentInChildren<Text>();
    }

    public void DrawText(string description)
    {
        _text.text = description;
    }
}
