using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class ItemHolder : MonoBehaviour, /*IPointerClickHandler,*/ IPointerEnterHandler, IPointerExitHandler
{
    Item _item;
    Sprite defaultSprite;
    Image itemImage;
    public Item item
    {
        get { return _item; }
        set
        {
            _item = value;
            SetImage(item);
        }
    }
    void SetImage(Item itemParam)
    {
        if (itemParam != null)
        {
            itemImage.sprite = itemParam.sprite;
            itemImage.enabled = true;
            itemImage.useSpriteMesh = true;
        }
        else
        {
            if(defaultSprite != null)
            {
                itemImage.sprite = defaultSprite;
                itemImage.enabled = true;
            }
            else
            itemImage.enabled = false;     
        }
    }

    public event Action<Item> MoverItem;
    public event Action<Item> MoverItemDeInventario;
    // Start is called before the first frame update
    protected virtual void OnValidate()
    {
        itemImage = GetComponent<Image>();
        defaultSprite = itemImage.sprite;
        SetImage(item);
    }
    protected virtual void DebugItemHolder()
    {
        Debug.Log(item.name + " Foi adicionado.");
        if (item.PodeSeAcumular)
            Debug.Log("Esse item pode se acumular");
        if (!item.PodeSeAcumular)
            Debug.Log("Esse item NÃO pode se acumular");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
            Debug.Log(item.name);
        StopAllCoroutines();
        StartCoroutine("SelectItem", eventData);
    }
    IEnumerator SelectItem(PointerEventData eventData)
    {
        if (eventData != null)
        {
            while (!(Input.GetButtonDown("Interact") || Input.GetButtonDown("Confirm"))) yield return null;

            if (Input.GetButtonDown("Interact"))
            {
                if (item != null && MoverItemDeInventario != null)
                {
                    MoverItemDeInventario(item);
                }
            }
            else if (Input.GetButtonDown("Confirm"))
            {
                if (item != null && MoverItem != null)
                {
                    MoverItem(item);
                }
            }
        }
    }
    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    if(eventData != null)
    //    {

    //        if (eventData.button == PointerEventData.InputButton.Left)
    //        {
    //            if (item != null && MoverItem != null)
    //            {
    //                MoverItem(item);
    //            }
    //        }
    //        else if(eventData.button == PointerEventData.InputButton.Right)
    //        {
    //            if (item != null && MoverItemDeInventario != null)
    //            {
    //                MoverItemDeInventario(item);
    //            }
    //        }            
    //    }               
    //}
    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
    }


    //if (eventData != null)
    //{
    //    if (Input.GetButtonDown("Confirm"))
    //    {
    //        if (item != null && MoverItem != null)
    //        {
    //            MoverItem(item);
    //        }
    //    }
    //    else if (Input.GetButtonDown("Interact"))
    //    {
    //        if (item != null && MoverItemDeInventario != null)
    //        {
    //            MoverItemDeInventario(item);
    //        }
    //    }
    //}
}
