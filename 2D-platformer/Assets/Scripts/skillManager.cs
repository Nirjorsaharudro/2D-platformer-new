using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillManager : MonoBehaviour
{
    public static skillManager instance;
    
    public int skillPoints;
    public Skill[] skills;  //For all skills
    public skillButton[] skillButtons; //For all skill Button
    public GameObject canNotUnlockPanel;
    public GameObject unlockPanel;
    public GameObject notEnoughSpPanel;
    public Skill activatedSkill;
    [SerializeField]
    private Image skillImage;
    [SerializeField]
    private Text skillNameText;
    [SerializeField]
    private GameObject congratulationPanel;

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

    //For unlocking a skill
    public void unlock(){
        //Checking for required SkillPoint
        if(activatedSkill.requiredSkillPoint <= skillPoints)
        {
            canNotUnlockPanel.SetActive(false);
            //Checking Parent skill unlocked or not
            if (activatedSkill.parentSkill == null)
            {
                skillPoints = skillPoints - activatedSkill.requiredSkillPoint;
                activatedSkill.isUnlocked = true;
                unlockPanel.SetActive(false);
                congratulation();
            }
            else
            {
                Skill parentSkill = activatedSkill.parentSkill;
                if(parentSkill.isUnlocked == true)
                {
                    skillPoints = skillPoints - activatedSkill.requiredSkillPoint;
                    activatedSkill.isUnlocked = true;
                    unlockPanel.SetActive(false);
                    congratulation();
                }
                else
                {
                    canNotUnlockPanel.SetActive(true);
                }
            }
        }
        else
        {
            //For not Enoung xp activating a panel
            notEnoughSpPanel.SetActive(true);
        }
    }

    //For Upgrading the skill
     public void upgrade(){
        if(activatedSkill.requiredUpgredingSkillPoint <= skillPoints)
        {
            skillPoints = skillPoints - activatedSkill.requiredUpgredingSkillPoint;
            activatedSkill.isUpgrade = true; 
        }
        else
        {
            notEnoughSpPanel.SetActive(true);
        }
    }

    public void increaseSkillpoints(int level){
        skillPoints += (level*level);
    }

    //For activating congratulation panel
    public void congratulation()
    {
        congratulationPanel.SetActive(true);
        skillImage.sprite = activatedSkill.skillSprite;
        skillNameText.text = activatedSkill.skillName;
    }

}
