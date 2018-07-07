using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CSVManager{
    
    // Reference : https://bravenewmethod.com/2014/09/13/lightweight-csv-reader-for-unity/#comment-7111
    public static List<Dictionary<string, object>> Read(string file)
    {
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
        TextAsset readData = Resources.Load(file) as TextAsset;

        string[] readLine = Regex.Split(readData.text, "\n|\r");
        string[] header = Regex.Split(readLine[0], ",");

        for (int i = 1; i < readLine.Length; i++)
        {
            string[] values = Regex.Split(readLine[i], ",");
            if (values.Length == 0 || values[0] == "") continue;

            Dictionary<string, object> splitValue = new Dictionary<string, object>();

            for (int j = 0; j < header.Length && j < values.Length; j++)
            {
                string value = values[j];
                
                value = value.TrimStart('\"').TrimEnd('\"').Replace("\\", "");
                object finalvalue = value;

                int n;
                float f;

                if (int.TryParse(value, out n))
                {
                    finalvalue = n;
                }
                else if (float.TryParse(value, out f))
                {
                    finalvalue = f;
                }

                splitValue[header[j]] = finalvalue;
            }
            list.Add(splitValue);
        }
        return list;
    }
}