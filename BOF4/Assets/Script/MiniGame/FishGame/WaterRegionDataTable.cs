using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class WaterRegionDataTable : DataTable {
    private Dictionary<int, WaterRegion> m_waterRegions = new Dictionary<int, WaterRegion>();

    public WaterRegion GetRegionByID(int ID) {
        WaterRegion region = null;
        m_waterRegions.TryGetValue(ID, out region);
        return region;
    }

    public override bool Init() {
        foreach (WaterRegion region in m_waterRegions.Values) {
            region.Init();
        }
        return true;
    }

    public override bool UnInit() {
        return true;
    }

    protected override bool OnParseLine(int nLineNum) {
        WaterRegion wr = new WaterRegion();
        
        wr.ID = GetInt("ID");
        wr.name = GetString("Name");

        int FishID = GetInt("Fish1");
        wr.FishsID.Add(FishID);

        FishID = GetInt("Fish2");
        wr.FishsID.Add(FishID);

        FishID = GetInt("Fish3");
        wr.FishsID.Add(FishID);

        FishID = GetInt("Fish4");
        wr.FishsID.Add(FishID);

        FishID = GetInt("Fish5");
        wr.FishsID.Add(FishID);

        m_waterRegions.Add(wr.ID, wr);
        return true;
    }

    protected override bool OnLoadComplete() {
        return true;
    }
    
}

