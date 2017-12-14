﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

	public static GameObject selectedDefender;
	
	public GameObject defenderPrefab;

	private Button [] buttonArray;
	private Text costText;
	

	// Use this for initialization
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button>();
		costText = GetComponentInChildren<Text>();
		if (!costText) {
			Debug.LogWarning (name + " has no cost indicator");
		}
		Defender thisDefender = defenderPrefab.GetComponent<Defender>();
		costText.text = thisDefender.starCost.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnMouseDown () {
		
		foreach (Button thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}
		
		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
		print (selectedDefender);		
	}
}
