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
		// �t�ΧP�_ -1 �� 1 �������ܤư�����
		float h = Input.GetAxis("Horizontal"); 
		float v = Input.GetAxis("Vertical");

		// ���z���[�t�סA�i�ק磌�󨭤W Rigidbody2D ���[�t�סC
		// ��k������J Update ����
		rig.velocity = new Vector2(h, v) * moveSpeed;

		// �]�w h ������ 0 �n����
		ani.SetBool(parRun, h != 0 || v !=0);

		// print(Input.GetKeyDown(KeyCode.A));

		#region ���V����
		// 
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			// print("���a���UA");
			transform.eulerAngles = new Vector3(0, 180, 0);
			// transform.localScale = new Vector3(-1, 1, 1);
		}

		if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			// print("���a���UD");
			transform.eulerAngles = new Vector3(0, 0, 0);
			// transform.localScale = new Vector3(1, 1, 1);
		}
		#endregion
	}
}
