using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipamentoHolder : ItemHolder
{
    public Item.TipoDeItem tipoDeHolder;
    
    protected override void OnValidate()
    {
        base.OnValidate();
        gameObject.name = tipoDeHolder.ToString() + "Holder";
    }
    protected override void DebugItemHolder()
    {
        base.DebugItemHolder();
        if (item.tipo != tipoDeHolder)
        {
            Debug.LogError("O holder " + gameObject.name + " está segurando um item do tipo errado: " +
                            "\nTipo esperado: " + tipoDeHolder +
                            "\nTipo segurado: " + item.tipo);
        }           
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
