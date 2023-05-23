using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class EditorTools : Editor
{
    const string scriptExtension = ".cs";

    public static void WriteToEnum<T>(string path, string name, ICollection<T> data)
    {
        using (StreamWriter file = File.CreateText(path + name + scriptExtension))
        {
            file.WriteLine("public enum " + name + " \n{");

            int i = 0;
            foreach (var line in data)
            {
                string lineRep = line.ToString().Replace(" ", string.Empty);
                if (!string.IsNullOrEmpty(lineRep))
                {
                    file.WriteLine(string.Format("\t{0} = {1},",
                        lineRep, i));
                    i++;
                }
                else
                {
                    Debug.LogWarning("Enum value can't be empty!");
                }
            }

            file.WriteLine("\n}");
        }

        AssetDatabase.ImportAsset(path + name + scriptExtension);
    }
}
