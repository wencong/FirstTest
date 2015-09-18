using System;
using System.Collections.Generic;
using UnityEngine;

public class WaterField {
    private float m_fDiatance;
    private float m_fHeight;

    private List<Fish> m_Fishes = new List<Fish>();

    public bool Init(float distance, float height, int[] fishIDs) {
        m_fDiatance = distance;
        m_fHeight = height;

        for (int nIndex = 0; nIndex < fishIDs.Length; ++nIndex) {
            int ID = fishIDs[nIndex];
            Fish fish = FishPool.Instance().GetFish(ID);
            if (fish != null) {
                
            }
            else {
                Log.Info("The fish is not exist:{0}", ID);
            }
        }
            return true;
    }

    public bool IsPointInField(float distance, float height) {
        if (Math.Abs(m_fDiatance - distance) > 5.0f) {
            return false;
        }
        if (Math.Abs(m_fDiatance - distance) > 2.0f) {
            return false;
        }
        return true;
    }

    public List<Fish> GetFishes() {
        return m_Fishes;
    }
}

