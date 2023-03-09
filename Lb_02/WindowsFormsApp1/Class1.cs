using System;

public class Adress
{
	private string country;
	private string city;
	private string street;
	private string house;
	private string room;
	

	public Adress()
	{
	}

	public Adress(string country, string city, string street, string house, string room)
	{
		this.country = country;
		this.city = city;
		this.street = street;
		this.house = house;
		this.room = room;
	}

	public Adress(string country, string city, string street, string house)
	{
        this.country = country;
        this.city = city;
        this.street = street;
        this.house = house;
        this.room = null;
    }

    public Adress(string country, string city, string street)
    {
        this.country = country;
        this.city = city;
        this.street = street;
        this.house = null;
        this.room = null;
    }

	public string getInfo()
	{
		if(house == null && room = null)
		{
            return "User adress is " + country + " " + city + " " + street;
        }else if (room == null && house != "")
		{
            return "User adress is " + country + " " + city + " " + street + " " + house;
		}
		else
		{
            return "User adress is " + country + " " + city + " " + street + " " + house + " " + room;
        }
		 
	}
}
