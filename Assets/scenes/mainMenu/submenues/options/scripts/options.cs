using UnityEngine;
using System.Collections;

public class options : MonoBehaviour {
	public Texture backgroundTexture;
	public Texture logo;
	float musicVolume, soundFXVolume;

	void Start() {
		musicVolume = GlobalFlags.getMusicVolume();
		soundFXVolume = GlobalFlags.getSoundFXVolume();
	}
	
	void OnGUI(){
		//display background texture
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), backgroundTexture);
		MenuUtils.drawMenuLabel("Options", logo);
		
		MenuUtils.drawBackToMainMenuButton();

		GUI.Label(MenuUtils.itemRect(1), "Music", MenuUtils.menuItemLabelStyle());

		musicVolume = GUI.HorizontalSlider(MenuUtils.itemRect(2), musicVolume, 0.0f, 1.0f);
		GlobalFlags.setMusicVolume(musicVolume);

		GUI.Label(MenuUtils.itemRect(3), "Sound FX", MenuUtils.menuItemLabelStyle());

		soundFXVolume = GUI.HorizontalSlider(MenuUtils.itemRect(4), soundFXVolume, 0.0f, 1.0f);
		GlobalFlags.setSoundFXVolume(soundFXVolume);
	}	
}
