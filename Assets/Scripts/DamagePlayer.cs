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

        AudioClip sound = SoundManager.instance.soundPlayerHurt;
        SoundManager.instance.PlaySound(sound, 0.8f, 1.2f);


        imgHp.fillAmount = hp / hpMax;
    }

    protected override void Dead()
    {
        base.Dead();

        AudioClip sound = SoundManager.instance.soundPlayerDead;
        SoundManager.instance.PlaySound(sound, 0.8f, 1.2f);

        controlSystem.enabled = false;
        weaponSpawn.Stop();
        textFinal.text = "你已經死了...";
        goFinal.SetActive(true);
    }

    public void Win()
    {
        textFinal.text = "恭喜過關";
        goFinal.SetActive(true);
    }
}
