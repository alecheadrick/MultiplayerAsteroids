using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	#region Variables
	public static bool firstPerson = false;
	public Text cameraText;
	#endregion

	#region Methods
	public void ToggleCamera()
	{
		firstPerson = !firstPerson;
		if (firstPerson)
		{
			cameraText.text = "1st Person";
		}
		else
		{
			cameraText.text = "3rd Person";
		}
	}

	public void LoadLevel()
	{
		SceneManager.LoadScene("Main");
	}

	#endregion
}
