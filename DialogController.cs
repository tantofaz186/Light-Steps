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
        if (instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }
        HidePanel();
    }

    public void SetDialog(DialogItem item){
        dialog.text = item.dialog;
        ShowPanel();
        Invoke("HidePanel", time);
    }

    void ShowPanel(){
        dialogPanel.SetActive(true);
    }

     void HidePanel(){
        dialogPanel.SetActive(false);
    }

}
