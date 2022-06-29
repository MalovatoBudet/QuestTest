using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBackground : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;

    Texture2D _texture2D;
    Sprite _mySprite;
    SpriteRenderer _spriteRenderer;    

    void Awake()
    {
        _spriteRenderer = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
    }

    public void Draw(string path)
    {
        _texture2D = Resources.Load(path, typeof(Texture2D)) as Texture2D;
        _mySprite = Sprite.Create(_texture2D, new Rect(0, 0, _texture2D.width, _texture2D.height), new Vector2(0.5f, 0.5f));

        _spriteRenderer.sprite = _mySprite;

        ScaleCamera();
    }

    void ScaleCamera()
    {
        float size = _texture2D.height / 2;
        _mainCamera.orthographicSize = size / 100;
    }
}
