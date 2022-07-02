using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundDrawer : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;
    [SerializeField] RawImage _rawImage;

    public void Draw(string path)
    {
        _rawImage.texture = Resources.Load(path, typeof(Texture2D)) as Texture2D;
    }
}
