using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;//�{�^���Ɖ�ʃ^�b�`�ɃR���t���N�g�𐶂܂Ȃ�����
using TMPro;

public class NovelSystem_Mk3 : SingletonMonoBehaviourFast<NovelSystem_Mk3>
{
    private Text[] NovelText;//�g�p����t�H���g�I�u�W�F�N�g�̃X�^�b�N��p
    private int TextNumber;//���݂̕����̈ʒu�ԍ��@�i�[�ϐ�

    private int FontNumber;
    private NovelClass[] NovelTexts;
    private int Novelnumber;//���݂̃e�L�X�g�̔ԍ�

    

    //��b�̃V�[�����J�n���ꂽ����A��b�f�[�^�������ɂ����Ă�����
    public void Setup(NovelTaker DATA)
    {
        //��������e�L�X�g�̔z������o���A�X�e�[�^�X�����L�̃R���[�`���Ŕ��΂�����
        Novelnumber = DATA.NovelNumber_Debug;

        //�g�p����e�L�X�g�t�H���g��NovelText�ɓK�p����
        NovelText = DATA.Fonts;

        //�ēx�\���O�ɕ����̓��e����x���Z�b�g
        for (int i = 0; i < NovelText.Length; i++)
        {
            NovelText[i].text = "";
        }

    }

    public IEnumerator While(NovelTaker DATA, int Number)
    {

        Debug.Log("�ʂ��Ă�");

        //�������͂���Ă��Ȃ���΁A�����ŏ������I��
        if (DATA.NS[Number].NovelParameter.Text == "") yield break;


        //���̃e�L�X�g�������p���̂łȂ����
        //��{�e�L�X�g�̓��e��������ۂɂ���
        if (!DATA.NS[Number].NovelParameter.ResidualText)
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
        while (TextNumber < DATA.NS[Number].NovelParameter.Text.Length)
        {
            //�t�H���g��F�̈Ⴄ���̂��������ނɂ�
            //���ꂱ��Text���̂��Ⴄ�I�u�W�F�N�g�ő��݂�����K�v������
            //�R�}���h���͈ʒu�ō�������

            //�q�X�g���[�I�𒆂�I�v�V�������̓|�[�Y�������s��
            yield return new WaitUntil(() => !NovelHistoria_Mk3.Historia.Paused);

            //�A�N�V�������͖��߂�����Ύ��s����
            //if (AP.pos != null) ActionSystemMaster.Instance.ActionStart(AP.pos, AP.TransTime);

            //�R�}���h���͂̊m�F
            if (DATA.NS[Number].NovelParameter.Text[TextNumber].ToString() == "'")
            {
                TextNumber++;//�ꕶ������Q��
                //������x�R�}���h���͂��m�F����܂ő�����
                while (DATA.NS[Number].NovelParameter.Text[TextNumber].ToString() != "'")
                {
                    if (DATA.NS[Number].NovelParameter.Text[TextNumber].ToString() == "F")
                    {
                        TextNumber++;//�ꕶ������Q��

                        //�w��̐��l��FontNumber�ɐݒ肷��
                        FontNumber = int.Parse(DATA.NS[Number].NovelParameter.Text[TextNumber].ToString());

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
                    TextAdd(NovelText[i], DATA.NS[Number].NovelParameter.Text[TextNumber], i);
                }
                else
                {
                    //���s���ꂽ�Ƃ��Ƀo�O���Ĉꕶ���󔒂������\��������������ς肻���������I�I�I�I�I
                    //�u�A�v����͂��������R�}���h�󔒃o�O�������������A���s�̎��ɋ󔒂͖����Ȃ��悤�ɐݒ肵����ꏏ�ɒ����Ă��̂ŁA����������Ƌ�_�ɂ͉��s�R�[�h�Ɠ����R�[�h���p�����Ă���H�H�H�i�悭�킩���j
                    if (DATA.NS[Number].NovelParameter.Text[TextNumber] == '\n')
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

            //if (!Pressed) 
            yield return new WaitForSeconds(0.06f);

        }

        //Pressed = false;

        //yield return new WaitUntil(() => Pressed);

        //�N���b�N�Ő�ɐi��

        //�S�Ă̓��͂��I����
        //�e�L�X�g�E�B���h�E���t�F�[�h�A�E�g����
        //�����łȂ���Ύ��̃e�L�X�g��\������

        //NovelHistoria����while���߂��o�����߁A�����ł̏����͕K�v�Ȃ�
        /*
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
        }*/
    }

    public void Over()
    {
        //��b�̏I��
        NovelHistoria_Mk3.Historia.Talking = false;

        NovelHistoria_Mk3.Historia.WindowCanvas.DOFade(0, 1f);
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
