using System;

public enum AdvertisementType
{
	Flyer,
	TelevisionAd,
	Billboard
}
	
//Class for Advertisements to increase hype of shop
public class Advertisement
{
	private AdvertisementType type;
	private int cost;
	private int hypeFactor;
	private int hypeLength;
		

	
	//Constructor for Advertisement, depending on type sets values for cost and hype
	//To be balanced later.
	public Advertisement (AdvertisementType adType)
	{
		type = adType;
		if(type == AdvertisementType.Flyer)
		{
			cost = GameConstants.adType1Cost;
			hypeFactor = GameConstants.adType1Hype;
			hypeLength = GameConstants.adType1Length;
		}
		else if(type == AdvertisementType.TelevisionAd)
		{
			cost = GameConstants.adType2Cost;
			hypeFactor = GameConstants.adType2Hype;
			hypeLength = GameConstants.adType2Length;
		}
		else if(type == AdvertisementType.Billboard)
		{
			cost = GameConstants.adType3Cost;
			hypeFactor = GameConstants.adType3Hype;
			hypeLength = GameConstants.adType3Length;
		}
		
		// this might be better form.... 
		/*
		switch (adType)
		{
		case AdvertisementType.Flyer:
			cost = GameConstants.adType1Cost;
			hypeFactor = GameConstants.adType1Hype;
			break;
		case AdvertisementType.TelevisionAd:
			cost = GameConstants.adType2Cost;
			hypeFactor = GameConstants.adType2Hype;
			break;
		case AdvertisementType.Billboard:
			cost = GameConstants.adType3Cost;
			hypeFactor = GameConstants.adType3Hype;
		}*/
	}
	
	public AdvertisementType getType () { return type; }
	public int getCost () { return cost; }
	public int getHype () { return hypeFactor; }
	/*	
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
<<<<<<< HEAD
	}*/
=======
	}
	
	public int getHypeLength(){
		return hypeLength;
	}
	
	public void decrementHypeLength(){
		hypeLength--;
	}
>>>>>>> 4254860ab2c4ba565c2cbcd4c6c2e47a093379a7
}

