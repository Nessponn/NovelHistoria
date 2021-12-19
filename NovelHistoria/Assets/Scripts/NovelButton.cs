using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NovelButton : MonoBehaviour
{
    public GameObject HistoryUI;
    public GameObject SettingUI;



    

    // Start is called before the first frame update
    public void History()
    {
        NovelHistoria_Mk3.Historia.Paused = !NovelHistoria_Mk3.Historia.Paused;

        HistoryUI.SetActive(!HistoryUI.activeSelf);
        if (HistoryUI.activeSelf)
        {
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "�Q�[���ɖ߂�";
        }
        else
        {
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "�q�X�g���[";
        }
    }

    public void Setting()
    {
        NovelHistoria_Mk3.Historia.Paused = !NovelHistoria_Mk3.Historia.Paused;

        SettingUI.SetActive(!SettingUI.activeSelf);
        if (SettingUI.activeSelf)
        {
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "�Q�[���ɖ߂�";
        }
        else
        {
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "�I�v�V����";
        }
    }
}
