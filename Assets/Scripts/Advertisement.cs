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
		if(type == AdvertisementType.Flyer)
		{
			cost = GameConstants.adType1Cost;
			hypeFactor = GameConstants.adType1Hype;
		}
		else if(type == AdvertisementType.InternetAd)
		{
			cost = GameConstants.adType2Cost;
			hypeFactor = GameConstants.adType2Hype;
		}
		else if(type == AdvertisementType.Billboard)
		{
			cost = GameConstants.adType3Cost;
			hypeFactor = GameConstants.adType3Hype;
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

