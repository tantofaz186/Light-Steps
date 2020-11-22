using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class GameController : MonoBehaviour
{
    DadosSaveGame saveGame;
    string saveGameFileName = "Light_Steps_Save.xml";
    string senha = "Inventário é chato de programar. Nossa senhora!";

    PlayerData player;



    private void Awake()
    {

    }


    void Start()
    {
        saveGame = new DadosSaveGame();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharScript>().player;
    }


    // Update is called once per frame
    void Update()
    {

    }


    void Save()
    {
        XmlSerializer serializador = new XmlSerializer(typeof(DadosSaveGame));  //serializador de XML
        StreamWriter escritaDoArquivo = new StreamWriter(saveGameFileName);        //abre o arquivo para salvar

        ///Tudo aqui são dados salvos
        saveGame.player = player;
        ///

        serializador.Serialize(escritaDoArquivo.BaseStream, saveGame);  //mandamos salvar
        escritaDoArquivo.Close();  //fechar o arquivo (IMPORTANTE!!)
        CriptografarSave(saveGameFileName);
    }


    void Load()
    {
        DescriptografarSave(saveGameFileName);
        XmlSerializer serializador = new XmlSerializer(typeof(DadosSaveGame));      //serializador de XML
        StreamReader leituraDoArquivo = new StreamReader(saveGameFileName);             //arquivo a ser lido

        DadosSaveGame saveGame = (DadosSaveGame)serializador.Deserialize(leituraDoArquivo.BaseStream);  //fazemos a leitura e desserializamos para o objeto do savegame

        ///Tudo aqui são dados carregados
        player = saveGame.player;
        ///

        leituraDoArquivo.Close();
        CriptografarSave(saveGameFileName);     
    }


    void CriptografarSave(string saveGameFileName)
    {
        Criptografia criptografia = new Criptografia();
        StreamReader leituraDoArquivo = new StreamReader(saveGameFileName);


        string arquivo = leituraDoArquivo.ReadToEnd();

        leituraDoArquivo.Close();

        arquivo = criptografia.Criptografar(arquivo, senha);

        StreamWriter escritaDoArquivo = new StreamWriter(saveGameFileName);
        escritaDoArquivo.Write(arquivo);
        escritaDoArquivo.Close();
    }


    void DescriptografarSave(string saveGameFileName)
    {
        Criptografia criptografia = new Criptografia();
        StreamReader leituraDoArquivo = new StreamReader(saveGameFileName);


        string arquivo = leituraDoArquivo.ReadToEnd();

        leituraDoArquivo.Close();

        arquivo = criptografia.DesCriptografar(arquivo, senha);

        StreamWriter escritaDoArquivo = new StreamWriter(saveGameFileName);
        escritaDoArquivo.Write(arquivo);
        escritaDoArquivo.Close();
    }
}
