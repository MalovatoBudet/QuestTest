using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsDispalyer : MonoBehaviour
{
    [SerializeField] CardsCreator _cardsCreator;

    [SerializeField] BackgroundDrawer _drawBackground;

    [SerializeField] TextModuleDrawer _textModuleDrawer;

    Dictionary<int, QuestCard> _cardDictionary = new Dictionary<int, QuestCard>();

    [SerializeField] QuestButton _mainButton;
    [SerializeField] QuestButton[] _buttons;


    void Start()
    {
        _cardDictionary = _cardsCreator._cardDictionary;


        Show(17);
    }

    public void Show(int cardId)
    {
        _drawBackground.Draw(_cardDictionary[cardId].questStepTask.card.image.file_id);

        _textModuleDrawer.DrawModule(_cardDictionary[cardId].questStepTask.visualisations[0].id);
        _textModuleDrawer.DrawText(_cardDictionary[cardId].questStepTask.description);

        //перебор массива с кнопками для назначения текста и id
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].StoreId(_cardDictionary[cardId].questButtonsId[i]);
            _buttons[i].ShowText(_cardDictionary[cardId].questButtonsText[i]);
        }

        //передача id в кнопку размером с экран, когда нет разветвления
        _mainButton.StoreId(_cardDictionary[cardId].questMainButton);
    }
}
