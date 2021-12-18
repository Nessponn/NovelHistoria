using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;//�{�^���Ɖ�ʃ^�b�`�ɃR���t���N�g�𐶂܂Ȃ�����
using TMPro;


public abstract class NovelHistoria : MonoBehaviour
{
    //�S�ẴV�X�e���̓�������B�S�Ă̓��͂��󂯕t���A�܂��A�S�Ă̏o�͂����肷��ꏊ�ł�����

    [Space]
    //�E�B���h�E�I�v�V�����i�����Łj
    public Image WindowSize;//�E�B���h�E�T�C�Y�̒l
    public Image WindowAlpha;//�E�B���h�E�̓����x�̒l�i�t�H���g�͊܂܂Ȃ��j
    public CanvasGroup WindowCanvas;//�E�B���h�E���̂���
    public RectTransform MessageFont;//���b�Z�[�W�̃t�H���g
    public CanvasGroup TextWindow;//�e�L�X�g�E�B���h�E�i�t�H���g�͊܂܂Ȃ��j

    [Space]
    //�m�x���e�L�X�g�p
    //private Text[] NovelText;//�g�p����t�H���g�I�u�W�F�N�g�̃X�^�b�N��p
    //private int TextNumber;//���݂̕����̈ʒu�ԍ��@�i�[�ϐ�
    private bool Talking;//��b�����ǂ���
    private bool Pressed;//���ɑ���܂ł̏���
    //[System.NonSerialized] public bool Paused;//�|�[�Y��
    //[System.NonSerialized] public bool HistoriaMODE;//�P�����Âǉ�����C�ɒǉ���

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
}
