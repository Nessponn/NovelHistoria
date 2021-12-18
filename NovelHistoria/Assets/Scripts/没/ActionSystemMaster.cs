using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;//ボタンと画面タッチにコンフリクトを生まないため
using TMPro;

public class ActionSystemMaster : SingletonMonoBehaviourFast<ActionSystemMaster>
{
    #region ActionSystem Method

    public Camera camera;

    //Sequence ActionAnimation;

    private bool Animating;//アニメーション中はtrue

    // Start is called before the first frame update
    void Start()
    {
        //画面アニメーション用のやつ
        //ActionAnimation = DOTween.Sequence();
    }

    private void Update()
    {
        //カメラポジション登録
        position = camera.transform.position;
    }

    private Vector3 position;//カメラのポジション
    private float time;//スタックする偏移時間

    public void ActionStart(Transform pos, float time)
    {
        camera.transform.DOMove(pos.position, time);

        //偏移時間の上書き
        this.time = time;
    }

    public void ActionOver()
    {
        //元の位置に戻す
        camera.transform.DOMove(position, time);
    }

    #endregion
}
