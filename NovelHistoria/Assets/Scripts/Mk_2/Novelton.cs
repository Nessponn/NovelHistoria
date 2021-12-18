using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Novelton : MonoBehaviour
{
	// �V���O���g��
	private static Novelton n_inst;
	public static Novelton N_INST
	{
		get
		{
			if (null == n_inst)
			{
				n_inst = (Novelton)FindObjectOfType(typeof(Novelton));
				if (null == n_inst) Debug.LogError(" Data Instance Error ");
			}
			return n_inst;
		}
	}

	void Awake()
	{
		GameObject[] obj = GameObject.FindGameObjectsWithTag("GameContoroller"); //�^�O�Ŕ���
		if (1 < obj.Length) Destroy(gameObject);
		else DontDestroyOnLoad(gameObject);
	}

	// �����ɏ���������
}
