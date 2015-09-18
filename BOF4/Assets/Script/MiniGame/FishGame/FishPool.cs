using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class FishPool : Singleton<FishPool>{
    public Dictionary<int, Fish> m_Fishes = new Dictionary<int, Fish>();

    public bool Init() {
        m_Fishes.Add(1, new DazuiFish("大嘴鱼", 1, 5, FishShadowType.BarType, 100, 10, 400));

        return true;
    }

    public bool UnInit() {
        m_Fishes.Clear();
        return true;
    }

    public Fish GetFish(int ID) {
        Fish fish = null;
        m_Fishes.TryGetValue(ID, out fish);
        return fish;
    }
}

