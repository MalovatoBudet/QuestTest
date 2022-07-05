using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct QuestCard
{
    public QuestStepTask questStepTask;

    public int questMainButton;

    public int[] questButtonsId;
    public string[] questButtonsText;
}

public class CardsCreator : MonoBehaviour
{
    QuestStepTask[] _questStepTask;
    EdgeTask[] _edgeTask;

    QuestCard _questCard;
    public Dictionary<int, QuestCard> _cardDictionary = new Dictionary<int, QuestCard>();

    void Start()
    {
        _questStepTask = GetComponent<QuestStepTaskParser>().questStepTaskArray;
        _edgeTask = GetComponent<EdgeTaskParser>().edgeTaskArray;

        //заполнить словарь (карточка + "кнопки")
        for (int i = 0; i < _questStepTask.Length; i++)
        {
            _questCard.questStepTask = _questStepTask[i];
            _questCard.questButtonsId = new int[2];
            _questCard.questButtonsText = new string[2];
            _questCard.questMainButton = 0;

            int z = 0;

            //заполнить информацию для передачи кнопкам
            for (int j = 0; j < _edgeTask.Length; j++)
            {
                if (_edgeTask[j].source_id == _questCard.questStepTask.id)
                {
                    for (int k = 0; k < _questStepTask.Length; k++)
                    {
                        if (_edgeTask[j].target_id == _questStepTask[k].id)
                        {
                            if (_questStepTask[k].choice_description != "")
                            {
                                int l = z;
                                _questCard.questButtonsId[l] = _questStepTask[k].id;
                                _questCard.questButtonsText[l] = _questStepTask[k].choice_description;

                                z++;
                            }
                            else
                            {
                                _questCard.questMainButton = _questStepTask[k].id;
                            }
                        }
                    }
                }
            }
            _cardDictionary.Add(_questStepTask[i].id, _questCard);
        }
    }
}