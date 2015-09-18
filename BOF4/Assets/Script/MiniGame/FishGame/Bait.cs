using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum EnumBaitType {
    QingWaType,
    ChongType,
    XuanZhuanQiType,
    Count
}

public class Bait : Item {
    private EnumBaitType m_type;
    private int m_nTastetLevel;

    public Bait(string name, int id, EnumBaitType type, int level) : base(name, id) {
        m_type = type;
        m_nTastetLevel = level;
    }

    public int TasteLevel {
        get {
            return m_nTastetLevel;
        }
        set {
            m_nTastetLevel = value;
        }
    }

    public EnumBaitType BaitType {
        get {
            return m_type;
        }
    }
}
