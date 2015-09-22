using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class FishingField {
    public int ID;
    public string name;
    public List<int> regionsID = new List<int>();

    private List<WaterRegion> m_waterFields = new List<WaterRegion>();

    public bool Init() {

        return true;
    }

    public bool UnInit() {
        m_waterFields.Clear();
        return true;
    }
}

