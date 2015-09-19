using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class FishPool : Singleton<FishPool>{
    public Dictionary<int, Fish> m_Fishes = new Dictionary<int, Fish>();

    public bool Init() {
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

