using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;


public static class SettingConfig {
    public static string settingPath = "Package/Settings";
    public static string ext = "csv";
    public static char[] chSep = new char[1] { ',' };
    public static int maxColumns = 40;
}

public abstract class DataTable {
    private string m_filePath = null;
    private string[] m_curLineDatas = null;
    private Dictionary<string, int> m_keyMap = null;

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
        if (!bRetCode) {
            Log.Info("file is null or empty.");
            goto Exit0;
        }

        m_filePath = filePath;
        string fullPath = string.Format("{0}/{1}", SettingConfig.settingPath, filePath);

        Init();
        bRetCode = _Load(fullPath);
        UnInit();

        if (!bRetCode) {
            goto Exit0;
        }

        bResult = true;
    Exit0:
        return bResult;
    }

    public bool Init() {
        m_curLineDatas = new string[SettingConfig.maxColumns];
        m_keyMap = new Dictionary<string, int>();
        return true;
    }

    public bool UnInit() {
        m_curLineDatas = null;
        m_keyMap.Clear();
        m_keyMap = null;
        return true;
    }

    public bool _Load(string filePath) {
        bool bRetCode = false;
        bool bResult = false;

        Stream stream = null;
        StreamReader streamReader = null;
        TextAsset text = ResourceMgr.Instance().Load<TextAsset>(filePath);

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
            ResourceMgr.Instance().UnLoad(text);
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
            
            if (!bRetCode) {
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
        bResult = true;

    Exit0:
        return bResult;
    }

    private bool _SplitData(string line) {
        bool bRetCode = false;
        bool bResult = false;

        bool isText = false;

        for (int i = 0; i < line.Length; ++i) {
            char ch = line[i];
            if (ch == '"') {
                isText = !isText;
            }
            else {
                if (ch == SettingConfig.chSep[0]) {

                }
            }
        }

        bResult = true;
    Exit0:
        return bResult;
    }
}

