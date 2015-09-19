using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class FishGame : MonoBehaviour, IMiniGame {
    private FishDataTable fishData = null;

    void Start() {
        fishData = new FishDataTable();
        fishData.LoadFile("fish");
    }

    void Update() {

    }
}

