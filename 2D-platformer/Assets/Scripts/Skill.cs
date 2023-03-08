using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For different skillAttributes
public class Skill : MonoBehaviour
{
   public string skillName;
   public Sprite skillSprite;

   [TextArea(1,3)]
   public string skillDes;

   public Skill parentSkill;
   public int requiredSkillPoint;
   public bool isUnlocked;
   public int requiredUpgredingSkillPoint;
   public bool isUpgrade;
}
