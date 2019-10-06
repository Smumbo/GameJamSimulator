using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TypingManager : MonoBehaviour
{
    public Line line;
    public Text cursor;
    public Text toType;
    public Text userInput;
    bool readText;
    MakeLines parent;

    void Start()
    {
        cursor.text = "│";
        toType.text = line.text;
        userInput.text = "";
        readText = true;
        parent = transform.parent.GetComponent<MakeLines>();
        
    }

    void Update()
    {
        if (!readText)
        {
            return;
        }
        string input = Input.inputString;

        // If we aren't typing, do nothing
        if (input.Equals(""))
        {
            return;
        }

        // If we are typing, check typed character
        string typing = "";
        char c = input[0];
        if (Input.GetKey(KeyCode.Return))
        {
            Debug.Log("TYPED : " + line.text);
            Debug.Log("MISTAKES: " + line.getMistakes());
            cursor.text = "";
            readText = false;
            parent.newManager();
            return;
        }
        string typed = line.read(c);
        typing += typed + "\n";

        // Update display
        userInput.text = typing;
        cursor.text = "";
        for (int i = 1; i < typing.Length; i++)
        {
            cursor.text += " ";
        }
        cursor.text += "│";
    }
}

[System.Serializable]
public class Line
{
    public string text;
    string hasTyped;
    int curChar;

    public Line(string t)
    {
        text = t;
        hasTyped = "";
        curChar = 0;
    }

    public string read(char c)
    {
        // backspace
        if (c.Equals('\b'))
        {
            if (curChar > 0)
            {
                curChar -= 1;
            }
            hasTyped = hasTyped.Substring(0, curChar);
        }
        // add characters
        else
        {
            curChar++;
            hasTyped += c;
        }
        return hasTyped;
    }

    public int getMistakes()
    {
        int mistakes = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (i >= hasTyped.Length)
            {
                mistakes += text.Length - hasTyped.Length;
                break;
            }
            else if (!hasTyped[i].Equals(text[i]))
            {
                mistakes += 1;
            }
        }
        if (hasTyped.Length > text.Length)
        {
            mistakes += hasTyped.Length - text.Length;
        }
        return mistakes;
    }
}