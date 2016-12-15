using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class FishingField {
    public int ID;
    public string name;
    public List<int> regionsID = new List<int>();

    private List<WaterRegion> m_waterRegions = new List<WaterRegion>();

    public bool Init() {
        for (int i = 0; i < regionsID.Count; i++) {
            int regionID = regionsID[i];
            WaterRegion region = FishGameSetting.Instance.regionData.GetRegionByID(regionID);
            if (region != null) {
                m_waterRegions.Add(region);
            }
        }
        return true;
    }

    public bool UnInit() {
        m_waterRegions.Clear();
        return true;
    }

    public List<WaterRegion> GetRegions() {
        return m_waterRegions;
    }
}

