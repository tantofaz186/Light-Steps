using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item")]
public class Item : ScriptableObject
{
    public enum TipoDeItem { CONSUMABLE, VEST, HELMET, HANDS, ACCESSORY, KEY }

    new public string name;
    public string descrição;
    public int preçoDeCompra;
    public Sprite sprite;
    public TipoDeItem tipo;
    public bool PodeSeAcumular
    {
        get
        {
            if (tipo == TipoDeItem.CONSUMABLE || tipo == TipoDeItem.KEY)
                return true;
            else 
                return false;
        }        
    }


}
