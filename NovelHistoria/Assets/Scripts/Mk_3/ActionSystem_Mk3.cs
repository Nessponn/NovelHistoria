using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ActionSystem_Mk3 : SingletonMonoBehaviourFast<ActionSystem_Mk3>
{
    GameObject camera;

    Vector3 STARTpos;
    float Transtime;

    // Start is called before the first frame update
    void Start()
    {
        //カメラのオブジェクトを取得（カメラには元々MainCameraタグがついている）
        camera = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    public void Setup()
    {

    }

    public void Move(NovelTaker DATA, int Number)
    {
        //偏移先が無ければ処理終了
        if (DATA.NS[Number].ActionParameter.pos == null) return;

        STARTpos = camera.transform.position;
        Transtime = DATA.NS[Number].ActionParameter.TransTime;
        Vector3 ENDpos = DATA.NS[Number].ActionParameter.pos.position;


        camera.transform.DOMove(ENDpos, Transtime);
    }

    public void While()
    {

    }

    public void Over(NovelTaker DATA)
    {
        camera.transform.DOMove(STARTpos, Transtime);
    }
}
