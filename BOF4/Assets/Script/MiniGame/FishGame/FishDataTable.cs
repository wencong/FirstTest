using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class FishDataTable : DataTable {
    private Dictionary<int, Fish> Fishes = new Dictionary<int, Fish>();

    protected override bool OnParseLine(int nLineNum) {
        Fish fish = new Fish();

        fish.ID = GetInt("ID");
        fish.name = GetString("Name");
        fish.m_shadowType = (FishShadowType)GetInt("ShadowType");

        fish.minSize = GetInt("MinSize");
        fish.maxSize = GetInt("MaxSize");

        fish.minPower = GetInt("MinPower");
        fish.maxPower = GetInt("MaxPower");

        fish.minPoint = GetInt("MinPoint");
        fish.maxPoint = GetInt("MaxPoint");

        fish.buyPrice = GetInt("BuyPrice");
        fish.sellPrice = GetInt("SellPrice");

        fish.baitList[0] = GetInt("Xuanzhuan");
        fish.baitList[1] = GetInt("Nier");
        fish.baitList[2] = GetInt("Dingji");
        fish.baitList[3] = GetInt("Ciyao");
        fish.baitList[4] = GetInt("Qingwa");
        fish.baitList[5] = GetInt("Chong");
        fish.baitList[6] = GetInt("Yaoshi");

        fish.comment = GetString("Comment");

        Fishes.Add(fish.ID, fish);
        Log.Info(fish.name);
        Log.Info(fish.comment);
        return true;   
    }

    protected override bool OnLoadComplete() {
        return true;
    }
}

