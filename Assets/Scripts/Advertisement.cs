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
	float currentTime;
	
	
	// Use this for initialization
	void Start ()
	{
		clock = GameObject.Find("GUI").GetComponent<Clock>();
		currentTime = clock.time;
		hypeEnd = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		print (clock.time);
		if(clock.time >= hypeLength){
			hypeEnd = true;
		}
	}
	
	public void setType(AdvertisementType adType){
		type = adType;
		if (type == AdvertisementType.Flyer) {
			cost = GameConstants.adType1Cost;
			hypeFactor = GameConstants.adType1Hype;
			hypeLength = GameConstants.adType1Length + currentTime;
		} else if (type == AdvertisementType.TelevisionAd) {
			cost = GameConstants.adType2Cost;
			hypeFactor = GameConstants.adType2Hype;
			hypeLength = GameConstants.adType2Length + currentTime;
		} else if (type == AdvertisementType.Billboard) {
			cost = GameConstants.adType3Cost;
			hypeFactor = GameConstants.adType3Hype;
			hypeLength = GameConstants.adType3Length + currentTime;
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
	
}

