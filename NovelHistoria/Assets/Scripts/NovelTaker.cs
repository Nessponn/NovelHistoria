using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NovelTaker : MonoBehaviour
{
    [Space]
    public int NovelNumber_Debug;//デバッグ用のノベル番号指定。必要なければprivateか消してしまっても問題はない
    [Space]
    public NovelClass[] NS;//ノベルテキスト本体
    [Space]
    public Text[] Fonts;//使用するテキスト。テキスト自体はゲームオブジェクトとして制御できる形でなければならない

    // Start is called before the first frame update
    void Start()
    {
        //データの取得
        NovelTaker DATA = gameObject.GetComponent<NovelTaker>();

        //データをNovelHistoriaに送る
        NovelHistoria_Mk3.Historia.HistoriaSystem_Start(DATA);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

