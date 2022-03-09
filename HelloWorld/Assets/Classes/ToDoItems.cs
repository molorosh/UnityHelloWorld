using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[Serializable]
public class ToDoItems
{
    public List<ToDoItem> Items { get; set; }

    public ToDoItems()
    {
        Items = new List<ToDoItem>();
    }
}

[Serializable]
public class ToDoItem
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public string Title { get; set; }

    public ToDoItem()
    {

    }
}

public class ToDoMgr
{
    private static ToDoItems list { get; set; }
    private static string filename = "ToDoList.xml";
    private static string filepath { get; set; }
    private static XmlSerializer serializer = new XmlSerializer(typeof(ToDoItems));

    private static void PreCheck()
    {
        Debug.Log("PreCheck()");
        if (list == null)
        {
            Debug.Log("list not created");
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            filepath = System.IO.Path.Combine(folder, filename);
            Debug.Log(filepath);
            if (System.IO.File.Exists(filepath))
            {
                try
                {
                    using (TextReader reader = new StreamReader(filepath))
                    {
                        list = (ToDoItems)serializer.Deserialize(reader);
                        Debug.Log("file was deserialised");
                        Debug.Log("count is " + list.Items.Count.ToString());
                    }
                }
                catch(Exception e)
                {
                    list = null;
                    Debug.Log("problem reading file:" + e.Message);
                }
            }
            if (list == null)
            {
                list = new ToDoItems();
                try
                {
                    using (TextWriter writer = new StreamWriter(filepath))
                    {
                        serializer.Serialize(writer, list);
                        Debug.Log("file was initially serialised");
                    }
                }
                catch(Exception error)
                {
                    Debug.Log("problem creating initial file: " + error.Message);
                    list = null;
                }
            }
        }
        else
        {
            Debug.Log("list already created");
        }
    }

    public static void Add(string msg)
    {
        Debug.Log("add + " + msg);
        PreCheck();
        list.Items.Add(new ToDoItem { CreatedAt = DateTime.Now, Id = Guid.NewGuid(), Title = msg });
        Save();
    }

    private static void Save()
    {
        try
        {
            using (TextWriter writer = new StreamWriter(filepath))
            {
                serializer.Serialize(writer, list);
                Debug.Log("file was serialised");
            }
        }
        catch (Exception error)
        {
            Debug.Log("problem saving file: " + error.Message);
            list = null;
        }
    }

    public static void Create()
    {
        PreCheck();
    }
}
