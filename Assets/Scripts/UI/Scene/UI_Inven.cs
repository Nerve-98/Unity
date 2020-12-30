using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inven : UI_Scene
{
    enum GameObjects
    {
        GridPanel
    }

    void Start()
    {

        Init();




    }


    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));

        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);


        foreach (Transform child in gridPanel.transform)
            Manager.Resource.Destroy(child.gameObject);

        for (int i = 0; i < 8; i++)
        {
            GameObject item = Manager.Resource.Instantiate("UI/Scene/UI_Inven_Item");
            item.transform.SetParent(gridPanel.transform);

            UI_Inven_Item invenitem = Util.GetOrAddComponent<UI_Inven_Item>(item);
            invenitem.SetInfo($"집행검{i}번");




        }




    }









}
