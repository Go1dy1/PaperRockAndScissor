using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ChestDemo : MonoBehaviour {

    //This script goes on the ChestComplete prefab;

    [FormerlySerializedAs("chestAnim")] public Animator _chestAnim; //Animator for the chest;

	// Use this for initialization
	void Awake ()
    {
        //get the Animator component from the chest;
        _chestAnim = GetComponent<Animator>();
        //start opening and closing the chest for demo purposes;
        StartCoroutine(OpenCloseChest());
	}


    IEnumerator OpenCloseChest()
    {
        //play open animation;
        _chestAnim.SetTrigger("open");
        //wait 2 seconds;
        yield return new WaitForSeconds(2);
        //play close animation;
        _chestAnim.SetTrigger("close");
        //wait 2 seconds;
        yield return new WaitForSeconds(2);
        //Do it again;
        StartCoroutine(OpenCloseChest());

    }
}
