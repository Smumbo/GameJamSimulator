using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeLines : MonoBehaviour
{
    List<TypingManager> lines;
    string[] logFile;

    void Start()
    {
        lines = new List<TypingManager>();
        logFile = File.ReadAllLines("Assets/Scripts/LineList.txt");
        for (int i = 0; i < logFile.Length; i++)
        {
            Debug.Log(logFile[i]);
        }
        newManager();
    }

    void Update()
    {
        
    }

    public void newManager()
    {
        var r = new System.Random();
        int randomLineIndex = r.Next(0, logFile.Length - 1);
        string randomLine = logFile[randomLineIndex];
    }
}