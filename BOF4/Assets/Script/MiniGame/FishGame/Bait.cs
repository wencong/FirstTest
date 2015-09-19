using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum EnumBaitType {
    XuanZhuanType,
    NiErType,
    DingJiType,
    CiYaoType,
    QingWaType,
    ChongType,
    YaoShiType,
    TypeCount
}

public class Bait : Item {
    public EnumBaitType type;
    public int level;

    public Bait() {
    }

}
