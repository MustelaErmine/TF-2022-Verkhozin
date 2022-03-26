﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class Save
{
    public static Save _instance = null;
    public static Save Instance { set => _instance = value; 
        get
        {
            if (_instance == null)
                Load();
            return _instance;
        } 
    }

    private static readonly string path = Application.persistentDataPath + @"\save.json";

    public static void Load()
    {
        if (!File.Exists(path))
        {
            Instance = new Save();
            Keep();
        }
        Instance = JsonConvert.DeserializeObject<Save>(File.ReadAllText(path));
    }
    public static void Keep()
    {
        File.WriteAllText(path, JsonConvert.SerializeObject(_instance));
    }

    public int lastLevel = 0;
}
