using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class FishingFieldDataTable : DataTable {
    private Dictionary<int, FishingField> m_FishFields = new Dictionary<int, FishingField>();

    public FishingField GetFishingFieldByID(int ID) {
        FishingField field = null;
        m_FishFields.TryGetValue(ID, out field);
        return field;
    }

    public override bool Init() {
        foreach (FishingField field in m_FishFields.Values) {
            field.Init();
        }
        return true;
    }

    public override bool UnInit() {
        return true;
    }

    protected override bool OnParseLine(int nLineNum) {
        FishingField field = new FishingField();
        
        field.ID = GetInt("ID");
        field.name = GetString("Name");

        int regionID = GetInt("Region1");
        field.regionsID.Add(regionID);

        regionID = GetInt("Region2");
        field.regionsID.Add(regionID);

        regionID = GetInt("Region3");
        field.regionsID.Add(regionID);

        regionID = GetInt("Region4");
        field.regionsID.Add(regionID);

        regionID = GetInt("Region5");
        field.regionsID.Add(regionID);

        m_FishFields.Add(field.ID, field);

        return true;
    }

    protected override bool OnLoadComplete() {
        return true;
    }
}

