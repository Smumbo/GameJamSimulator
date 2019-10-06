using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeLines : MonoBehaviour
{
    List<TypingManager> lines;

    void Start()
    {
        lines = new List<TypingManager>();
        newManager();
    }

    void Update()
    {
        
    }

    public void newManager()
    {
        newManager("void Start()");
    }

    public void newManager(string line)
    {
        TypingManager tm = new TypingManager();
        tm.line = line;
        lines.Add(tm);
    }
}

