﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{


    enum Buttons
    {
        PointButton
    }

    enum Texts
    {
        PointText,
        ScoreText
    }
    enum GameObjects
    {
        TestObject
    }

    enum Images
    {
        ItemIcon
    }



    private void Start()
    {
        Init();
        /*
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));


        // Get<Text>((int)Texts.ScoreText).text = "Bind Test";


        GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(OnButtonClicked);
        
        
        GameObject go = GetImage((int)Images.ItemIcon).gameObject;

        AddUIEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);
        //UI_EventHandler evt = go.GetComponent<UI_EventHandler>();
        //evt.OnDragHandler += ((PointerEventData data) => { evt.gameObject.transform.position = data.position; });
        */

    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));


        // Get<Text>((int)Texts.ScoreText).text = "Bind Test";


        GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(OnButtonClicked);


        GameObject go = GetImage((int)Images.ItemIcon).gameObject;

        AddUIEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);
        //UI_EventHandler evt = go.GetComponent<UI_EventHandler>();
        //evt.OnDragHandler += ((PointerEventData data) => { evt.gameObject.transform.position = data.position; });

    }

    int _score = 0;
    public void OnButtonClicked(PointerEventData data)
    {
        _score++;
        Get<Text>((int)Texts.ScoreText).text = $"점수 : {_score}점";
        //_text.text = $"점수 : {_score}";
    }

}
