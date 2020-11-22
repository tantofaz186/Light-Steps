using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class InventoryManager : MonoBehaviour
{
    public Inventory inventarioBolsa;
    public InventoryEquipado inventarioEquipado;
    //public InventoryManager inventarioPointer;
    public Inventory bolsaInimiga;
    public InventoryEquipado equipadoInimigo;
    PlayerData player;
    private void Awake()
    {
        inventarioBolsa.EquiparItem += Equipar;
        inventarioEquipado.DesequiparItem += Desequipar;
        bolsaInimiga.MoverParaInventario += SaquearBolsa;
        inventarioBolsa.MoverParaInventario += EntregarItem;
        //inventarioPointer.inventarioBolsa.EquiparItem += Equipar;
        //inventarioPointer.inventarioEquipado.DesequiparItem += Desequipar;
        //inventarioPointer.inventarioBolsa.MoverParaInventario += SaquearBolsa;
    }
    void Start()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        if(temp != null)
            player = temp.GetComponent<PlayerCharScript>().player;
        if (player != null)
        {
            inventarioBolsa.listaDeItens = player.itensNaBolsa;
            inventarioEquipado.listaDeEquipados = player.itensEquipados;
        }
        bolsaInimiga.listaDeItens = new List<Item>();
        equipadoInimigo.listaDeEquipados = new List<Item>();
    }
    void Update()
    {
        if (player != null)
        {
            player.itensNaBolsa = inventarioBolsa.listaDeItens;
            player.itensEquipados = inventarioEquipado.listaDeEquipados;
        }
    }
    /// <summary>
    /// remove um item da bolsa do personagem e equipa ele no inventário equipado
    /// </summary>
    /// <param name="item">Item a ser equipado</param>
    public void Equipar(Item item)
    {
        if (inventarioBolsa.RemoverItem(item))//se o item está na bolsa
        {
            Item itemAnterior;
            if (inventarioEquipado.AdicionarItem(item, out itemAnterior))//se item pode ser equipado
            {
                if (itemAnterior != null)  //se já existia um item equipado
                {
                    inventarioBolsa.AdicionarItem(itemAnterior); //retorna o item anterior para a bolsa
                }
            }
            else//se o item não pode ser equipado
                inventarioBolsa.AdicionarItem(item);//retorna o item atual para a bolsa
        }
    }
    public void Desequipar(Item item)
    {
        if (!inventarioBolsa.Cheio() && inventarioEquipado.RemoverItem(item))//se a bolsa não está cheia e existe um item que pode ser removido
        {
            inventarioBolsa.AdicionarItem(item);//adiciona o item na bolsa
        }
    }
    public void SaquearBolsa(Item item)
    {
        Debug.Log("Saqueando");
        if (bolsaInimiga.RemoverItem(item))
        {
            inventarioBolsa.AdicionarItem(item);
        }
    }
    public void EntregarItem(Item item)
    {
        if (!this.bolsaInimiga.Cheio() && this.inventarioBolsa.RemoverItem(item))
        {
            this.bolsaInimiga.AdicionarItem(item);
        }
    }
    //public void SaquearBolsa(Item item)
    //{
    //    if (!inventarioPointer.inventarioBolsa.Cheio() && inventarioBolsa.RemoverItem(item))
    //    {
    //        inventarioPointer.inventarioBolsa.AdicionarItem(item);
    //        Debug.Log("Item " + item.name + " foi retirado de inventário " + this.name +
    //            " e adicionado à inventário " + inventarioPointer.name);
    //    }
    //}
}
