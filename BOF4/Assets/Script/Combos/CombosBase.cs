using UnityEngine;
using System.Collections;


/************************************************************************/
/* 
 * 【连锁技的基本概念】
连锁技（コンボ，Combos）是在战斗中连续使用特能时，给予该特能比原本更强威力的 
能力提升现象。当连锁技成功发动时，画面右上角会出现显示Hit数的对话框。
 * 
 * 【连锁技的发动条件】
1、发动连锁技的特能间须有一定相关性，详见表7；
2、两特能发动中间，没有敌方的行动插入。
 * 
 * 【连锁技的发动概率】
一般情况下，连锁技的发动概率是固定的。
从第一行动角色到第二行动角色，连锁技的发动概率为85%；
从第二行动角色到第三行动角色，连锁技的发动概率为75%。
 * 
 * 〖提升发动概率的三种方法〗
满足以下特定条件，连锁技的发动概率将有一定程度的提升，最高可达100%。
1、装备道具「和谐之戒/ハーモニクス」，可使发动概率提升10%。多人装备，效果累 
加，如发动连锁技的两名角色均装备「和谐之戒」，发动概率提升20%。
2、连续使用相同种类的特能，发动概率提升5%。
3、我方任一角色的速度比敌方成员速度的平均值高出1以上，发动概率提升5%。
 * 
 * 【连锁技的体系】
大体上，连锁技可以分为合成连锁技、连续连锁技和追加连锁技三种。

（1）合成连锁技
合成连锁技（合成コンボ）是将特定的特能组合使用后，生成一种新特能的魔法。生成 
的这种魔法具有多重属性，称作「重属魔法」（重属魔法）。

（2）连续连锁技
使用同种种类的特能形成的连续连锁技（连続コンボ）可提升特能的威力及成功概率， 
且伴有连锁技水平的提升。
主要效果：提升威力及成功概率。

（3）追加连锁技
追加连锁技（追加コンボ）的特徵是，在第二及第三序位发动的特能，继承了之前特能 
的属性，或伴有小威力的迷你魔法。因为与连续连锁技同时起作用，追加连锁技的威力 
和成功概率也得到了提升。
主要效果：属性继承，附加小威力的迷你魔法。
 
 */
/************************************************************************/

/************************************************************************/
/* 
 * 一般情况下，连锁技的发动概率是固定的。
从第一行动角色到第二行动角色，连锁技的发动概率为85%
从第二行动角色到第三行动角色，连锁技的发动概率为75%。

〖提升发动概率的三种方法〗
满足以下特定条件，连锁技的发动概率将有一定程度的提升，最高可达100%。
1、装备道具「和谐之戒/ハーモニクス」，可使发动概率提升10%。多人装备，效果累 
加，如发动连锁技的两名角色均装备「和谐之戒」，发动概率提升20%。
2、连续使用相同种类的特能，发动概率提升5%。
3、我方任一角色的速度比敌方成员速度的平均值高出1以上，发动概率提升5%。
3、我方任一角色的速度比敌方成员速度的平均值高出1以上，发动概率提升7%。
 */
/************************************************************************/

public class CombosBase {
    static public float m_defaultC1ToC2 = 0.85f;
    static public float m_defaultC2ToC3 = 0.75f;

    static public Skill[] chongshuFireWind = new Skill[3];
    static public Skill[] chongshuWindWater = new Skill[3];
    static public Skill[] chongshuWaterEarth = new Skill[3];
    static public Skill[] chongshuEarthFire = new Skill[3];


    static public Skill m_combos_skill;

    static public void init()
    {
        m_combos_skill = new Skill();
        m_combos_skill = null;

        chongshuFireWind[0] = new Skill();
        chongshuFireWind[0].nSkillLevel = 1;
        chongshuFireWind[0].szName = "轻度强力";
        chongshuFireWind[1] = new Skill();
        chongshuFireWind[1].nSkillLevel = 2;
        chongshuFireWind[1].szName = "中度";
        chongshuFireWind[2] = new Skill();
        chongshuFireWind[2].nSkillLevel = 3;
        chongshuFireWind[2].szName = "超强力";

        chongshuWindWater[0] = new Skill();
        chongshuWindWater[0].nSkillLevel = 1;
        chongshuWindWater[0].szName = "巴鲁";
        chongshuWindWater[1] = new Skill();
        chongshuWindWater[1].nSkillLevel = 2;
        chongshuWindWater[1].szName = "巴巴鲁";
        chongshuWindWater[2] = new Skill();
        chongshuWindWater[2].nSkillLevel = 3;
        chongshuWindWater[2].szName = "巴鲁哈拉";

        chongshuWaterEarth[0] = new Skill();
        chongshuWaterEarth[0].nSkillLevel = 1;
        chongshuWaterEarth[0].szName = "暴风雨";
        chongshuWaterEarth[1] = new Skill();
        chongshuWaterEarth[1].nSkillLevel = 2;
        chongshuWaterEarth[1].szName = "风暴";
        chongshuWaterEarth[2] = new Skill();
        chongshuWaterEarth[2].nSkillLevel = 3;
        chongshuWaterEarth[2].szName = "灾难";

        chongshuEarthFire[0] = new Skill();
        chongshuEarthFire[0].nSkillLevel = 1;
        chongshuEarthFire[0].szName = "沙滩";
        chongshuEarthFire[1] = new Skill();
        chongshuEarthFire[1].nSkillLevel = 2;
        chongshuEarthFire[1].szName = "岩浆";
        chongshuEarthFire[2] = new Skill();
        chongshuEarthFire[2].nSkillLevel = 3;
        chongshuEarthFire[2].szName = "梅可姆";
    }

    public static Skill CombosSkill(Skill firstSkill, Skill secondSkill, Skill combosSkill = null)
    {
        /************************************************************************/
        /* 
         * 合成连锁技 魔法
         * */
        /************************************************************************/
        if (firstSkill.nType >= Skill.SkillType.fire && secondSkill.nType >= Skill.SkillType.fire)
        {
            return CombosMagic(firstSkill, secondSkill);
        }
        return null;
    }

    public static Skill CombosMagic(Skill firstSkill, Skill secondSkill)
    {
        /************************************************************************/
        /* 
         * 完全同类型技能，威力+1
         */
        /************************************************************************/
        if (firstSkill.nType == secondSkill.nType)
        {
            m_combos_skill = secondSkill;
            m_combos_skill.nPowerLevel += 1;

            return m_combos_skill;
        }
        
        else if (!firstSkill.bMultiple)
        {
            if (secondSkill.bMultiple)
            {
                m_combos_skill = secondSkill;
                return m_combos_skill;
            }

        }

        return null;
    }


}
