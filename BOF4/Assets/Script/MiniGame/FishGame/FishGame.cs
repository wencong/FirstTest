using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class FishGame : Singleton<FishGame>, IMiniGame {
    private bool ShowInfo = true;

    public bool Load() {
        return FishGameSetting.Instance().LoadSettings();
    }

    public bool Init() {
        return FishGameSetting.Instance().Init();
    }

    public bool Start() {
        return true;
    }

    public void Update() {
        if (ShowInfo) {
            string info = "";
            FishingField field = FishGameSetting.Instance().fieldData.GetFishingFieldByID(1);
            info += string.Format("钓鱼场-{0}-{1} \r\n", field.ID, field.name);

            List<WaterRegion> regions = field.GetRegions();
            foreach (var region in regions) {
                info += string.Format("  区域-{0}-{1}\r\n", region.ID, region.name);

                List<Fish> fishes = region.GetFishes();
                foreach (var fish in fishes) {
                    info += string.Format("    {0}-{1}\r\n", fish.ID, fish.name);
                }
            }

            Log.Info(info);
            ShowInfo = false;
        }
    }

    public bool Stop() {
        return FishGameSetting.Instance().UnInit();
    }
}

