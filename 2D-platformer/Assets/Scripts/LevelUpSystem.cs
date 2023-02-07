using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpSystem : MonoBehaviour
{
    public int level;
    public float currentXp;
    public float requireXp;

    private float lerpTimer;
    private float delayTimer;
    [Header("UI")]
    public Image frontXpBar;
    public Image backXpBar;
    [Header("Multipliers")]
    [Range(1f,300f)]
    public float additionMultiplier = 300f;
    [Range(2f,4f)]
    public float powerMultiplier = 2f;
    [Range(7f,14f)]
    public float divisionMultiplier = 7f;

    // Start is called before the first frame update
    void Start()
    {
        requireXp = CalculateRequiredXp();
        frontXpBar.fillAmount = currentXp / requireXp;
        backXpBar.fillAmount = currentXp / requireXp;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateXpUI();
        if(currentXp > requireXp)
            LevelUp();
    }

    public void UpdateXpUI()
    {
        float xpFraction = currentXp / requireXp;
        float Fxp = frontXpBar.fillAmount;
        if(Fxp < xpFraction)
        {
            delayTimer += Time.deltaTime;
            backXpBar.fillAmount = xpFraction;
            if(delayTimer > 2)
            {
                lerpTimer += Time.deltaTime;
                float percentComplete = lerpTimer / 4;
                frontXpBar.fillAmount = Mathf.Lerp(Fxp,backXpBar.fillAmount,percentComplete);
            }
        }
    }
    
    //Increase xp
    public void GainExperienceFlatRate(float xpGained)
    {
        currentXp += xpGained;
        lerpTimer = 0;
    }
    
    //For increase level and skillPoints
    public void LevelUp(){
        level++;
        frontXpBar.fillAmount = 0f;
        backXpBar.fillAmount = 0f;
        currentXp = Mathf.RoundToInt(currentXp - requireXp);
        skillManager.instance.increaseSkillpoints(level);
        requireXp = CalculateRequiredXp();
    }
    
    //For calculating required Xp using algorithm
    private int CalculateRequiredXp()
    {
        int solveForRequiredXp = 0;
        for(int levelCycle = 1;levelCycle <= level;levelCycle++)
        {
            solveForRequiredXp += (int)Mathf.Floor(levelCycle + additionMultiplier * Mathf.Pow(powerMultiplier,
                levelCycle / divisionMultiplier));
        }
        return solveForRequiredXp / 4;
    }
}
