using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Adress
    {        
        public string username;
        private string country;
        private string city;
        private string street;
        private string house;
        private string room;


        public Adress()
        {
        }

        public Adress(string username, string country, string city, string street, string house, string room)
        {
            this.username = username;
            this.country = country;
            this.city = city;
            this.street = street;
            this.house = house;
            this.room = room;
        }

        public Adress(string username, string country, string city, string street, string house)
        {
            this.username = username;
            this.country = country;
            this.city = city;
            this.street = street;
            this.house = house;
            this.room = null;
        }

        public Adress(string username, string country, string city, string street)
        {
            this.username = username;
            this.country = country;
            this.city = city;
            this.street = street;
            this.house = null;
            this.room = null;
        }

        public string getInfo()
        {
            if (house == "" && room == "")
            {
                return username + "'s adress is " + country + " " + city + " " + street;
            }
            else if (room == "" && house != "")
            {
                return username + "'s adress is " + country + " " + city + " " + street + " " + house;
            }           
            else
            {
                return username + "'s adress is " + country + " " + city + " " + street + " " + house + " room " + room;
            }

        }    

        public void setValues(string username, string country, string city, string street, string house, string room)
        {
            this.username = username;
            this.country = country;
            this.city = city;
            this.street = street;
            this.house = house;
            this.room = room;
        }
        public void setValues(string username, string country, string city, string street, string house)
        {
            this.username = username;
            this.country = country;
            this.city = city;
            this.street = street;
            this.house = house;
            this.room = null;
        }

        public void setValues(string username, string country, string city, string street)
        {
            this.username = username;
            this.country = country;
            this.city = city;
            this.street = street;
            this.house = null;
            this.room = null;
        }

        public string getValueUsername()
        {
            return username;
        }

        public string getValueCountry()
        {
            return country;
        }

        public string getValueCity()
        {
            return city;
        }

        public string getValueStreet()
        {
            return street;
        }

        public string getValueHouse()
        {
            return house;
        }

        public string getValueRoom()
        {
            return room;
        }

        public void setValueUsername(string uN)
        {
            this.username = uN;             
        }

        public void setValueContry(string uN)
        {
            this.country = uN;
        }

        public void setValueCity(string uN)
        {
            this.city = uN;
        }

        public void setValueStreet(string uN)
        {
            this.street = uN;
        }

        public void setValueHouse(string uN)
        {
            this.house = uN;
        }

        public void setValueRoom(string uN)
        {
            this.room = uN;
        }
    }
}
