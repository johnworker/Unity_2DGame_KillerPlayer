using UnityEngine;
using UnityEngine.SceneManagement;	// Ū�������ݨϥΪ��R�W�Ŷ�

public class MenuManager : MonoBehaviour
{
	/// <summary>
	/// �]�w�}�l��k
	/// </summary>
	public void StartGame() 
	{
		// �����޲z(���).LoadScene Ū������API ("�����W��");
		SceneManager.LoadScene("�C������");
	}

	/// <summary>
	/// �]�w������k
	/// </summary>
	public void QuitGame() 
	{
		// ����(���).Quit();���}����API
		Application.Quit();
	}
}
