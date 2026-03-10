using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public static class FileHandler
{
    public static void SaveToJSON<T> (List<T> toSave, string filename)
    {
        string content = JsonHelper.ToJson<T>(toSave.ToArray()  );
        WriteFile(GetPath(filename), content); // Only handles direct file input.
    }

    public static void ReadFromJSON()
    {

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

    private static string ReadFile()
    {
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
