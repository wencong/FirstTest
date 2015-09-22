using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;

// 怪物生成器
public class MonsterCreator
{
    //private Dictionary<int, MonsterBase> m_dictMonsters = new Dictionary<int, MonsterBase>();

    private MonsterCreator(){
    }

    private static MonsterCreator instance = null; 

    public static MonsterCreator getInstance()
    {
        if (instance == null)
        {
            instance = new MonsterCreator();
        }
        return instance;
    }

    public void loadSettings()
    {
        StreamReader sr = null;
        sr = new StreamReader("Assets/Script/Settings/Monsters.txt");
        if (sr != null)
        {
            string strLine = null;
            bool bFirstLine = true;
            while ((strLine = sr.ReadLine()) != null)
            {
                if (bFirstLine)
                {
                    bFirstLine = false;
                    continue;
                }

                if (strLine.Length != 0)
                {
                    string[] arr = strLine.Split('\t');
                    MonsterBase mb = new MonsterBase();
                    
                    mb.nId          = Convert.ToInt32(arr[0]);
                    mb.szName       = arr[1];
                    mb.HP           = Convert.ToInt32(arr[2]);
                    mb.AP           = Convert.ToInt32(arr[3]);
                    mb.nAttack      = Convert.ToInt32(arr[4]);
                    mb.nDefence     = Convert.ToInt32(arr[5]);
                    mb.nSpeed       = Convert.ToInt32(arr[6]);
                    mb.nMagic       = Convert.ToInt32(arr[7]);
                    
                    mb.nFireDef     = Convert.ToInt32(arr[8]);
                    mb.nWindDef     = Convert.ToInt32(arr[9]);
                    mb.nWaterDef    = Convert.ToInt32(arr[10]);
                    mb.nEarthDef    = Convert.ToInt32(arr[11]);
                    
                    mb.nHolyDef     = Convert.ToInt32(arr[12]);
                    mb.nSpiritDef   = Convert.ToInt32(arr[13]);
                    mb.nStateDef    = Convert.ToInt32(arr[14]);
                    mb.nDeathDef    = Convert.ToInt32(arr[15]);

                    mb.nCutDef      = Convert.ToInt32(arr[16]);
                    mb.nShotDef     = Convert.ToInt32(arr[17]);
                    mb.nMagicDef    = Convert.ToInt32(arr[18]);
                    mb.nDragonDef   = Convert.ToInt32(arr[19]);
                    
                    mb.nExpierence  = Convert.ToInt32(arr[20]);
                    mb.nMoney       = Convert.ToInt32(arr[21]);
                    
                    mb.nItem1Id     = Convert.ToInt32(arr[22]);
                    mb.byItem1Drop  = Convert.ToByte(arr[23]);
                    mb.nItem2Id     = Convert.ToInt32(arr[24]);
                    mb.byItem2Drop  = Convert.ToByte(arr[25]);

                    string[] skills = arr[26].Split(',');
                    mb.nSkillId = new int[skills.Length];
                    for (int i = 0; i < skills.Length;  ++i)
                    {
                        mb.nSkillId[i] = Convert.ToInt32(skills[i]);
                    }
                }
            }
        }   
    }

    public GameObject createMonster(int nMonsterId)
    {
        return null;
    }
}

