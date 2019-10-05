using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TypingManager : MonoBehaviour
{
    public List<Line> lines;
    public Text display;
    public Text cursor;

    void Start()
    {
        lines.Add(new Line("void Start()"));
    }

    // Update is called once per frame
    void Update()
    {
        string input = Input.inputString;

        // If we aren't typing, do nothing
        if (input.Equals(""))
        {
            return;
        }

        // If we are typing, check typed character
        string typing = "";
        char c = input[0];
        for (int i = 0; i < lines.Count; i++)
        {
            Line line = lines[i];
            string typed = line.continueText(c);
            typing += typed + "\n";
            // If we typed the whole word
            if (typed.Equals(line.text))
            {
                // Remove word from list
                Debug.Log("TYPED : " + line.text);
                lines.Remove(line);
                break;
            }
            
        }
        display.text = typing;
        cursor.text = "";
        for (int i = 1; i < typing.Length; i++)
        {
            cursor.text += " ";
        }
        cursor.text += "|";
    }
}

[System.Serializable]
public class Line
{
    public string text;
    public UnityEvent onTyped;
    string hasTyped;
    int curChar;

    public Line(string t)
    {
        text = t;
        onTyped = new UnityEvent();
        hasTyped = "";
        curChar = 0;
    }

    public string continueText(char c)
    {
        if (c.Equals('\b'))
        {
            if (curChar > 0)
            {
                curChar -= 1;
            }
            hasTyped = hasTyped.Substring(0, curChar);
        }
        else if (curChar < text.Length)
        {
            curChar++;
            hasTyped += c;
        }
        return hasTyped;
    }
}