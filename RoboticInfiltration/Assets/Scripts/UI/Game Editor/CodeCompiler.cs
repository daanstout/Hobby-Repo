using System.Collections;
using System.Collections.Generic;
using System.Text;

using TMPro;

using UnityEngine;

public class CodeCompiler : MonoBehaviour {
    public RobotEntity entity;
    public TMP_InputField code;

    public void Compile() {
        var lines = StripMarkUp(code.text).Split('\n');

        entity.SetCommands(lines);
        entity.Restart();
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
}
