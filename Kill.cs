using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour
{
	// Start is called before the first frame update
	void OnTriggerEnter(Collider other)
	{
		SceneManager.LoadScene("Monkes");
	}
	
	//Update Is called once per frame
	void Update()
	{

	}
}
