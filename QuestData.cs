using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuestData 
{
    public static List<Quest> quests;
}
public class Quest
{
    public string nomeDaQuest;
    public string estadoAtualDaQuest;
    public bool completada;

    public Quest()
    {
        nomeDaQuest = "Quest Genérica";
        estadoAtualDaQuest = "Invada a filial de segurança!";
        completada = false;
        QuestData.quests.Add(this);
    }
}
