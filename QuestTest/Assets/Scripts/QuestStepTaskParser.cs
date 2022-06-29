using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.VersionControl;
using UnityEngine;

[Serializable]
public struct QuestStepTask
{
    public string description;
    public string choice_description;
    public int id;
    public Visualisations[] visualisations;
    public Card card;
}

[Serializable]
public struct Visualisations
{
    [SerializeField] string title;
    [SerializeField] string description;
    public int id;
}

[Serializable]
public struct Card
{
    [SerializeField] int id;
    [SerializeField] int queststep_id;
    public Image image;
}

[Serializable]
public struct Image
{
    public string file_id;
}

[Serializable]
public struct QuestStepTaskArray
{
    public QuestStepTask[] tasks;
}

public class QuestStepTaskParser : MonoBehaviour
{
    [SerializeField] TextAsset textJSON;

    public QuestStepTask[] questStepTaskArray;

    public void Awake()
    {
        string s = "";

        s = "{\"tasks\":" + textJSON.text + "}";

        questStepTaskArray = JsonUtility.FromJson<QuestStepTaskArray>(s).tasks;
    }
}