using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class GameController : MonoBehaviour
{
    DadosSaveGame saveGame;
    string saveGameFileName = "FileName.xml";
    string senha = "DefaultPasswordPleaseDoNOTUseThisOneOk?";

    public PlayerData player;
    public List<NPCData> NPCs;
    public List<Quest> quests;


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

        foreach(NPCScript npcObject in FindObjectsOfType<NPCScript>())
        {
            NPCs.Add(npcObject.npc);
        }
        ///Tudo aqui são dados salvos
        quests = QuestData.quests;
        saveGame.quests = quests;
        saveGame.player = player;
        saveGame.NPCs = NPCs;
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

        saveGame = (DadosSaveGame)serializador.Deserialize(leituraDoArquivo.BaseStream);  //fazemos a leitura e desserializamos para o objeto do savegame

        ///Tudo aqui são dados carregados
        quests = saveGame.quests;
        player = saveGame.player;
        NPCs = saveGame.NPCs;
        ///
        QuestData.quests = quests;
        ReiniciarNPCs();


        leituraDoArquivo.Close();
        CriptografarSave(saveGameFileName);     
    }
    void ReiniciarNPCs()
    {

        NPCScript[] npcObjects = FindObjectsOfType<NPCScript>();
        for (int i = 0; i < npcObjects.Length; i++)
        {
            #region Instancia um novo npc na posição do último save
            GameObject instantiated = GameObject.Instantiate(npcObjects[i].gameObject, NPCs[i].position, Quaternion.identity);
            if(instantiated.GetComponent<NPCScript>() == null)
            {
                instantiated.AddComponent<NPCScript>();
            }
            instantiated.GetComponent<NPCScript>().npc = NPCs[i];
            #endregion
            Destroy(npcObjects[i].gameObject); //destrói o npc ativo antes do load 

        }


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
