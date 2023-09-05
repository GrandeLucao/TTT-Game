using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    // Não sei se isso roda, testar depois
    // const string path = Application.persistentDataPath + "/state.pjt";
    // SE A LINHA 8 RODAR, REMOVER A LINHA 16 E 28

    public static void SavePlayer (Player player)
    {
        // objeto q vai formatar o arquivo em binario
        BinaryFormatter formatter = new BinaryFormatter();
        // caminho padrao dentro do unity que não muda entre sistemas
        string path = Application.persistentDataPath + "/state.pjt";

        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(player);

        // serializa o dado em binario dentro do arquivo
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer ()
    {
        string path = Application.persistentDataPath + "/state.pjt";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }else
        {
           Debug.LogError("Save file not found in "+path);
           return null; 
        }
    }

}