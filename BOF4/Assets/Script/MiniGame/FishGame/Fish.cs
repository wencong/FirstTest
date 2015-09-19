using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public enum FishShadowType
{
    CircleType,
    FishType,
    BarType
}

public class Fish : Item
{
    public FishShadowType m_shadowType;
    public int minSize;
    public int maxSize;
    public int minPower;
    public int maxPower;
    public int minPoint;
    public int maxPoint;

    public int[] baitList = new int[(int)EnumBaitType.TypeCount];


    public Fish() {

    }

    public bool IsEatBait(Bait bait) {
        int nNeedLevel = baitList[(int)bait.type];
        if (nNeedLevel <= bait.level && nNeedLevel != -1){
            return true;
        }
        return false;
    }
}