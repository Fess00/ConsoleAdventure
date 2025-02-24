﻿using System.Collections.Generic;

namespace ConsoleAdventure.Settings
{
    static public class Loger
    {
        static List<string> logs = new List<string>();

        public static void AddLog(string log)
        {
            logs.Add(log);
            if (logs.Count > 10)
            {
                logs.RemoveAt(0);
            }
        }

        public static void ClearLogs()
        {
            logs.Clear();
        }

        public static string GetLogs()
        {
            string output = string.Empty;
            if (logs.Count > 0)
            {
                output += "Logs:\n";
            }
            for (int i = 0; i < logs.Count; i++)
            {
                output += $"{logs[logs.Count - i - 1]}\n";
            }
            return output;
        }
    }
}
