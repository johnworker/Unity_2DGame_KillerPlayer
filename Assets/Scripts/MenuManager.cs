using UnityEngine;
using UnityEngine.SceneManagement;	// 讀取場景需使用的命名空間

public class MenuManager : MonoBehaviour
{
	/// <summary>
	/// 設定開始方法
	/// </summary>
	public void StartGame() 
	{
		// 場景管理(資料).LoadScene 讀取場景API ("場景名稱");
		SceneManager.LoadScene("遊戲場景");
	}

	/// <summary>
	/// 設定結束方法
	/// </summary>
	public void QuitGame() 
	{
		// 應用(資料).Quit();離開內建API
		Application.Quit();
	}
}
