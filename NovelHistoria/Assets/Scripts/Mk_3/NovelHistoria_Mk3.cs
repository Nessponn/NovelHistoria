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

    //データ処理開始
    public void HistoriaSystem_Start(NovelTaker DATA)
    {
        //ウィンドウの表示
        WindowCanvas.DOFade(1, 1f);

        //各種システムのSetupメソッドにアクセスし、Setupする
        //NovelSystemのSetUp
        NovelSystem_Mk3.Instance.Setup(DATA);

        DOVirtual.DelayedCall(1, () =>
        {
            //システムの開始 番号指定可
            StartCoroutine(HistoriaSystem_While(DATA, 0));

            //会話の開始
            Talking = true;
        }
        );
        
    }

    //継続的なデータ処理
    private IEnumerator HistoriaSystem_While(NovelTaker DATA, int Number)
    {
        Pressed = false;

        //会話システムにデータを投下
        StartCoroutine(NovelSystem_Mk3.Instance.While(DATA,Number));

        //アクションシステムにデータを投下
        //ActionSystem_Mk2.Instance.ActionStart(DATA);

        yield return new WaitUntil(() => Pressed);

        //クリックされたら次に進む
        Number++;

        if(DATA.NS.Length > Number)
        {
            StartCoroutine(HistoriaSystem_While(DATA, Number));
        }
        else
        {
            HistoriaSystem_Over();
        }
    }

    private void HistoriaSystem_Over()
    {
        NovelSystem_Mk3.Instance.Over();
    }
}
