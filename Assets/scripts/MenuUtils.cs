﻿using UnityEngine;
using System.Collections;

public class MenuUtils : MonoBehaviour {
	//itemRect - used to return a positioned rectangle (for a menu button) based on menu item number
	//use itemRect(itemNumber) for default starting position
	//use itemRect(int itemNumber, float startingPlacement, float startingOffset) for custom
	public static Rect itemRect(int itemNumber){
		return itemRect(itemNumber, -1, -1);
	}

	public static Rect itemRect(int itemNumber, float startingPlacement, float startingOffset){
		return new Rect(Screen.width * 0.25f, top(
			itemNumber
			, 	startingPlacement==-1 ? 0.2f : startingPlacement
			,	startingOffset==-1 ? 0.125f : startingOffset 
			), Screen.width * 0.5f, Screen.height * 0.1f);
	}

	public static float top(int itemNumber, float itemPlacementY, float itemOffsetY){
		return Screen.height * (itemPlacementY + itemOffsetY * itemNumber);
	}

	public static GUIStyle menuTitleStyle() {
		GUIStyle style = new GUIStyle();
		style.fontSize = 20;
		style.normal.textColor = Color.white;
		style.alignment = TextAnchor.MiddleCenter;
		return style;
	}

	public static GUIStyle menuParagraphStyle() {
		GUIStyle style = new GUIStyle();
		style.fontSize = 12;
		style.normal.textColor = Color.white;
		style.wordWrap = true;
		return style;
	}

	public static GUIStyle menuItemLabelStyle() {
		GUIStyle style = new GUIStyle();
		style.fontSize = 12;
		style.normal.textColor = Color.white;
		style.wordWrap = true;
		style.alignment = TextAnchor.MiddleCenter;
		return style;
	}

	public static void drawMenuLabel(string title, Texture logo) {
		GUI.DrawTexture(new Rect(20.0f,30.0f,75.0f,75.0f), logo);
		GUI.Label(new Rect(180.0f, 55.0f, 50.0f, 20.0f), title, menuTitleStyle());
	}

	public static void drawBackToMainMenuButton() {
		float width = Screen.width * 0.15f;
		float height = Screen.height * 0.07f;
		float paddingX = 30.0f;
		float paddingY = 10.0f;
		
		if(GUI.Button(new Rect(Screen.width - (width + paddingX), Screen.height - (height + paddingY), width, height), "Back")) {
			Application.LoadLevel(0);
		}
	}
}
