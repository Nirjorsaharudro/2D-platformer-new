using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillButton : MonoBehaviour
{
    public Text SkillPonintsText;
    public Image skillImage;
    public Text skillNameText;
    public Text skillDesText;
    public GameObject upgradeButton;
    public GameObject unlockButton;

    public int skillButtonId;  //For unique button Id
    private bool Unlocked = true;

    private void Update() {
        SkillPonintsText.text = skillManager.instance.skillPoints.ToString();
        //Changing images if skill is unlocked
        if(skillManager.instance.skills[skillButtonId].isUnlocked == true && Unlocked){
            Unlocked = false;
            GameObject skName = transform.GetChild(0).gameObject;
            skName.SetActive(true);
            GameObject skImage = transform.GetChild(1).gameObject;
            skImage.GetComponent<Image>().sprite = skillManager.instance.skills[skillButtonId].skillSprite;
            GameObject skCount = transform.GetChild(3).gameObject;
            skCount.GetComponent<Text>().text = "1";
        }
        //Increse Skill Item value if ugraded
        if(skillManager.instance.skills[skillButtonId].isUpgrade == true){
            skillManager.instance.skills[skillButtonId].isUpgrade = false;
            GameObject skCount = transform.GetChild(3).gameObject;
            int value = int.Parse(skCount.GetComponent<Text>().text);
            //Debug.Log(value);
            value++;
            string val = value.ToString();
            //Debug.Log(val);
            skCount.GetComponent<Text>().text = val;   
        }
    }
    
    //For upgrading or unlocking panel activation
    public void pressedSkillButton(){
        if(skillManager.instance.skills[skillButtonId].isUnlocked == true){
            upgradeButton.SetActive(true);
            unlockButton.SetActive(false);
        }else
        {
            upgradeButton.SetActive(false);
            unlockButton.SetActive(true);
        }
        skillManager.instance.activatedSkill = transform.GetComponent<Skill>();

        skillImage.sprite = skillManager.instance.skills[skillButtonId].skillSprite;
        skillNameText.text = skillManager.instance.skills[skillButtonId].skillName;
        skillDesText.text = skillManager.instance.skills[skillButtonId].skillDes; 
    }

}
