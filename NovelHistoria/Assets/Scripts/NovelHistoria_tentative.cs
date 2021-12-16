using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;//�{�^���Ɖ�ʃ^�b�`�ɃR���t���N�g�𐶂܂Ȃ�����
using TMPro;

public class NovelHistoria_tentative : MonoBehaviour
{
    //���̃X�N���v�g�́ANovelTaker(����)�̓��e����̃E�B���h�E�ɕ\�����邽�߂̏������s���ꏊ
    //�܂��A�E�B���h�E��e�L�X�g��Setting���̐ݒ�A���f���s���B

    #region NovelSystemManager Core
    [Space]
    //�E�B���h�E�I�v�V�����i�����Łj
    public Image WindowSize;//�E�B���h�E�T�C�Y�̒l
    public Image WindowAlpha;//�E�B���h�E�̓����x�̒l�i�t�H���g�͊܂܂Ȃ��j
    public CanvasGroup WindowCanvas;//�E�B���h�E���̂���
    public RectTransform MessageFont;//���b�Z�[�W�̃t�H���g
    public CanvasGroup TextWindow;//�e�L�X�g�E�B���h�E�i�t�H���g�͊܂܂Ȃ��j

    [Space]
    //�m�x���e�L�X�g�p
    private Text[] NovelText;//�g�p����t�H���g�I�u�W�F�N�g�̃X�^�b�N��p
    private int TextNumber;//���݂̕����̈ʒu�ԍ��@�i�[�ϐ�
    private bool Talking;//��b�����ǂ���
    private bool Pressed;//���ɑ���܂ł̏���
    [System.NonSerialized] public bool Paused;//�|�[�Y��
    [System.NonSerialized] public bool HistoriaMODE;//�P�����Âǉ�����C�ɒǉ���

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

