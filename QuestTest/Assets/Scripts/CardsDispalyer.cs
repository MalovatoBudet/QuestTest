using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsDispalyer : MonoBehaviour
{
    [SerializeField] CardsCreator _cardsCreator;
    [SerializeField] BackgroundDrawer _drawBackground;
    [SerializeField] TextModuleDrawer _textModuleDrawer;    

    [SerializeField] QuestButton _mainButton;
    [SerializeField] QuestButton[] _buttons;

    [SerializeField] int _currentCardId = 17;
    [SerializeField] int _previousmoduleId = 7;

    Dictionary<int, QuestCard> _cardDictionary = new Dictionary<int, QuestCard>();

    void Start()
    {
        _cardDictionary = _cardsCreator._cardDictionary;

        Show(_currentCardId);
    }


    public void Show(int cardId)
    {
        if (_previousmoduleId != 0)
        {
            _textModuleDrawer.EraseModule(_previousmoduleId);
        }

        _previousmoduleId = _cardDictionary[cardId].questStepTask.visualisations[0].id;

        _drawBackground.Draw(_cardDictionary[cardId].questStepTask.card.image.file_id);

        _textModuleDrawer.DrawModule(_cardDictionary[cardId].questStepTask.visualisations[0].id);
        _textModuleDrawer.DrawText(_cardDictionary[cardId].questStepTask.description);

        //перебор массива с кнопками для назначения текста и id
        for (int i = 0; i < _buttons.Length; i++)
        {
            if (_cardDictionary[cardId].questButtonsId[i] == 0)
            {
                _buttons[i].gameObject.SetActive(false);
            }
            else
            {
                _buttons[i].gameObject.SetActive(true);
            }

            _buttons[i].StoreId(_cardDictionary[cardId].questButtonsId[i]);
            _buttons[i].ShowText(_cardDictionary[cardId].questButtonsText[i]);
        }

        if (_cardDictionary[cardId].questMainButton == 0)
        {
            _mainButton.gameObject.SetActive(false);
        }
        else
        {
            _mainButton.gameObject.SetActive(true);
        }

        _mainButton.StoreId(_cardDictionary[cardId].questMainButton);
    }
}