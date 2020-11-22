using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryEquipado : MonoBehaviour
{
    public Transform gridDeEquipaveis;
    [SerializeField] EquipamentoHolder[] espaçosDeEquipaveis;
    public List<Item> listaDeEquipados;

    public event Action<Item> DesequiparItem;
    //public event Action<Item> MoverParaInventario;


    void OnValidate()
    {
        if (gridDeEquipaveis == null)
            gridDeEquipaveis = GetComponentInChildren<Transform>();

        espaçosDeEquipaveis = gridDeEquipaveis.GetComponentsInChildren<EquipamentoHolder>();


    }
    private void Awake()
    {
        for (int i = 0; i < espaçosDeEquipaveis.Length; i++)
        {
            espaçosDeEquipaveis[i].MoverItem += DesequiparItem;
            //espaçosDeEquipaveis[i].MoverItemDeInventario += MoverParaInventario;
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
    public bool AdicionarItem(Item item, out Item itemAnterior)
    {
        for (int i = 0; i < espaçosDeEquipaveis.Length; i++)
        {
            if (espaçosDeEquipaveis[i].tipoDeHolder == item.tipo)
            {
                itemAnterior = espaçosDeEquipaveis[i].item;
                espaçosDeEquipaveis[i].item = item;
                listaDeEquipados.Add(item);
                listaDeEquipados.Remove(itemAnterior);
                return true;
            }
        }
        itemAnterior = null;
        return false;
    }
    public bool RemoverItem(Item item)
    {
        for (int i = 0; i < espaçosDeEquipaveis.Length; i++)
        {
            if (espaçosDeEquipaveis[i].item == item)
            {
                espaçosDeEquipaveis[i].item = null;
                listaDeEquipados.Remove(item);
                return true;
            }
        }
        return false;
    }

    private void AtualizarInventario()
    {
        for (int i = 0; i < espaçosDeEquipaveis.Length; i++)
        {
            if (espaçosDeEquipaveis[i].item == null)
            {

            }
        }

    }
}
