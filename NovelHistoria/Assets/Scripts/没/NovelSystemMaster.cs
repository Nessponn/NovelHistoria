using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;//ボタンと画面タッチにコンフリクトを生まないため
using TMPro;


[RequireComponent(typeof(ActionSystemMaster))]//ついていなかった場合は自動的に適用
public class NovelSystemMaster : SingletonMonoBehaviourFast<NovelSystemMaster>
{
    //このスクリプトは、NovelTaker(仮称)の内容を一つのウィンドウに表示するための処理を行う場所
    //また、ウィンドウやテキストのSetting等の設定、反映も行う。
    private Text[] NovelText;//使用するフォントオブジェクトのスタック専用
    private int TextNumber;//現在の文字の位置番号　格納変数
    private bool Pressed;//次に送るまでの処理
    [System.NonSerialized] public bool Paused;//ポーズ中
    [System.NonSerialized] public bool HistoriaMODE;//１文字づつ追加か一気に追加か

    private bool Talking;//会話中かどうか
    #region NovelSystemManager Core
    [Space]
    public CanvasGroup WindowCanvas;//ウィンドウそのもの

    [Space]
    //ノベルテキスト用
   
    

    [Space]
    public TextMeshProUGUI MessageFont_Number;
    public TextMeshProUGUI TextWindow_Number;

    
   
    #endregion

    #region NovelSystem Method

    private int FontNumber;
    private NovelClass[] NovelTexts;
    private int Novelnumber;//現在のテキストの番号


    public void NovelStart(NovelClass[] Texts,Text[] Fonts,int DebugNovel)
    {
        #region NovelSystem

        //ここからテキストの配列を取り出し、ステータスを下記のコルーチンで発火させる
        NovelTexts = Texts;
        Novelnumber = DebugNovel;

        //使用するテキストフォントをNovelTextに適用する
        NovelText = Fonts;

        //再度表示前に文字の内容を一度リセット
        for (int i = 0; i < NovelText.Length; i++)
        {
            NovelText[i].text = "";
        }

        //必要な情報をもとにノベルスタート
        DOVirtual.DelayedCall(1, () =>
        {
            NovelStart();
        }
        );
        #endregion

        #region ActionSystem



        #endregion
    }



    //オーバーライド。１つのオブジェクトから２回目以降の会話を実行するために使用
    //Managerでのみ使用するために、修飾子はprivate
    private void NovelStart()
    {
        Pressed = false;
        StartCoroutine(NovelTake(NovelTexts[Novelnumber].NovelParameter.Text, NovelTexts[Novelnumber].NovelParameter.ResidualText,NovelTexts[Novelnumber].ActionParameter));
    }

    private void NovelStart(NovelClass[] NC)
    {
        Pressed = false;
        StartCoroutine(SystemStart(NC, NC[Novelnumber].NovelParameter.ResidualText, NC[Novelnumber].ActionParameter));
    }

    //
    private void NovelOver()
    {
        //会話の終了
        Talking = false;

        WindowCanvas.DOFade(0, 1f);
    }

    //一つの命令を実行
    public IEnumerator SystemStart(NovelClass[] NC, bool ResidualText, ActionParameter AP)
    {
        //一つのノベルシーンシステムに付き

        //ノベルシステムの開始
        StartCoroutine(NovelTake(NovelTexts[Novelnumber].NovelParameter.Text, NovelTexts[Novelnumber].NovelParameter.ResidualText, NovelTexts[Novelnumber].ActionParameter));
        yield return null;


    }

    public IEnumerator NovelSystem(NovelClass[] NC,int Number)
    {

        yield return null;
    }

    public IEnumerator NovelTake(NovelClass[] NC, int Number)
    {

        yield return null;
    }