        //�{�^���������ꂽ�ꍇ�A�N���b�N�ł̉�b�i�s�͖���
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Pressed = true;
        }
    }

    #endregion

    #region NovelSystem Method

    private int FontNumber;
    private NovelClass[] NovelTexts;
    private int Novelnumber;//���݂̃e�L�X�g�̔ԍ�


    public void NovelStart(NovelClass[] Texts, Text[] Fonts, int DebugNovel)
    {
        #region NovelSystem

        //��������e�L�X�g�̔z������o���A�X�e�[�^�X�����L�̃R���[�`���Ŕ��΂�����
        NovelTexts = Texts;
        Novelnumber = DebugNovel;

        //�g�p����e�L�X�g�t�H���g��NovelText�ɓK�p����
        NovelText = Fonts;

        //�ēx�\���O�ɕ����̓��e����x���Z�b�g
        for (int i = 0; i < NovelText.Length; i++)
        {
            NovelText[i].text = "";
        }

        //�K�v�ȏ������ƂɃm�x���X�^�[�g
        DOVirtual.DelayedCall(1, () =>
        {
            NovelStart();
        }
        );
        #endregion

        #region ActionSystem



        #endregion
    }



    //�I�[�o�[���C�h�B�P�̃I�u�W�F�N�g����Q��ڈȍ~�̉�b�����s���邽�߂Ɏg�p
    //Manager�ł̂ݎg�p���邽�߂ɁA�C���q��private
    private void NovelStart()
    {
        Pressed = false;
        StartCoroutine(NovelTake(NovelTexts[Novelnumber].NovelParameter.Text, NovelTexts[Novelnumber].NovelParameter.ResidualText, NovelTexts[Novelnumber].ActionParameter));
    }

    private void NovelStart(NovelClass[] NC)
    {
        Pressed = false;
        StartCoroutine(SystemTake(NC, NC[Novelnumber].NovelParameter.ResidualText, NC[Novelnumber].ActionParameter));
    }

    //
    private void NovelOver()
    {
        //��b�̏I��
        Talking = false;

        WindowCanvas.DOFade(0, 1f);
    }
    public IEnumerator SystemTake(NovelClass[] NC, bool ResidualText, ActionParameter AP)
    {
        //��x���点��΁A���Ƃ͊e�R���[�`���Ń��[�v���Ă����
        StartCoroutine(NovelTake(NovelTexts[Novelnumber].NovelParameter.Text, NovelTexts[Novelnumber].NovelParameter.ResidualText, NovelTexts[Novelnumber].ActionParameter));
        yield return null;


    }
    //�S�ẴV�X�e���𓝊����A�l�X�ȏ������s��
    public IEnumerator NovelTake(string NovelTextContent, bool ResidualText, ActionParameter AP)
    {
        //�������͂���Ă��Ȃ���΁A�����ŏ������I��
        if (NovelTextContent == "") yield break;

        //�E�B���h�E�̕\��
        WindowCanvas.DOFade(1, 1f);

        //��b�̊J�n
        Talking = true;

        //���̃e�L�X�g�������p���̂łȂ����
        //��{�e�L�X�g�̓��e��������ۂɂ���
        if (!ResidualText)
        {
            for (int i = 0; i < NovelText.Length; i++)
            {
                NovelText[i].text = "";
            }
            //�q�X�g���[�̃v���n�u�𐶐�����
            HistoryAdd(NovelText);
        }
        //�ǂݍ��ޕ����̈ʒu���ŏ��ɖ߂�
        TextNumber = 0;

        //�t�H���g�t���O�̏�����
        FontNumber = 0;

        //�ҋ@���Ԃ̌v�Z




        //�e�L�X�g���ꕶ���Â\�����Ă���
        while (TextNumber < NovelTextContent.Length)
        {
            //�t�H���g��F�̈Ⴄ���̂��������ނɂ�
            //���ꂱ��Text���̂��Ⴄ�I�u�W�F�N�g�ő��݂�����K�v������
            //�R�}���h���͈ʒu�ō�������

            //�q�X�g���[�I�𒆂�I�v�V�������̓|�[�Y�������s��
            yield return new WaitUntil(() => !Paused);

            //�A�N�V�������͖��߂�����Ύ��s����
            if (AP.pos != null) ActionSystemMaster.Instance.ActionStart(AP.pos, AP.TransTime);

            //�R�}���h���͂̊m�F
            if (NovelTextContent[TextNumber].ToString() == "'")
            {
                TextNumber++;//�ꕶ������Q��
                //������x�R�}���h���͂��m�F����܂ő�����
                while (NovelTextContent[TextNumber].ToString() != "'")
                {
                    if (NovelTextContent[TextNumber].ToString() == "F")
                    {
                        TextNumber++;//�ꕶ������Q��

                        //�w��̐��l��FontNumber�ɐݒ肷��
                        FontNumber = int.Parse(NovelTextContent[TextNumber].ToString());

                        TextNumber++;//�ꕶ������Q��(���̎��_�ŁA���̖��߂������̓R�}���h���͏I���̕���������)
                    }
                }

                //while���E�o��
                TextNumber++;//�ꕶ������Q��(�R�}���h�I���p��'���Q�Ƃ��Ȃ��悤�ɂ��邽��)
            }

            for (int i = 0; i < NovelText.Length; i++)
            {
                if (FontNumber == i)
                {
                    //���s���߂́A���̃t�H���g���ɂ͓K�p����Ȃ����߁A�����Ŏ��O�Ɏ�������

                    //�P�����ǉ�
                    TextAdd(NovelText[i], NovelTextContent[TextNumber], i);
                }
                else
                {
                    //���s���ꂽ�Ƃ��Ƀo�O���Ĉꕶ���󔒂������\��������������ς肻���������I�I�I�I�I
                    //�u�A�v����͂��������R�}���h�󔒃o�O�������������A���s�̎��ɋ󔒂͖����Ȃ��悤�ɐݒ肵����ꏏ�ɒ����Ă��̂ŁA����������Ƌ�_�ɂ͉��s�R�[�h�Ɠ����R�[�h���p�����Ă���H�H�H�i�悭�킩���j
                    if (NovelTextContent[TextNumber] == '\n')
                    {
                        for (int j = 0; j < NovelText.Length; j++)
                        {
                            //���s�ǉ�
                            if (FontNumber != j) TextAdd(NovelText[j], '\n', j);
                        }
                    }
                    else
                    {
                        //�󔒂��P�����ǉ�
                        TextAdd(NovelText[i], "�@", i);
                    }
                }
            }
            TextNumber++;//�ǉ�������1����

            if (!Pressed) yield return new WaitForSeconds(0.02f);

        }

        Pressed = false;

        yield return new WaitUntil(() => Pressed);

        //�N���b�N�Ő�ɐi��

        //�S�Ă̓��͂��I����
        //�e�L�X�g�E�B���h�E���t�F�[�h�A�E�g����
        //�����łȂ���Ύ��̃e�L�X�g��\������

        if (NovelTexts.Length - 1 > Novelnumber)
        {
            //�܂����b�Z�[�W���c���Ă���ꍇ
            Novelnumber++;
            NovelStart();
        }
        else
        {
            //���b�Z�[�W���c���Ă��Ȃ��ꍇ
            NovelOver();
        }
    }
    public void HistoryAdd(Text[] Tx)
    {
        NovelHistoria.Instance.HistoryTake(Tx);
    }

    public void TextAdd(Text tx, char cx, int FontNumber)
    {
        tx.text += cx;
        NovelHistoria.Instance.HistoryAdd(cx, FontNumber);
    }
    public void TextAdd(Text tx, string cx, int FontNumber)
    {
        tx.text += cx;
        NovelHistoria.Instance.HistoryAdd(cx, FontNumber);
    }
    #endregion


}
