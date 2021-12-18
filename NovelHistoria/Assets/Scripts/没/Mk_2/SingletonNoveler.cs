using System.Collections;
using System;
using UnityEngine;

public class SingletonNoveler<T> : NovelHistoria_Mk2 where T : SingletonNoveler<T>
{
	protected static readonly string[] NovelfindTags =
	{
		"GameController",
	};

	protected static T nins;
	public static T NIns
	{
		get
		{
			if (nins == null)
			{

				Type type = typeof(T);

				foreach (var tag in NovelfindTags)
				{
					GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);

					for (int j = 0; j < objs.Length; j++)
					{
						nins = (T)objs[j].GetComponent(type);
						if (nins != null)
							return nins;
					}
				}

				Debug.LogWarning(string.Format("{0} is not found", type.Name));
			}

			return nins;
		}
	}

	virtual protected void Awake()
	{
		CheckInstanceHistoria();
	}

	protected bool CheckInstanceHistoria()
	{
		if (nins == null)
		{
			nins = (T)this;
			return true;
		}
		else if (NIns == this)
		{
			return true;
		}

		Destroy(this);
		return false;
	}
}
