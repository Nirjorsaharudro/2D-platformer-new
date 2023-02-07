using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillManager : MonoBehaviour
{
    public static skillManager instance;
    
    public int skillPoints;
    public Skill[] skills;  //For all skills
    public skillButton[] skillButtons; //For all skill Button

    public Skill activatedSkill;

    private void Awake() {
        //Makeing script singeleton
        if(instance == null){
            instance = this;
        }else{
            if(instance != this){
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    public void unlock(){
        if(activatedSkill.requiredSkillPoint <= skillPoints)
        {
            skillPoints = skillPoints - activatedSkill.requiredSkillPoint;
            activatedSkill.isUnlocked = true; 
        }
    }

     public void upgrade(){
        if(activatedSkill.requiredUpgredingSkillPoint <= skillPoints)
        {
            skillPoints = skillPoints - activatedSkill.requiredUpgredingSkillPoint;
            activatedSkill.isUpgrade = true; 
        }
    }

    public void increaseSkillpoints(int level){
        skillPoints += (level*level);
    }

}
