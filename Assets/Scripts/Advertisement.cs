using UnityEngine;
using System.Collections;

public class Advertisement : MonoBehaviour
{
	public enum AdvertisementType
	{
		Flyer,
		TelevisionAd,
		Billboard
	}
	
	private AdvertisementType type;
	private int cost;
	private int hypeFactor;
	private float hypeLength;
	public bool hypeEnd;
	
	private Clock clock;
	
	int adImageX = 210;
	int imageSpace = 10;
	int adImageY = 10;
	int adImageW = 60;
	int adImageH = 60;
	
	
	// Use this for initialization
	void Start ()
	{
		clock = GameObject.Find("GUI").GetComponent<Clock>();
		hypeEnd = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		hypeLength -= clock.deltaTime;
		if(hypeLength <= 0){
			hypeEnd = true;
		}
	}
	
	void OnGUI(){
		displayAdImage();
	}
	
	public void setType(AdvertisementType adType){
		type = adType;
		if (type == AdvertisementType.Flyer) {
			cost = GameConstants.adType1Cost;
			hypeFactor = GameConstants.adType1Hype;
			hypeLength = GameConstants.adType1Length;
		} else if (type == AdvertisementType.TelevisionAd) {
			cost = GameConstants.adType2Cost;
			hypeFactor = GameConstants.adType2Hype;
			hypeLength = GameConstants.adType2Length;
		} else if (type == AdvertisementType.Billboard) {
			cost = GameConstants.adType3Cost;
			hypeFactor = GameConstants.adType3Hype;
			hypeLength = GameConstants.adType3Length;
		}
	}
	
	public AdvertisementType getType ()
	{
		return type;
	}

	public int getCost ()
	{
		return cost;
	}

	public int getHype ()
	{
		return hypeFactor;
	}

	public float getHypeLength ()
	{
		return hypeLength;
	}
	
	public void displayAdImage(){
		Texture2D adImage;
		if(type == AdvertisementType.Flyer) {
			adImage = (Texture2D) Resources.Load("Flyers");
			GUI.Label(new Rect(adImageX,adImageY,adImageW,adImageH),adImage);
		} else if(type == AdvertisementType.TelevisionAd){
			adImage = (Texture2D) Resources.Load("TelevisionAd");
			GUI.Label(new Rect(adImageX + imageSpace + adImageW,adImageY,adImageW,adImageH),adImage);
		} else if(type == AdvertisementType.Billboard){
			adImage = (Texture2D) Resources.Load("Billboard");
			GUI.Label(new Rect(adImageX + imageSpace * 2 + adImageW * 2,adImageY,adImageW,adImageH),adImage);
		}
	}
	
}

