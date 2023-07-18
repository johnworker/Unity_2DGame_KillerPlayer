using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
	public GameObject goSkillUI1;
	public GameObject goSkillUI2;
	public GameObject goSkillUI3;

	[Header("技能資料陣列")]
	public DataSkill[] dataSkills;


	private int lv = 1;
	private float exp = 0;

	public float[] expNeeds = { 100, 200, 300 };

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

		if (this.exp > expNeeds[lv -1])
		{
			this.exp -= expNeeds[lv - 1];
			lv++;
			textLv.text = lv.ToString();
			LevelUp();
		}

		textExp.text = this.exp + "/" + expNeeds[lv - 1];
		imgExp.fillAmount = this.exp / expNeeds[lv - 1];
	}

	private void LevelUp()
	{
		goLvUp.SetActive(true);
		Time.timeScale = 0;
	}

	[ContextMenu("產生經驗值需求資料")]
	private void ExpNeeds()
	{
		expNeeds = new float[100];

		for (int i = 0; i < 100; i++)
		{
			expNeeds[i] = (i + 1) * 100 ;
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
}
