using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;//ボタンと画面タッチにコンフリクトを生まないため
using TMPro;

public class NovelSystem_Mk2 : SingletonNoveler<NovelSystem_Mk2>
{

    private Text[] NovelText;//使用するフォントオブジェクトのスタック専用
    private int TextNumber;//現在の文字の位置番号　格納変数

    private int FontNumber;
    private NovelClass[] NovelTexts;
    private int Novelnumber;//現在のテキストの番号

/*
    public void NovelStart(NovelClass[] Texts, Text[] Fonts, int DebugNovel)
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
    }*/

    /// <summary>
    /// 
    /// 要件
    /// 
    /// NovelHistoriaから送信されたデータのうち
    /// ノベルデータのみを処理するためのクラスである。
    /// While処理は
    /// 
    /// </summary>




    //オーバーライド。１つのオブジェクトから２回目以降の会話を実行するために使用
    //Managerでのみ使用するために、修飾子はprivate
   /* public void NovelStart()
    {
        Pressed = false;
        StartCoroutine(NovelTake(NovelTexts[Novelnumber].NovelParameter.Text, NovelTexts[Novelnumber].NovelParameter.ResidualText, NovelTexts[Novelnumber].ActionParameter));
    }*/

    /*
    public void NovelStart(NovelClass[] DATA)
    {
        Pressed = false;
        StartCoroutine(SystemStart(DATA, DATA[Novelnumber].NovelParameter.ResidualText, DATA[Novelnumber].ActionParameter));
    }
    */

    //会話のシーンが開始された直後、会話データがここにもってこられる
    public void Setup(NovelTaker DATA)
    {
        //ここからテキストの配列を取り出し、ステータスを下記のコルーチンで発火させる
        //NovelTexts = DATA.NC;
        Novelnumber = DATA.NovelNumber_Debug;

        //使用するテキストフォントをNovelTextに適用する
        NovelText = DATA.Fonts;

        //再度表示前に文字の内容を一度リセット
        for (int i = 0; i < NovelText.Length; i++)
        {
            NovelText[i].text = "";
        }

        //スタート処理はNovelHistoria側で行うため、個々でのスタート処理は行わない
        /*//必要な情報をもとにノベルスタート
        DOVirtual.DelayedCall(1, () =>
        {
            Pressed = false;
            StartCoroutine(Novel_While(DATA));
        }
        );*/

    }

    public IEnumerator While(NovelTaker DATA, int Number)
    {
        //何も入力されていなければ、ここで処理を終了
        if (DATA.NS[Number].NovelParameter.Text == "") yield break;

        //ウィンドウの表示
        WindowCanvas.DOFade(1, 1f);

        //会話の開始
        Talking = true;

        //次のテキストを引き継ぐのでなければ
        //基本テキストの内容をからっぽにする
        if (!DATA.NS[Number].NovelParameter.ResidualText)
        {
            for (int i = 0; i < NovelText.Length; i++)
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
        while (TextNumber < DATA.NS[Number].NovelParameter.Text.Length)
        {
            //フォントや色の違うものを差し込むには
            //それこそText自体を違うオブジェクトで存在させる必要がある
            //コマンド入力位置で差し込む

            //ヒストリー選択中やオプション中はポーズ処理を行う
            yield return new WaitUntil(() => !Paused);

            //アクション入力命令があれば実行する
            //if (AP.pos != null) ActionSystemMaster.Instance.ActionStart(AP.pos, AP.TransTime);

            //コマンド入力の確認
            if (DATA.NS[Number].NovelParameter.Text[TextNumber].ToString() == "'")
            {
                TextNumber++;//一文字先を参照
                //もう一度コマンド入力を確認するまで続ける
                while (DATA.NS[Number].NovelParameter.Text[TextNumber].ToString() != "'")
                {
                    if (DATA.NS[Number].NovelParameter.Text[TextNumber].ToString() == "F")
                    {
                        TextNumber++;//一文字先を参照

                        //指定の数値をFontNumberに設定する
                        FontNumber = int.Parse(DATA.NS[Number].NovelParameter.Text[TextNumber].ToString());

                        TextNumber++;//一文字先を参照(この時点で、次の命令もしくはコマンド入力終了の文字が来る)
                    }
                }

                //while文脱出後
                TextNumber++;//一文字先を参照(コマンド終了用の'を参照しないようにするため)
            }

            for (int i = 0; i < NovelText.Length; i++)
            {
                if (FontNumber == i)
                {
                    //改行命令は、他のフォント文には適用されないため、ここで自前に実装する

                    //１文字追加
                    TextAdd(NovelText[i], DATA.NS[Number].NovelParameter.Text[TextNumber], i);
                }
                else
                {
                    //改行されたときにバグって一文字空白があく可能性が高い←やっぱりそうだった！！！！！
                    //「、」を入力した時もコマンド空白バグが発生したが、改行の時に空白は明けないように設定したら一緒に直ってたので、もしかすると句点には改行コードと同じコードが用いられている？？？（よくわからん）
                    if (DATA.NS[Number].NovelParameter.Text[TextNumber] == '\n')
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

            //if (!Pressed) 
                yield return new WaitForSeconds(0.02f);

        }

        //Pressed = false;

        //yield return new WaitUntil(() => Pressed);

        //クリックで先に進む

        //全ての入力が終わると
        //テキストウィンドウがフェードアウトする
        //そうでなければ次のテキストを表示する

        //NovelHistoria側でwhile命令を出すため、ここでの処理は必要ない
        /*
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
        }*/
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
    public void TextAdd(Text tx, string cx, int FontNumber)
    {
        tx.text += cx;
        NovelHistoria_Setting.Instance.HistoryAdd(cx, FontNumber);
    }

}
   