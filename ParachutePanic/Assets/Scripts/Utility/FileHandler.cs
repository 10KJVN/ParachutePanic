using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Utility class that handles Writing/Reading to JSON files.
/// Using Generics allows for flexibility between the types of data
/// to Save or Load. Whenever another class uses this and requires:
/// a "filename" parameter, make sure to end it on name.json yourself.
/// </summary>

public static class FileHandler
{
    public static void SaveToJSON<T>(List<T> toSave, string filename)
    {
        Debug.Log(GetPath(filename));
        string content = JsonHelper.ToJson<T>(toSave.ToArray());
        WriteFile(GetPath(filename), content);
    }

    public static void SaveToJSON<T>(T toSave, string filename) 
    {
        Debug.Log(GetPath(filename));
        string content = JsonUtility.ToJson(toSave);
        WriteFile(GetPath(filename), content);
    }

    public static List<T> ReadListFromJSON<T>(string filename)
    {
        string content = ReadFile(GetPath(filename));

        if (string.IsNullOrEmpty(content) || content == "{}")
        {
            return new List<T>();
        }

        List<T> response = JsonHelper.FromJson<T>(content).ToList();

        return response;
    }

    public static T ReadFromJSON<T>(string filename)
    {
        string content = ReadFile(GetPath(filename));

        if (string.IsNullOrEmpty(content) || content == "{}")
        {
            return default(T);
        }

        T response = JsonUtility.FromJson<T> (content);

        return response; 
    }    

    private static string GetPath(string filename)
    {
        return Application.persistentDataPath + "/" + filename;
    }

    private static void WriteFile(string path, string content)
    {
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream)) 
        {
            writer.WriteLine(content);
        }
    }

    private static string ReadFile(string path)
    {
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string content = reader.ReadToEnd();
                return content;
            }
        }
        return "";
    }
}

// Source - https://stackoverflow.com/a/36244111
// Posted by Programmer, modified by community. See post 'Timeline' for change history
// Retrieved 2026-03-10, License - CC BY-SA 4.0

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
