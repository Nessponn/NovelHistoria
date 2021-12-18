using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;//�{�^���Ɖ�ʃ^�b�`�ɃR���t���N�g�𐶂܂Ȃ�����
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
		GameObject[] obj = GameObject.FindGameObjectsWithTag("GameController"); //�^�O�Ŕ���
		if (1 < obj.Length) Destroy(gameObject);
		else DontDestroyOnLoad(gameObject);
	}


    #endregion

    [Space]
    //�E�B���h�E�I�v�V�����i�����Łj
    public Image WindowSize;//�E�B���h�E�T�C�Y�̒l
    public Image WindowAlpha;//�E�B���h�E�̓����x�̒l�i�t�H���g�͊܂܂Ȃ��j
    public CanvasGroup WindowCanvas;//�E�B���h�E���̂���
    public RectTransform MessageFont;//���b�Z�[�W�̃t�H���g
    public CanvasGroup TextWindow;//�e�L�X�g�E�B���h�E�i�t�H���g�͊܂܂Ȃ��j

    [Space]
    //�m�x���e�L�X�g�p
    [System.NonSerialized] public bool Talking;//��b�����ǂ���
    [System.NonSerialized] public bool Pressed;//���ɑ���܂ł̏���
    [System.NonSerialized] public bool Paused;//�|�[�Y��
    [System.NonSerialized] public bool HistoriaMODE;//�P�����Âǉ�����C�ɒǉ���

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

    //�f�[�^�����J�n
    public void HistoriaSystem_Start(NovelTaker DATA)
    {
        //�E�B���h�E�̕\��
        WindowCanvas.DOFade(1, 1f);

        //�e��V�X�e����Setup���\�b�h�ɃA�N�Z�X���ASetup����
        //NovelSystem��SetUp
        NovelSystem_Mk3.Instance.Setup(DATA);

        DOVirtual.DelayedCall(1, () =>
        {
            //�V�X�e���̊J�n �ԍ��w���
            StartCoroutine(HistoriaSystem_While(DATA, 0));

            //��b�̊J�n
            Talking = true;
        }
        );
        
    }

    //�p���I�ȃf�[�^����
    private IEnumerator HistoriaSystem_While(NovelTaker DATA, int Number)
    {
        Pressed = false;

        //��b�V�X�e���Ƀf�[�^�𓊉�
        StartCoroutine(NovelSystem_Mk3.Instance.While(DATA,Number));

        //�A�N�V�����V�X�e���Ƀf�[�^�𓊉�
        //ActionSystem_Mk2.Instance.ActionStart(DATA);

        yield return new WaitUntil(() => Pressed);

        //�N���b�N���ꂽ�玟�ɐi��
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
