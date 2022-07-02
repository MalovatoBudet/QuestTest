using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public struct EdgeTask
{
    public int source_id;
    public int target_id;
    [SerializeField] int id;
}

[Serializable]
public struct EdgeTaskArray
{
    public EdgeTask[] tasks;
}

public class EdgeTaskParser : MonoBehaviour
{
    [SerializeField] TextAsset textJSON;

    public EdgeTask[] edgeTaskArray;

    public void Awake()
    {
        string s = "";

        s = "{\"tasks\":" + textJSON + "}";

        edgeTaskArray = JsonUtility.FromJson<EdgeTaskArray>(s).tasks;
    }
}
