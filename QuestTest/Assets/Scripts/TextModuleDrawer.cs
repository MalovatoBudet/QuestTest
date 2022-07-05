using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public class KeyValuePair
{
    public int key;
    public GameObject val;
}

public class TextModuleDrawer : MonoBehaviour
{
    [SerializeField] List<KeyValuePair> MyList = new List<KeyValuePair>();

    Dictionary<int, GameObject> myDict = new Dictionary<int, GameObject>();

    Text _text;

    void Awake()
    {
        foreach (var kvp in MyList)
        {
            myDict[kvp.key] = kvp.val;
        }
    }      

    public void DrawModule(int id)
    {
        myDict[id].SetActive(true);

        _text = myDict[id].GetComponentInChildren<Text>();        
    }

    public void DrawText(string description)
    {
        _text.text = description;
    }

    public void EraseModule(int id)
    {
        myDict[id].SetActive(false);
    }
}