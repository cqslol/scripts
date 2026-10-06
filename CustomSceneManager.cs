using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
	[Header("Scene Name")]
	public string SceneName = "SceneName";
	[Space]
	[Header("HandTag")]
	public string HandTag = "HandTag";

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(HandTag))
		{
			SceneManager.LoadScene(SceneName);
		}
	}
}