using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAfterX : MonoBehaviour
{
	public float delay = 17f;
    void Start()
    {
        StartCoroutine("Hide");
    }

    IEnumerator Hide (){
		while(true)
		{

			yield return  new WaitForSeconds(delay);

			gameObject.SetActive(false);
		}
	}
}
