using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NovelClass
{
    //��{�m�x���p�����[�^
    public NovelParameter NovelParameter;

    [Space]
    //�A�N�V�����Q�[�������p�����[�^
    public ActionParameter ActionParameter;
}

[System.Serializable]
public class NovelParameter
{
    public string Name;//�l�[���e�L�X�g
    [TextArea(3, 10)] public string Text;//�e�L�X�g�{��
    public GameObject ChoicesObject;//�I�����I�u�W�F�N�g
    public bool ResidualText;//���̃e�L�X�g���N���b�N���Ă��c���������܂܂ɂ���
    public float InterbalTime = 0.02f;//��b���S�\���ɏ��v���鎞��(�f�t�H���g��0.02�b)
}

[System.Serializable]
public class ActionParameter
{
    public Transform pos;//�X�N���[����̍��W
    public float TransTime;//���W�Ɉړ�����܂łɗv���鏊�v����
    [Range(0, 1)] public float Timing;//��b���̂ǂ̔䗦�̃^�C�~���O�ŃA�N�V�����𔭉΂����邩
    public bool DoAfterTalk;//��b�I����Ɏ��s
}