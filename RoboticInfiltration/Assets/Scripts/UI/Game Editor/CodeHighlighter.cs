using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using TMPro;

using UnityEngine;

public class CodeHighlighter : MonoBehaviour {
    private bool editingFlag = false;

    private string[] keywords = new string[]{
        Commands.DISTANCE_MOVE_FORWARD_COMMAND,
        Commands.HALT_COMMAND,
        Commands.ROTATE_LEFT_COMMAND,
        Commands.ROTATE_RIGHT_COMMAND,
        Commands.TIMED_MOVE_FORWARD_COMMAND,
        Commands.WAIT_COMMAND
    };

    public TMP_InputField editorField;
    public Color keywordHighlight = Color.blue;

    public void OnCodeEdited(string code) {
        if (editingFlag)
            return;
        
        editingFlag = true;

        var caretPos = FindCaretStringPosition(code);

        code = StripMarkUp(code);

        code = AddHighlighting(code);

        editorField.text = code;
        editorField.stringPosition = FindNewCaretStringPosition(code, caretPos);

        editingFlag = false;
    }

    private int FindCaretStringPosition(string text) {
        int charsTotal = 0;
        int charsVisible = 0;

        while(charsTotal < editorField.stringPosition) {
            if(text[charsTotal] == '<') {
                while (charsTotal < editorField.stringPosition && text[charsTotal] != '>')
                    charsTotal++;

                charsTotal++;
                continue;
            }

            charsTotal++;
            charsVisible++;
        }

        return charsVisible;
    }

    private string StripMarkUp(string text) {
        var builder = new StringBuilder();

        int index = 0;

        while (index < text.Length) {
            if (text[index] == '<') {
                while (index < text.Length && text[index] != '>')
                    index++;

                index++;
                continue;
            }

            builder.Append(text[index]);

            index++;
        }

        return builder.ToString();
    }

    private string AddHighlighting(string text) {
        // TODO, do this in steps to keep formatting
        //var words = text.Split('\n', ' ', '\t');

        //var builder = new StringBuilder();

        //foreach (var word in words) {
        //    if (Array.IndexOf(keywords, word) > -1) {
        //        builder.Append($"<color=#{ColorUtility.ToHtmlStringRGB(keywordHighlight)}>");
        //        builder.Append(word);
        //        builder.Append($"</color>");
        //    } else {
        //        builder.Append(word);
        //    }
        //}

        //return builder.ToString();

        var lines = text.Split('\n');

        var builder = new StringBuilder();

        foreach(var line in lines) {
            builder.Append($"{AddHighlightingPerLine(line)}\n");
        }

        return builder.ToString();
    }

    private string AddHighlightingPerLine(string line) {
        var words = line.Split(' ', '\t');

        for(int i = 0; i < words.Length; i++) {
            if(Array.IndexOf(keywords, words[i]) > -1) {
                words[i] = $"<color=#{ColorUtility.ToHtmlStringRGB(keywordHighlight)}>{words[i]}</color>";
            }
        }

        var builder = new StringBuilder();

        var index = 0;
        var currentWord = 0;

        while(index < line.Length) {
            if(line[index] == ' ' || line[index] == '\t') {
                builder.Append(line[index]);
                index++;
            } else {
                builder.Append(words[currentWord]);
                currentWord++;

                while (index < line.Length && line[index] != ' ' && line[index] != '\t')
                    index++;
            }
        }

        return builder.ToString();
    }

    private IEnumerator MoveCaret() {
        yield return new WaitForEndOfFrame();
        editorField.MoveTextEnd(false);
    }

    private int FindNewCaretStringPosition(string text, int caretPos) {
        int newPos = 0;

        while(newPos < text.Length) {
            if(text[newPos] == '<') {
                while (newPos < text.Length && text[newPos] != '>')
                    newPos++;

                newPos++;
                continue;
            }

            if (caretPos == 0)
                return newPos;

            caretPos--;
            newPos++;
        }

        return newPos;
    }
}
