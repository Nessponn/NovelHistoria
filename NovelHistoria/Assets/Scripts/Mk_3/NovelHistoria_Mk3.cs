using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;//ボタンと画面タッチにコンフリクトを生まないため
using TMPro;


public class NovelHistoria_Mk3 : MonoBehaviour
{
	#region SingletonArea

	private static NovelHistoria_Mk3 historia;
	public static NovelHistoria_Mk3 Historia
	{
		get
		{
			if (null == historia)
			{
				historia = (NovelHistoria_Mk3)FindObjectOfType(typeof(NovelHistoria_Mk3));
				if (null == historia) Debug.LogError(" Data Instance Error ");
			}
			return historia;
		}
	}

	void Awake()
	{
		GameObject[] obj = GameObject.FindGameObjectsWithTag("GameController"); //タグで判別
		if (1 < obj.Length) Destroy(gameObject);
		else DontDestroyOnLoad(gameObject);
	}


    #endregion

    [Space]
    //ウィンドウオプション（改訂版）
    public Image WindowSize;//ウィンドウサイズの値
    public Image WindowAlpha;//ウィンドウの透明度の値（フォントは含まない）
    public CanvasGroup WindowCanvas;//ウィンドウそのもの
    public RectTransform MessageFont;//メッセージのフォント
    public CanvasGroup TextWindow;//テキストウィンドウ（フォントは含まない）

    [Space]
    //ノベルテキスト用
    [System.NonSerialized] public bool Talking;//会話中かどうか
    [System.NonSerialized] public bool Pressed;//次に送るまでの処理
    [System.NonSerialized] public bool Paused;//ポーズ中
    [System.NonSerialized] public bool HistoriaMODE;//１文字づつ追加か一気に追加か

    [Space]
    public TextMeshProUGUI MessageFont_Number;
    public TextMeshProUGUI TextWindow_Number;

    // Start is called before the first frame update
    void Start()
    {
        TextWindow.alpha = 1 - WindowAlpha.fillAmount;
        NovelSafetySystem.Reset();
    }

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


    private List<NovelTaker> StackDATA = new List<NovelTaker>();
    
    public void HistoriaSystem_Start(NovelTaker DATA)
    {
        //すでに会話が開始されていた場合、要素をスタックに追加するのみで処理を終える
        if(StackDATA.Count > 0)
        {
            //Debug.Log("既に会話は開始されています");
            StackDATA.Push(DATA);
            return;
        }
        //そうでなければ、加えて会話開始処理を行う
        StackDATA.Push(DATA);

        HistoriaSystem_Setup(StackDATA[0]);
    }

    //データ処理開始
    //★つけたところは後で設定一秒のところを任意の秒数に変えるように変更する
    private void HistoriaSystem_Setup(NovelTaker DATA)
    {
        //各種システムのSetupメソッドにアクセスし、Setupする
        //NovelSystemのSetUp
        NovelSystem_Mk3.Instance.Setup(DATA);


        //システムの開始 番号指定可
        StartCoroutine(HistoriaSystem_While(DATA, 0));

    }

    //継続的なデータ処理
    private IEnumerator HistoriaSystem_While(NovelTaker DATA, int Number)
    {
        Pressed = false;

        //会話システムにデータを投下
        StartCoroutine(NovelSystem_Mk3.Instance.While(DATA,Number));

        //アクションシステムにデータを投下
        ActionSystem_Mk3.Instance.Move(DATA, Number);


        //ちゃんと全てのイベントが終わったかを見る
        yield return new WaitUntil(() => NovelSafetySystem.NovelSafety && Pressed);

        //SafyteSystemのステータスをリセット
        NovelSafetySystem.Reset();

        //クリックされたら次に進む
        Number++;

        if(DATA.NS.Length > Number)
        {
            StartCoroutine(HistoriaSystem_While(DATA, Number));
        }
        else
        {
            HistoriaSystem_Over(DATA);
        }
    }

    private void HistoriaSystem_Over(NovelTaker DATA)
    {
        StackDATA.Pop();

        //まだStackDATAにデータが残っているならば、そのデータを参照し、再びSetupへ

        if(StackDATA.Count > 0)
        {
            HistoriaSystem_Setup(StackDATA[0]);

            //一部機能はOverでいったんリセット
            ActionSystem_Mk3.Instance.Over(DATA);

            return;
        }
        //完全にデータを消費したらOver

        NovelSystem_Mk3.Instance.Over();
        ActionSystem_Mk3.Instance.Over(DATA);

        
    }
}

//ノベルや画面偏移のアニメーションにコンフリクトを起こさないためのクラス
public static class NovelSafetySystem
{
    public static bool NovelSafety;
    public static bool ActionSafety;

    public static bool Safety()
    {
        return NovelSafety && ActionSafety;
    }

    public static void Reset()
    {
        NovelSafety = false;
        ActionSafety = false;
    }
}

public static class ListExtensions
{
    /// <summary>
    /// 先頭にあるオブジェクトを削除します
    /// </summary>
    public static void Pop<T>(this IList<T> self)
    {
        self.RemoveAt(0);
        //Debug.Log("データを消去");
    }

    /// <summary>
    /// 末尾にオブジェクトを追加します
    /// </summary>
    public static void Push<T>(this IList<T> self, T item)
    {
        self.Insert(self.Count, item);
        //Debug.Log("データを追加");
    }

    /// <summary>
    /// 先頭にあるオブジェクトを削除し、返します
    /// </summary>
    public static T RetPop<T>(this IList<T> self)
    {
        var result = self[0];
        self.RemoveAt(0);
        return result;
    }

    /// <summary>
    /// 末尾にオブジェクトを追加します
    /// </summary>
    public static T RetPush<T>(this IList<T> self, T item)
    {
        var result = self[0];
        self.Insert(0, item);
        return result;
    }
}