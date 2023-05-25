using UnityEngine;

public class ControlSystem : MonoBehaviour
{
	[Header("���ʳt��"), Range(0, 10)]
	public float moveSpeed = 3.5f;

	public Rigidbody2D rig;

	[Header("�ʵe���")]
	public Animator ani;
	[Header("�]�B�Ѽ�")]
	public string parRun = "�����}��";

	private void Awake()
	{
		// print("1 + 2");
		// print($"{ 1 + 2 }");
	}

	private void Start()
	{
		// print("<color=blue>�}�l</color>");
	}

	private void Update()
	{
		// print("<color=#996615>����</color>");

		Move();
	}

	private void Move()
	{
		// GetAxis ���o�b�V�BHorizontal �����b�V
		float h = Input.GetAxis("Horizontal"); 
		float v = Input.GetAxis("Vertical");

		// ���z���[�t�סA�i�ק磌�󨭤W Rigidbody2D ���[�t�סC
		// ��k������J Update ����
		rig.velocity = new Vector2(h, v) * moveSpeed;
	}
}
