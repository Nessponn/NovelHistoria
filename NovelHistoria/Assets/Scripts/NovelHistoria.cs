using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;//ボタンと画面タッチにコンフリクトを生まないため
using TMPro;


public abstract class NovelHistoria : MonoBehaviour
{
    //全てのシステムの統括部門。全ての入力を受け付け、また、全ての出力を決定する場所でもある

    [Space]
    //ウィンドウオプション（改訂版）
    public Image WindowSize;//ウィンドウサイズの値
    public Image WindowAlpha;//ウィンドウの透明度の値（フォントは含まない）
    public CanvasGroup WindowCanvas;//ウィンドウそのもの
    public RectTransform MessageFont;//メッセージのフォント
    public CanvasGroup TextWindow;//テキストウィンドウ（フォントは含まない）

    [Space]
    //ノベルテキスト用
    //private Text[] NovelText;//使用するフォントオブジェクトのスタック専用
    //private int TextNumber;//現在の文字の位置番号　格納変数
    private bool Talking;//会話中かどうか
    private bool Pressed;//次に送るまでの処理
    //[System.NonSerialized] public bool Paused;//ポーズ中
    //[System.NonSerialized] public bool HistoriaMODE;//１文字づつ追加か一気に追加か

    [Space]
    public TextMeshProUGUI MessageFont_Number;
    public TextMeshProUGUI TextWindow_Number;

    // Update is called once per frame
    void Update()
    {

        if (Talking)
        {
            MessageFont_Number.text = "" + (int)(WindowSize.fillAmount * 100);
            TextWindow_Number.text = "" + (int)(WindowAlpha.fillAmount * 100);

            MessageFont.localScale = Vector3.Lerp(new Vector3(0.72f, 0.735f, 1), new Vector3(0.9f, 0.915f, 1), WindowSize.fillAmount);
            MessageFont.localPosition = Vector3.Lerp(new Vector3(0, -200, 0), new Vector3(0, -175, 0), WindowSize.fillAmount);
            TextWindow.gameObject.GetComponent<RectTransform>().localScale = Vector3.Lerp(new Vector3(8, 1.5f, 1), new Vector3(10, 2, 1), WindowSize.fillAmount);
            TextWindow.gameObject.GetComponent<RectTransform>().localPosition = Vector3.Lerp(new Vector3(0, -200, 0), new Vector3(0, -175, 0), WindowSize.fillAmount);
            TextWindow.alpha = 1 - WindowAlpha.fillAmount;
        }

        //ボタンが押された場合、クリックでの会話進行は無効
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Pressed = true;
        }
    }
}
