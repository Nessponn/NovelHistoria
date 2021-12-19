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
        TextWindow.alpha = 1 - WindowAlpha.fillAmount;
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


    private List<NovelTaker> StackDATA = new List<NovelTaker>();
    
    public void HistoriaSystem_Start(NovelTaker DATA)
    {
        //���łɉ�b���J�n����Ă����ꍇ�A�v�f���X�^�b�N�ɒǉ�����݂̂ŏ������I����
        if(StackDATA.Count > 0)
        {
            //Debug.Log("���ɉ�b�͊J�n����Ă��܂�");
            StackDATA.Push(DATA);
            return;
        }
        //�����łȂ���΁A�����ĉ�b�J�n�������s��
        StackDATA.Push(DATA);

        HistoriaSystem_Setup(StackDATA[0]);
    }

    //�f�[�^�����J�n
    //�������Ƃ���͌�Őݒ��b�̂Ƃ����C�ӂ̕b���ɕς���悤�ɕύX����
    private void HistoriaSystem_Setup(NovelTaker DATA)
    {
        //�e��V�X�e����Setup���\�b�h�ɃA�N�Z�X���ASetup����
        //NovelSystem��SetUp
        NovelSystem_Mk3.Instance.Setup(DATA);


        //�V�X�e���̊J�n �ԍ��w���
        StartCoroutine(HistoriaSystem_While(DATA, 0));

    }

    //�p���I�ȃf�[�^����
    private IEnumerator HistoriaSystem_While(NovelTaker DATA, int Number)
    {
        Pressed = false;

        //��b�V�X�e���Ƀf�[�^�𓊉�
        StartCoroutine(NovelSystem_Mk3.Instance.While(DATA,Number));

        //�A�N�V�����V�X�e���Ƀf�[�^�𓊉�
        ActionSystem_Mk3.Instance.Move(DATA, Number);

        yield return new WaitUntil(() => Pressed);

        //�N���b�N���ꂽ�玟�ɐi��
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

        //�܂�StackDATA�Ƀf�[�^���c���Ă���Ȃ�΁A���̃f�[�^���Q�Ƃ��A�Ă�Setup��

        if(StackDATA.Count > 0)
        {
            HistoriaSystem_Setup(StackDATA[0]);

            //�ꕔ�@�\��Over�ł������񃊃Z�b�g
            ActionSystem_Mk3.Instance.Over(DATA);

            return;
        }
        //���S�Ƀf�[�^���������Over

        NovelSystem_Mk3.Instance.Over();
        ActionSystem_Mk3.Instance.Over(DATA);


    }
}
public static class ListExtensions
{
    /// <summary>
    /// �擪�ɂ���I�u�W�F�N�g���폜���܂�
    /// </summary>
    public static void Pop<T>(this IList<T> self)
    {
        self.RemoveAt(0);
        //Debug.Log("�f�[�^������");
    }

    /// <summary>
    /// �����ɃI�u�W�F�N�g��ǉ����܂�
    /// </summary>
    public static void Push<T>(this IList<T> self, T item)
    {
        self.Insert(self.Count, item);
        //Debug.Log("�f�[�^��ǉ�");
    }

    /// <summary>
    /// �擪�ɂ���I�u�W�F�N�g���폜���A�Ԃ��܂�
    /// </summary>
    public static T RetPop<T>(this IList<T> self)
    {
        var result = self[0];
        self.RemoveAt(0);
        return result;
    }

    /// <summary>
    /// �����ɃI�u�W�F�N�g��ǉ����܂�
    /// </summary>
    public static T RetPush<T>(this IList<T> self, T item)
    {
        var result = self[0];
        self.Insert(0, item);
        return result;
    }
}