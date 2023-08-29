using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;   // 使用清單List需要的命名空間
using System.Linq;					// 處理資料

public class LevelManager : MonoBehaviour
{
    [Header("經驗值")]
    public Image imgExp;
    [Header("文字等級")]
    public TextMeshProUGUI textLv;
    [Header("文字經驗值")]
    public TextMeshProUGUI textExp;
    [Header("升級面板")]
    public GameObject goLvUp;
    [Header("技能1~3")]
    public GameObject[] goSkillUI;

    /// <summary>
    /// 0 吸取經驗值
    /// 1 斧頭攻擊
    /// 2 斧頭間隔
    /// 3 玩家血量
    /// 4 移動速度
    /// </summary>

    [Header("技能資料陣列")]
    public DataSkill[] dataSkills;

    // 使用清單儲存技能資料
    public List<DataSkill> randomSkill = new List<DataSkill>();

    private int lv = 1;
    private float exp = 0;

    public float[] expNeeds = { 100, 200, 300 };

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Keypad1)) AddExp(100);
#endif
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // print($"<color=#6699ff>{collision.name}</color>");

        if (collision.name.Contains("經驗值"))
        {
            collision.GetComponent<ExpSystem>().enabled = true;
        }
    }


    public void AddExp(float exp)
    {
        this.exp += exp;

        if (this.exp >= expNeeds[lv - 1])
        {
            this.exp -= expNeeds[lv - 1];
            lv++;
            textLv.text = lv.ToString();
            LevelUp();
        }

        textExp.text = this.exp + "/" + expNeeds[lv - 1];
        imgExp.fillAmount = this.exp / expNeeds[lv - 1];
    }

    [Header("關閉")]
    public GameObject btnClose;

    private void LevelUp()
    {
        AudioClip sound = SoundManager.instance.soundLvUp;
        SoundManager.instance.PlaySound(sound, 0.8f, 1.2f);

        goLvUp.SetActive(true);
        Time.timeScale = 0;

        // x.skillLv < 5 為條件; 挑出所有等級小於 5 的技能 (挑選"全部技能資料"內小於五的技能)
        randomSkill = dataSkills.Where(x => x.skillLv < 5).ToList();
        // Random.Range(0, 999) 為重新排序; 數字夠大即可達到隨機效果 (將"randomSkill"清單隨機排序：洗牌)
        randomSkill = randomSkill.OrderBy(x => Random.Range(0, 999)).ToList();

        // 迴圈執行三次
        for (int i = 0; i < 3; i++)
        {
            if (i > randomSkill.Count - 1)
            {
                goSkillUI[i].SetActive(false);
            }
            else
            {
                // 技能選取區塊.找到名字為《技能名稱》的子物件 並更新他的文字內容 為 隨機技能的名稱
                goSkillUI[i].transform.Find("技能名稱").GetComponent<TextMeshProUGUI>().text = randomSkill[i].skillName;
                goSkillUI[i].transform.Find("技能描述").GetComponent<TextMeshProUGUI>().text = randomSkill[i].skillDescription;
                goSkillUI[i].transform.Find("技能等級").GetComponent<TextMeshProUGUI>().text = "Lv" + randomSkill[i].skillLv;
                goSkillUI[i].transform.Find("技能圖片").GetComponent<Image>().sprite = randomSkill[i].skillPicture;
            }
        }

        if (randomSkill.Count == 0) btnClose.SetActive(true);
    }

    [ContextMenu("產生經驗值需求資料")]
    private void ExpNeeds()
    {
        expNeeds = new float[100];

        for (int i = 0; i < 100; i++)
        {
            expNeeds[i] = (i + 1) * 100;
        }
    }

    // 執行 10 次並取得每次迴圈的 i 值&#xff1a;從 0 ~ 9

    /*
	 for (int i = 0; i < 10; i++)
	{
		// 迴圈要執行的內容
	}

	// 小括號內三個區域的意義
	// int i = 0; 初始值 i 預設為 0
	// i < 10; 當 i 小於 10 會執行迴圈&#xff0c;否則停止迴圈
	// i++ 每次迴圈執行完內容後會對 i 加 1*/

    public void ClickCloseButton()
    {
        goLvUp.SetActive(false);
        Time.timeScale = 1;
    }

    public void ClickSkillButton(int indexSkill)
    {
        AudioClip sound = SoundManager.instance.soundSkillLvUp;
        SoundManager.instance.PlaySound(sound, 0.8f, 1.2f);

        //print($"<color=#6699ff>{indexSkill}</color>");
        randomSkill[indexSkill].skillLv++;
        goLvUp.SetActive(false);
        Time.timeScale = 1;

        if (randomSkill[indexSkill].skillName == "吸取經驗值範圍增加") UpdateAbsorbExpRange();
        if (randomSkill[indexSkill].skillName == "武器斧頭攻擊") UpdateAxAttack();
        if (randomSkill[indexSkill].skillName == "武器生成間隔縮短") UpdateAxInterval();
        if (randomSkill[indexSkill].skillName == "玩家血量增加") UpdatePlayerHp();
        if (randomSkill[indexSkill].skillName == "移動速度提升") UpdateMoveSpeed();
    }

    [Header("衝鋒企鵝：圓形碰撞")]
    public CircleCollider2D playerExpRange;

    private void UpdateAbsorbExpRange()
    {
        int lv = dataSkills[0].skillLv - 1;
        playerExpRange.radius = dataSkills[0].skillValues[lv];
    }

    [Header("武器斧頭生成點")]
    public WeaponSpawn weaponSpawn;

    private void UpdateAxAttack()
    {
        int lv = dataSkills[1].skillLv - 1;
        weaponSpawn.attack = dataSkills[1].skillValues[lv];

    }
    private void UpdateAxInterval()
    {
        int lv = dataSkills[2].skillLv - 1;
        weaponSpawn.interval = dataSkills[2].skillValues[lv];

        weaponSpawn.Restart();
    }

    [Header("玩家資料")]
    public DataBasic dataBasic;

    private void UpdatePlayerHp()
    {
        int lv = dataSkills[0].skillLv - 1;
        dataBasic.hp = dataSkills[0].skillValues[lv];
    }

    [Header("衝鋒企鵝：控制系統")]
    public ControlSystem controlSystem;

    private void UpdateMoveSpeed()
    {
        int lv = dataSkills[4].skillLv - 1;
        controlSystem.moveSpeed = dataSkills[4].skillValues[lv];
    }

}