        //全てのシステムを統括し、様々な処理を行う
        public IEnumerator NovelTake(string NovelTextContent ,bool ResidualText,ActionParameter AP)
    {
        //何も入力されていなければ、ここで処理を終了
        if (NovelTextContent == "") yield break;
        
        //ウィンドウの表示
        WindowCanvas.DOFade(1, 1f);

        //会話の開始
        Talking = true;

        //次のテキストを引き継ぐのでなければ
        //基本テキストの内容をからっぽにする
        if (!ResidualText)
        {
            for(int i = 0;i < NovelText.Length; i++)
            {
                NovelText[i].text = "";
            }
            //ヒストリーのプレハブを生成する
            HistoryAdd(NovelText);
        }
        //読み込む文字の位置を最初に戻す
        TextNumber = 0;

        //フォントフラグの初期化
        FontNumber = 0;

        //待機時間の計算

        
        

        //テキストを一文字づつ表示していく
        while (TextNumber < NovelTextContent.Length)
        {
            //フォントや色の違うものを差し込むには
            //それこそText自体を違うオブジェクトで存在させる必要がある
            //コマンド入力位置で差し込む

            //ヒストリー選択中やオプション中はポーズ処理を行う
            yield return new WaitUntil(() => !Paused);

            //アクション入力命令があれば実行する
            if(AP.pos != null)ActionSystemMaster.Instance.ActionStart(AP.pos, AP.TransTime);

            //コマンド入力の確認
            if(NovelTextContent[TextNumber].ToString() == "'")
            {
                TextNumber++;//一文字先を参照
                //もう一度コマンド入力を確認するまで続ける
                while (NovelTextContent[TextNumber].ToString() != "'")
                {
                    if (NovelTextContent[TextNumber].ToString() == "F")
                    {
                        TextNumber++;//一文字先を参照

                        //指定の数値をFontNumberに設定する
                        FontNumber = int.Parse(NovelTextContent[TextNumber].ToString());

                        TextNumber++;//一文字先を参照(この時点で、次の命令もしくはコマンド入力終了の文字が来る)
                    }
                }

                //while文脱出後
                TextNumber++;//一文字先を参照(コマンド終了用の'を参照しないようにするため)
            }

            for (int i = 0; i < NovelText.Length; i++)
            {
                if(FontNumber == i)
                {
                    //改行命令は、他のフォント文には適用されないため、ここで自前に実装する
                    
                    //１文字追加
                    TextAdd(NovelText[i], NovelTextContent[TextNumber], i);
                }
                else
                {
                    //改行されたときにバグって一文字空白があく可能性が高い←やっぱりそうだった！！！！！
                    //「、」を入力した時もコマンド空白バグが発生したが、改行の時に空白は明けないように設定したら一緒に直ってたので、もしかすると句点には改行コードと同じコードが用いられている？？？（よくわからん）
                    if (NovelTextContent[TextNumber] == '\n')
                    {
                        for (int j = 0; j < NovelText.Length; j++)
                        {
                            //改行追加
                            if (FontNumber != j) TextAdd(NovelText[j], '\n', j);
                        }
                    }
                    else
                    {
                        //空白を１文字追加
                        TextAdd(NovelText[i], "　", i);
                    }
                }
            }
            TextNumber++;//追加したら1増加

            if(!Pressed)yield return new WaitForSeconds(0.02f);
            
        }

        Pressed = false;

        yield return new WaitUntil(() => Pressed);

        //クリックで先に進む

        //全ての入力が終わると
        //テキストウィンドウがフェードアウトする
        //そうでなければ次のテキストを表示する

        if (NovelTexts.Length - 1 > Novelnumber)
        {
            //まだメッセージが残っている場合
            Novelnumber++;
            NovelStart();
        }
        else
        {
            //メッセージが残っていない場合
            NovelOver();
        }
    }
    public void HistoryAdd(Text[] Tx)
    {
        NovelHistoria_Setting.Instance.HistoryTake(Tx);
    }

    public void TextAdd(Text tx, char cx, int FontNumber)
    {
        tx.text += cx;
        NovelHistoria_Setting.Instance.HistoryAdd(cx, FontNumber);
    }
    public void TextAdd(Text tx,string cx,int FontNumber)
    {
        tx.text += cx;
        NovelHistoria_Setting.Instance.HistoryAdd(cx, FontNumber);
    }
    #endregion

    
}
