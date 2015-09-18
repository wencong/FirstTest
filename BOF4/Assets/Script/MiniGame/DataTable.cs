using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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
}

