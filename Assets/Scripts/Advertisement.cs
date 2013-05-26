using System;

public enum AdvertisementType
{
	Flyer,
	InternetAd,
	Billboard
}
	
//Class for Advertisements to increase hype of shop
public class Advertisement
{
	private AdvertisementType type;
	private int cost;
	private int hypeFactor;
		
	//Constructor for Advertisement, depending on type sets values for cost and hype
	//To be balanced later.
	public Advertisement (AdvertisementType adType)
	{
		type = adType;
		if(type == AdvertisementType.Flyer){
			cost = 30;
			hypeFactor = 5;
		} else if(type == AdvertisementType.InternetAd){
			cost = 60;
			hypeFactor = 15;
		} else if(type == AdvertisementType.Billboard){
			cost = 100;
			hypeFactor = 40;
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
}

