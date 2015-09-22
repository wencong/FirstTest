using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BaitDataTable : DataTable {
    public override bool Init() {
        return false;
    }

    public override bool UnInit() {
        return false;
    }

    protected override bool OnParseLine(int nLineNum) {
        return false;
    }
    protected override bool OnLoadComplete() {
        return false;
    }
}

