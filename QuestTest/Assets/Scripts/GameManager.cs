using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Button _mainButton;
    [SerializeField] Button[] _buttons;

    [SerializeField] int[] _card_id;

    [SerializeField] DrawBackground _drawSprite;
    [SerializeField] DrawTextModule _drawTextModule;

    QuestStepTask[] _questStepTask;
    EdgeTask[] _edgeTask;

    Text _buttonText;

    int source_id;
    int target_id;

    int i = 0; //заготовка для сохранения    

    void Start()
    {
        _questStepTask = GetComponent<QuestStepTaskParser>().questStepTaskArray;
        _edgeTask = GetComponent<EdgeTaskParser>().edgeTaskArray;

        ButtonsSetFalse();
        OnStart();
    }

    void OnStart()
    {
        if (i <= _edgeTask.Length)
        {
            source_id = _edgeTask[i].source_id;
            target_id = _edgeTask[i].target_id;

            _mainButton.onClick.RemoveAllListeners();
            _mainButton.onClick.AddListener(delegate { OnButtonPress(target_id); });

            ShowCard();
        }
    }

    public void OnButtonPress(int target_id)
    {
        source_id = target_id;

        for (int i = 0; i < _edgeTask.Length; i++)
        {
            if (source_id == _edgeTask[i].source_id)
            {
                target_id = _edgeTask[i].target_id;
            }
        }

        ManageButtonsListeners();
        ShowCard();
    }

    void ShowCard()
    {
        for (int i = 0; i < _questStepTask.Length; i++)
        {
            if (_questStepTask[i].id == source_id)
            {
                _drawTextModule.DrawModule(_questStepTask[i].visualisations[0].id);

                _drawTextModule.DrawText(_questStepTask[i].description);

                _drawSprite.Draw(_questStepTask[i].card.image.file_id);
            }
        }
    }

    void ManageButtonsListeners()
    {
        int k = 0;

        for (int i = 0; i < _edgeTask.Length; i++)
        {
            if (_edgeTask[i].source_id == source_id)
            {
                for (int j = 0; j < _questStepTask.Length; j++)
                {
                    if (_edgeTask[i].target_id == _questStepTask[j].id)
                    {
                        if (_questStepTask[j].choice_description != "")
                        {
                            int l = k;

                            _buttons[k].gameObject.SetActive(true);
                            _mainButton.gameObject.SetActive(false);

                            _buttons[k].onClick.RemoveAllListeners();
                            _mainButton.onClick.RemoveAllListeners();

                            _buttonText = _buttons[k].GetComponentInChildren<Text>();
                            _buttonText.text = _questStepTask[j].choice_description;                                

                            _card_id[k] = _edgeTask[i].target_id;
                            _buttons[k].onClick.AddListener(delegate { OnButtonPress(_card_id[l]); });                            
                        }
                        else
                        {
                            _mainButton.gameObject.SetActive(true);
                            ButtonsSetFalse();

                            _mainButton.onClick.RemoveAllListeners();
                            _mainButton.onClick.AddListener(delegate { OnButtonPress(target_id); });
                        }

                        k ++;
                    }
                }
            }
        }
    }

    void ButtonsSetFalse()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].gameObject.SetActive(false);
        }
    }
}
