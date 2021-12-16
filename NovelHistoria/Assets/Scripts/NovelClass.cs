using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NovelClass
{
    //基本ノベルパラメータ
    public NovelParameter NovelParameter;

    [Space]
    //アクションゲーム向けパラメータ
    public ActionParameter ActionParameter;
}

[System.Serializable]
public class NovelParameter
{
    public string Name;//ネームテキスト
    [TextArea(3, 10)] public string Text;//テキスト本文
    public GameObject ChoicesObject;//選択肢オブジェクト
    public bool ResidualText;//このテキストをクリックしても残留させたままにする
    public float InterbalTime = 0.02f;//会話文全表示に所要する時間(デフォルトは0.02秒)
}

[System.Serializable]
public class ActionParameter
{
    public Transform pos;//スクロール先の座標
    public float TransTime;//座標に移動するまでに要する所要時間
    [Range(0, 1)] public float Timing;//会話中のどの比率のタイミングでアクションを発火させるか
    public bool DoAfterTalk;//会話終了後に実行
}