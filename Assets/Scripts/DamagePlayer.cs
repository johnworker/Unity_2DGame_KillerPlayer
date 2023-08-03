using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : DamageBasic
{
    public Image imgHp;

    [Header("控制系統")]
    public ControlSystem controlSystem;
    [Header("武器生成點")]
    public WeaponSpawn weaponSpawn;
    [Header("結束畫面")]
    public GameObject goFinal;
    [Header("結束標題")]
    public TextMeshProUGUI textFinal;


    /*
    private void Start()
    {
        Damage(50);
    }*/

    public override void Damage(float damage)
    {
        // 繼承 DataBasic 的資料定義和方法運算
        base.Damage(damage);
        
        imgHp.fillAmount = hp / hpMax;
    }

    protected override void Dead()
    {
        base.Dead();
        controlSystem.enabled = false;
        weaponSpawn.Stop();
        textFinal.text = "你已經死了...";
        goFinal.SetActive(true);
    }
}
