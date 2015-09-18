using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class FishingField {
    private string m_name = "海边的钓鱼场";
    private Vector3 m_posOri;
    private List<WaterField> m_waterFields = new List<WaterField>();

    public bool Init(string name) {
        m_name = name;
        m_posOri = new Vector3(0, 0, 0);
        /*
         * load config;
         * for()
         * {
         *       WaterField wf = new WaterField(...);
         *       m_waterField.Add(wf);
         * }
         */ 
        return true;
    }

    public bool UnInit() {
        m_waterFields.Clear();
        return true;
    }
}

