using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class FishGameSetting : Singleton<FishGameSetting>, IGameSetting {

    public FishDataTable fishData = new FishDataTable();
    public WaterRegionDataTable regionData = new WaterRegionDataTable();
    public FishingFieldDataTable fieldData = new FishingFieldDataTable();

    public bool LoadSettings() {
        bool bRetCode = false;
        bool bResult = false;

        bRetCode = fishData.LoadFile("Fish");
        if (bRetCode) {
            goto Exit0;
        }

        bRetCode = regionData.LoadFile("WaterRegion");
        if (bRetCode) {
            goto Exit0;
        }

        bRetCode = fieldData.LoadFile("FishField");
        if (bRetCode) {
            goto Exit0;
        }

        bResult = true;
    Exit0:
        return bResult;
        
    }
    public bool Init() {
        bool bRetCode = false;
        bool bResult = false;

        bRetCode = fishData.Init();
        if (bRetCode) {
            goto Exit0;
        }

        bRetCode = regionData.Init();
        if (bRetCode) {
            goto Exit0;
        }

        bRetCode = fieldData.Init();
        if (bRetCode) {
            goto Exit0;
        }

        bResult = true;
    Exit0:
        return bResult;
    }
    public bool UnInit() {
        bool bRetCode = false;
        bool bResult = false;

        bRetCode = fishData.UnInit();
        if (bRetCode) {
            goto Exit0;
        }

        bRetCode = regionData.UnInit();
        if (bRetCode) {
            goto Exit0;
        }

        bRetCode = fieldData.UnInit();
        if (bRetCode) {
            goto Exit0;
        }

        bResult = true;
    Exit0:
        return bResult;
    }

}

