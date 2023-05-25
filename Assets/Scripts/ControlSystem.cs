using UnityEngine;

public class ControlSystem : MonoBehaviour
{
	[Header("移動速度"), Range(0, 10)]
	public float moveSpeed = 3.5f;

	public Rigidbody2D rig;

	[Header("動畫控制器")]
	public Animator ani;
	[Header("跑步參數")]
	public string parRun = "走路開關";

	private void Awake()
	{
		// print("1 + 2");
		// print($"{ 1 + 2 }");
	}

	private void Start()
	{
		// print("<color=blue>開始</color>");
	}

	private void Update()
	{
		// print("<color=#996615>執行</color>");

		Move();
	}

	private void Move()
	{
		// GetAxis 取得軸向、Horizontal 水平軸向
		float h = Input.GetAxis("Horizontal"); 
		float v = Input.GetAxis("Vertical");

		// 物理的加速度，可修改物件身上 Rigidbody2D 的加速度。
		// 方法必須放入 Update 執行
		rig.velocity = new Vector2(h, v) * moveSpeed;
	}
}
