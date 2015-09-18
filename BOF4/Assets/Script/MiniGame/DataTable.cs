using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;


public static class SettingConfig {
    public static string settingPath = "Package/Settings";
    public static string ext = "csv";
}

public abstract class DataTable {
    private string m_filePath = null;
    private char m_chSep = ',';

    private Dictionary<string, int> m_keyMap = new Dictionary<string, int>();

    protected abstract bool OnParseLine(int nLineNum);
    protected abstract bool OnLoaded();

    public DataTable() {

    }

    public string GetFilePath() {
        return m_filePath;
    }

    public bool LoadFile(string filePath) {
        if (string.IsNullOrEmpty(filePath)) {
            return false;
        }

        m_filePath = filePath;

        string fullPath = string.Format("{0}/{1}", SettingConfig.settingPath, filePath);

        return true;
    }

    public bool _Load(string filePath) {
        bool bRetCode = false;
        bool bResult = false;

        StreamReader streamReader = null;

        TextAsset text = Resources.Load<TextAsset>(filePath);

        if (text == null) {
        }

        bResult = true;

        return bResult;
    }
}

