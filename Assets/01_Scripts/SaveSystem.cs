using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour 
{
    private static string SavePath => $"{Application.persistentDataPath}/save.txt";

    [ContextMenu("Save")]
    public static void Save()
    {
        var state = LoadFile();
        CaptureState(state);
        SaveFile(state);
    }

    [ContextMenu("Load")]
    public static void Load()
    {
        var state = LoadFile();
        RestoreState(state);
    }

    public static void DeleteSaveFile()
    {
        if (File.Exists(SavePath))

        {

            File.Delete(SavePath);

        }
    }

    private static Dictionary<string, object> LoadFile()
    {
        if (!File.Exists(SavePath))
        {
            return new Dictionary<string, object>();
        }

        using (FileStream stream = File.Open(SavePath, FileMode.Open))
        {
            var formatter = new BinaryFormatter();
            return (Dictionary<string, object>)formatter.Deserialize(stream);
        }
    }


    private static void SaveFile(object state)
    {
        using (var stream = File.Open(SavePath, FileMode.Create))
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, state);
        }
    }

    private static void CaptureState(Dictionary<string, object> state)
    {
        foreach (var saveable in SceneUtil.GetAllObjectsInScene<BaseSaveable>())
        {
            state[saveable.Id] = saveable.CaptureState();
        }
    }

    private static void RestoreState(Dictionary<string, object> state)
    {
        foreach (var saveable in SceneUtil.GetAllObjectsInScene<BaseSaveable>())
        {
            if (state.TryGetValue(saveable.Id, out object value))
            {
                saveable.RestoreState(value);
            }
        }
    }

    public static bool SaveFileExists() => File.Exists(SavePath);

}
