using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(PlayerData player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/daave.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        float[] position = { player.position[0], player.position[1], player.position[2] };
        PlayerData data = new PlayerData(player.health, player.batteries,
            player.epinephrineInjection, player.ammo9mm, player.arrowQuiver, position);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/daave.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        } else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }
}
