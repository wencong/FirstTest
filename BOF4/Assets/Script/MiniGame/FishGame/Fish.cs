using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public enum FishShadowType
{
    FishType,
    CircleType,
    BarType
}

public class Fish : Item
{
    private float m_fSize;
    private float m_fManual;
    private FishShadowType m_shadowType;

    private float m_fMinSize;
    private float m_fMaxSize;

    private bool[] m_eatBaits = new bool[(int)EnumBaitType.Count];
    public Fish(string name, int id, float manual,
                FishShadowType type, float size,
                float minSize, float maxSize) 
                 : base(name, id) {
        m_fManual = manual;
        m_shadowType = type;
        m_fSize = size;

        m_fMinSize = minSize;
        m_fMaxSize = maxSize;
    }

    public FishShadowType ShadowType {
        get {
            return m_shadowType;
        }
    }

    public bool InitEatBait(EnumBaitType type) {
        m_eatBaits[(int)type] = true;
        return true;
    }

    public bool IsEatBait(Bait bait) {
        return m_eatBaits[(int)bait.BaitType];
    }
}

public class DazuiFish : Fish {
    public DazuiFish(string name, int id, float manual,
                     FishShadowType type, float size,
                     float minSize, float maxSize) : 
                     base (name, id, manual, type, size, minSize, maxSize){

    }
}
