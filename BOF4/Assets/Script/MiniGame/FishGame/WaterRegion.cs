using System;
using System.Collections.Generic;
using UnityEngine;

public class WaterRegion {
    public int ID;
    public string name;

    public float distance;
    public float height;

    public List<int> FishsID = new List<int>();

    private List<Fish> m_Fishes = new List<Fish>();

    public bool Init() {
        for (int i = 0; i < FishsID.Count; ++i) {
            int ID = FishsID[i];
            Fish fish = FishGameSetting.Instance.fishData.GetFishByID(ID);

            if (fish != null) {
                m_Fishes.Add(fish);
            }
        }
        return true;
        
    }

    public bool UnInit() {
        FishsID.Clear();
        m_Fishes.Clear();
        return true;
    }

    public bool IsPointInField(float distance, float height) {
        if (Math.Abs(this.distance - distance) > 5.0f) {
            return false;
        }
        if (Math.Abs(this.distance - distance) > 2.0f) {
            return false;
        }
        return true;
    }

    public List<Fish> GetFishes() {
        return m_Fishes;
    }
}

