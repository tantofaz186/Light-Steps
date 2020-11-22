using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public static DialogController instance;
    public Text dialog;
    public GameObject dialogPanel;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        HidePanel();
    }
    public void SetAction(ObjetoDeInteracao interacao)
    {
        dialog.text = interacao.actionText;
        ShowPanel();
    }
    public void SetDialog(DialogItem item)
    {
        if (!running)
        {
            ShowPanel();
            StartCoroutine(PercorrerDialogo(item));
        }
    }
    bool running = false;
    IEnumerator PercorrerDialogo(DialogItem item)
    {
        running = true;
        yield return new WaitForEndOfFrame();
        if (item.index >= item.dialog.Length)
        {
            if (item.repeatAllDialog)
                item.index = 0;
            else//repete apenas a ultima fala
                item.index = item.dialog.Length - 1;
            HidePanel();
            running = false;
            StopAllCoroutines();
        }
        else
        {
            dialog.text = item.dialog[item.index];
            yield return new WaitUntil(() => (Input.GetButtonDown("Interact") || Input.GetButtonDown("Confirm")));
            item.index += 1;
            StartCoroutine(PercorrerDialogo(item));
        }
    }


    void ShowPanel()
    {
        dialogPanel.SetActive(true);
    }

    public void HidePanel()
    {
        dialogPanel.SetActive(false);
    }

}
