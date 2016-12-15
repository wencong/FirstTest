using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;


public static class SettingConfig {
    public static string settingPath = "Settings";
    public static string ext = "csv";
    public static char[] chSep = new char[1] { ',' };
    public static int maxColumns = 40;
}

public abstract class DataTable {
    private string m_filePath = null;
    private string[] m_curLineDatas = null;
    private Dictionary<string, int> m_keyMap = null;

    public abstract bool Init();
    public abstract bool UnInit();
    protected abstract bool OnParseLine(int nLineNum);
    protected abstract bool OnLoadComplete();

    public DataTable() {

    }

    public string GetFilePath() {
        return m_filePath;
    }

    public bool LoadFile(string filePath) {
        bool bRetCode = false;
        bool bResult = false;

        bRetCode = string.IsNullOrEmpty(filePath);
        if (bRetCode) {
            Log.Info("file is null or empty.");
            goto Exit0;
        }

        m_filePath = filePath;
        string fullPath = string.Format("{0}/{1}", SettingConfig.settingPath, filePath);

        _Init();
        bRetCode = _Load(fullPath);
        _UnInit();

        if (!bRetCode) {
            goto Exit0;
        }

        bResult = true;
    Exit0:
        return bResult;
    }

    private bool _Init() {
        m_curLineDatas = new string[SettingConfig.maxColumns];
        m_keyMap = new Dictionary<string, int>();
        return true;
    }

    private bool _UnInit() {
        m_curLineDatas = null;
        m_keyMap.Clear();
        m_keyMap = null;
        return true;
    }

    private bool _Load(string filePath) {
        bool bRetCode = false;
        bool bResult = false;

        Stream stream = null;
        StreamReader streamReader = null;
        TextAsset text = ResourceMgr.Instance.Load<TextAsset>(filePath);

        if (text == null) {
            Log.Error("Load Texture Failed: {0}", filePath);
            goto Exit0;
        }

        try {
            stream = new MemoryStream(text.bytes);
            streamReader = new StreamReader(stream);
        }
        catch (Exception ex){
            Log.Exception(ex);
            goto Exit0;
        }

        int lineNum = 0;
        while (true) {
            string line = streamReader.ReadLine();
            
            if (line == null) {
                break;
            }

            if (lineNum == 0) {
                bRetCode = _ParseColumn(line, lineNum);
                if (!bRetCode) {
                    Log.Error("Parse Column failed: {0}", filePath);
                    goto Exit0;
                }
            }
            else {
                bRetCode = _ParseData(line, lineNum);
                if (!bRetCode) {
                    Log.Error("Parse data failed, {0}:{1}", filePath, lineNum);
                    goto Exit0;
                }
            }
            lineNum++;
        }

        OnLoadComplete();
        bResult = true;

    Exit0:
        if (streamReader != null) {
            streamReader.Close();
            streamReader = null;
        }

        if (stream != null) {
            stream.Close();
            stream = null;
        }

        if (text != null) {
            ResourceMgr.Instance.UnLoad(text);
        }
        return bResult;
    }

    private bool _ParseColumn(string line, int lineNum) {
        bool bRetCode = false;
        bool bResult  = false;

        string[] columns = line.Split(SettingConfig.chSep);

        for (int i = 0; i < columns.Length; ++i) {
            string key = columns[i];
            bRetCode = m_keyMap.ContainsKey(key);
            
            if (bRetCode) {
                Log.Error("The key {0} is already exist in file: {1}", key, m_filePath);
                goto Exit0;
            }

            m_keyMap.Add(key, i);
        }

        bResult = true;
    Exit0:
        return bResult;
    }

    private bool _ParseData(string line, int lineNum) {
        bool bRetCode = false;
        bool bResult = false;

        bRetCode = _SplitData(line);
        if (!bRetCode) {
            goto Exit0;
        }

        bRetCode = OnParseLine(lineNum);
        if (!bRetCode) {
            goto Exit0;
        }

        bResult = true;

    Exit0:
        return bResult;
    }

    private bool _SplitData(string line) {
        bool bResult = false;

        bool isText = false;
        int nStartPos = 0;
        int nColumnCount = 0;

        for (int i = 0; i < line.Length; ++i) {
            char ch = line[i];
            if (ch == '"') {
                isText = !isText;
            }
            else if (ch == SettingConfig.chSep[0] && !isText) {
                string data = line.Substring(nStartPos, i - nStartPos);
                m_curLineDatas[nColumnCount] = _DeleteQuotes(data);
                nStartPos = i + 1;
                nColumnCount++;
                if (nColumnCount > SettingConfig.maxColumns) {
                    Log.Error("columnCount is beyond of the max value of maxColumns");
                    goto Exit0;
                }
            }
        }

        if (nStartPos < line.Length) {
            string data = line.Substring(nStartPos, line.Length - nStartPos);
            m_curLineDatas[nColumnCount++] = _DeleteQuotes(data);
        }

        bResult = true;
    Exit0:
        return bResult;
    }

    private string _DeleteQuotes(string s) {
        if (s.Length > 1 && s[0] == '"' && s[s.Length - 1] == '"') {
            s = s.Substring(1, s.Length - 2);
        }
        return s;
    }

    private string _GetValueByName(string name) {
        int nIndex = 0;

        if (m_keyMap.TryGetValue(name, out nIndex) &&
            nIndex < m_keyMap.Count) {
            string value = m_curLineDatas[nIndex];
            if (value != "" && value != null) {
                return value;
            }
        }

        return null;
    }

    protected string GetString(string name, string defaultValue = "", bool bMust = false) {
        string value = _GetValueByName(name);

        if (value == null) {
            //Log.Error("GetString failed : {0} in {1}", name, m_filePath);
            value = defaultValue;
        }

        return value;
    }

    protected int GetInt(string name, int defaultValue = 0, bool bMust = false) {
        string value = _GetValueByName(name);
        if (value == null) {
            //Log.Error("GetString failed : {0} in {1}", name, m_filePath);
            return defaultValue;
        }

        int nValue = 0;
        if (!int.TryParse(value, out nValue)) {
            //Log.Error("Parse value failed : {0} in {1}", name, m_filePath);
            return defaultValue;
        }
        return nValue;
    }
}

