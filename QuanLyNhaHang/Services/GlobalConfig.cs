using System;
using System.Collections.Generic;
using FirebirdSql.Data.FirebirdClient;

namespace QuanLyNhaHang.Services
{
    public static class GlobalConfig
    {
        private static Dictionary<string, string> _configs = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private static Dictionary<string, int> _intConfigs = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        private static Dictionary<string, decimal> _decConfigs = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase);
        
        public static void LoadAllConfigs(string connectionString)
        {
            _configs.Clear();
            _intConfigs.Clear();
            _decConfigs.Clear();
            if (string.IsNullOrEmpty(connectionString)) return;

            try
            {
                using (FbConnection conn = new FbConnection(connectionString))
                {
                    conn.Open();
                    using (FbCommand cmd = new FbCommand("SELECT NAME, TEXTVALUE, INTVALUE, DECIMALVALUE, DATATYPE FROM SCONFIG WHERE STATUS = 30", conn))
                    {
                        using (FbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string key = reader["NAME"]?.ToString()?.Trim();
                                if (string.IsNullOrEmpty(key)) continue;

                                string textVal = reader["TEXTVALUE"] != DBNull.Value ? reader["TEXTVALUE"]?.ToString() : null;
                                string intVal = reader["INTVALUE"] != DBNull.Value ? reader["INTVALUE"]?.ToString() : null;
                                string decVal = reader["DECIMALVALUE"] != DBNull.Value ? reader["DECIMALVALUE"]?.ToString() : null;

                                if (!string.IsNullOrEmpty(intVal) && int.TryParse(intVal, out int iv))
                                {
                                    _intConfigs[key] = iv;
                                }

                                if (!string.IsNullOrEmpty(decVal) && decimal.TryParse(decVal, out decimal dv))
                                {
                                    _decConfigs[key] = dv;
                                }

                                if (!string.IsNullOrEmpty(textVal))
                                {
                                    _configs[key] = textVal;
                                }
                                else if (!string.IsNullOrEmpty(intVal))
                                {
                                    _configs[key] = intVal;
                                }
                                else if (!string.IsNullOrEmpty(decVal))
                                {
                                    _configs[key] = decVal;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading config: " + ex.Message);
            }
        }

        public static string Get(string key, string defaultValue = "")
        {
            if (_configs.TryGetValue(key, out string val) && !string.IsNullOrEmpty(val))
                return val;
            if (_intConfigs.TryGetValue(key, out int iv))
                return iv.ToString();
            if (_decConfigs.TryGetValue(key, out decimal dv))
                return dv.ToString();
            return defaultValue;
        }

        public static int GetInt(string key, int defaultValue = 0)
        {
            if (_intConfigs.TryGetValue(key, out int i))
                return i;
            if (_configs.TryGetValue(key, out string val) && int.TryParse(val, out int parsed))
                return parsed;
            return defaultValue;
        }

        public static decimal GetDecimal(string key, decimal defaultValue = 0)
        {
            if (_decConfigs.TryGetValue(key, out decimal d))
                return d;
            if (_intConfigs.TryGetValue(key, out int iv))
                return iv;
            if (_configs.TryGetValue(key, out string val) && decimal.TryParse(val, out decimal parsed))
                return parsed;
            return defaultValue;
        }
    }
}
