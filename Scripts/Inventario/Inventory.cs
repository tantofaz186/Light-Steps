using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public Transform gridBolsa;
    public ItemHolder[] espaçosNaBolsa;
    public List<Item> listaDeItens;

    public event Action<Item> EquiparItem;
    public event Action<Item> MoverParaInventario;




    void OnValidate()
    {

    }
    private void Awake()
    {
        if (gridBolsa == null)
            gridBolsa = GetComponentInChildren<Transform>();

        espaçosNaBolsa = gridBolsa.GetComponentsInChildren<ItemHolder>();

        for (int i = 0; i < espaçosNaBolsa.Length; i++)
        {
            espaçosNaBolsa[i].MoverItem += EquiparItem;
            espaçosNaBolsa[i].MoverItemDeInventario += MoverParaInventario;

        }
        AtualizarInventario();
    }
    // Start is called before the first frame update
    void Start()
    {
        AtualizarInventario();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool AdicionarItem(Item item)
    {
        if (Cheio() || item == null)
            return false;
        listaDeItens.Add(item);
        AtualizarInventario();
        return true;
    }
    public bool RemoverItem(Item item)
    {
        for (int i = 0; i < espaçosNaBolsa.Length; i++)
        {
            if (espaçosNaBolsa[i].item == item)
            {
                listaDeItens.Remove(item);
                AtualizarInventario();
                return true;
            }
        }
        return false;
        //if (item == null)
        //    return false;

        //listaDeItens.Remove(item);
        //AtualizarInventario();
        //return true;
    }
    public bool Cheio()
    {
        if (listaDeItens.Count >= espaçosNaBolsa.Length)
            return true;
        return false;
    }
    private void AtualizarInventario()
    {
        for (int i = 0; i < espaçosNaBolsa.Length; i++)
        {
            
            if (i >= listaDeItens.Count) 
            {
                espaçosNaBolsa[i].item = null;
            }
            else
                espaçosNaBolsa[i].item = listaDeItens[i];
        }

    }
}
