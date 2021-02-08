using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class TestComponent : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

        MessageBox.Instance.DeployMessage(new GameMessage("Добро пожаловать", "Приветствую тебя, юный волшебник. Добро пожаловать в башню, здесь начнутся твои приключения, полные загадок, тайн и несметных сокровищ!"));

        MessageBox.Instance.DeployMessage(new GameMessage("Введение","В этой игре ты можешь управлять целой партией героев, отправляя их в древние, опасные земли! Следи за странствием каждого из героев в его личном журнале и будь внимателен, без твоего присмотра герои быстро сгинут. Если твой герой успешно вернется в башню, то с собой он принесет множество полезных ресурсов!"));

        MessageBox.Instance.DeployMessage(new GameMessage("Обучение", "Отправь своего первого героя в один из порталов, а затем вернись в игру позже, чтобы узнать что он повстречал."));



    }
}
