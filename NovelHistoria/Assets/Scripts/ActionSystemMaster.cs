using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;//�{�^���Ɖ�ʃ^�b�`�ɃR���t���N�g�𐶂܂Ȃ�����
using TMPro;

public class ActionSystemMaster : SingletonMonoBehaviourFast<ActionSystemMaster>
{
    #region ActionSystem Method

    public Camera camera;

    //Sequence ActionAnimation;

    private bool Animating;//�A�j���[�V��������true

    // Start is called before the first frame update
    void Start()
    {
        //��ʃA�j���[�V�����p�̂��
        //ActionAnimation = DOTween.Sequence();
    }

    private void Update()
    {
        //�J�����|�W�V�����o�^
        position = camera.transform.position;
    }

    private Vector3 position;//�J�����̃|�W�V����
    private float time;//�X�^�b�N����Έڎ���

    public void ActionStart(Transform pos, float time)
    {
        camera.transform.DOMove(pos.position, time);

        //�Έڎ��Ԃ̏㏑��
        this.time = time;
    }

    public void ActionOver()
    {
        //���̈ʒu�ɖ߂�
        camera.transform.DOMove(position, time);
    }

    #endregion
}
