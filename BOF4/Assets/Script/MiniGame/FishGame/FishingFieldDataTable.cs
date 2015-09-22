using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class FishingFieldDataTable : DataTable {
    private Dictionary<int, FishingField> m_FishFields = new Dictionary<int, FishingField>();

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

        return true;
    }

    protected override bool OnLoadComplete() {
        return true;
    }
}

