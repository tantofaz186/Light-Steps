using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogItem : MonoBehaviour
{
    public string dialog;

    void OnTriggerEnter(Collider col){
        if (col.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.F)){
            DialogController.instance.SetDialog(this);
        }
    }
}
