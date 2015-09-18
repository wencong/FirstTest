using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MonsterBase
{
    /************************************************************************/
    /* 
     * 基础属性
     */
    /************************************************************************/
    public int nId;                          // 怪物ID
    public string szName;                      // 怪物名字
    public int HP;                             // hp
    public int AP;                             // AP
    public int nAttack;                        // 攻击力
    public int nDefence;                       // 防御力
    public int nSpeed;                         // 速度
    public int nMagic;                         // 魔力

    /************************************************************************/
    /* 
     * 元素抗性
     */
    /************************************************************************/
    public int nFireDef;                          // 火
    public int nWindDef;                          // 风
    public int nWaterDef;                         // 水
    public int nEarthDef;                         // 土

    /************************************************************************/
    /* 
     * 精神抗性
     */
    /************************************************************************/
    public int nHolyDef;                          // 神圣
    public int nSpiritDef;                        // 精神
    public int nStateDef;                         // 状态
    public int nDeathDef;                         // 死亡

    /************************************************************************/
    /* 
     * 物理抗性
     */
    /************************************************************************/
    public int nCutDef;                           // 斩击
    public int nShotDef;                          // 射击
    public int nMagicDef;                         // 魔法
    public int nDragonDef;                        // 吐息

    /************************************************************************/
    /* 
     * expirence and money
     */
    /************************************************************************/
    public int nExpierence;
    public int nMoney;

    /************************************************************************/
    /* 
     * Item
     */
    /************************************************************************/
    public int nItem1Id;
    public byte byItem1Drop;
    public int nItem2Id;
    public byte byItem2Drop;

    /************************************************************************/
    /* 
     * Skill
     */
    /************************************************************************/
    public int[] nSkillId;
}