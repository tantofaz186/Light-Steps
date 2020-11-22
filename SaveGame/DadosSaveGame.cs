using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadosSaveGame
{
    ///Essa classe deve ser usada para guardar dados que serão usados ao carregar o jogo.
    ///ex: posição de um personagem, itens no inventário, fase atual
    ///O objetivo dessa classe é ser incrementada com o passar do projeto com a adição de classes de dados criadas na nova versão
    public PlayerData player;

    public DadosSaveGame()
    {
        player = null;
    }
}
