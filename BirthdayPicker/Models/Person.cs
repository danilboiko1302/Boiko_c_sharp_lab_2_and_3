using System;
using BirthdayPicker.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace BirthdayPicker.Models
{
    internal class Person
    {
        private string _email;


        public string FirstName { get; }

        public string LastName { get; }

        public string Email
        {
            get => _email;
            private set
            {
                if (new EmailAddressAttribute().IsValid(value))
                {
                    _email = value;
                }
                else
                {
                    throw new WrongEmail("Error! Invalid email!");
                }
            }
        }

        public DateTime Date { get; }

        public string WesternZodiac { get; }

        public string ChineseZodiac { get; }

        public bool IsBirthday { get; }

        public bool IsAdult { get; }

        internal Person(string firstName, string lastName, string email, DateTime date)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            
            Date = date;

            int age = ComputeAge();
            IsAdult = (age >= 18);
            IsBirthday = CheckForBirthday();
            WesternZodiac = ComputeWesternZodiac();
            ChineseZodiac = ComputeChineseZodiac();
        }
        
        public Person(string firstName, string lastName, string email):
            this(firstName,lastName,email,DateTime.Today)
        {
        }

        public Person(string firstName, string lastName, DateTime date) :
            this(firstName, lastName, "testing@testing.tes", date)
        {
        }

        private int ComputeAge()
        {
            DateTime atTheMoment = DateTime.Today;
            int resultAge = atTheMoment.Year - Date.Year;

            if (((atTheMoment.Month == Date.Month) && (Date.Day > atTheMoment.Day)) || Date.Month > atTheMoment.Month)
            {
                resultAge--;
            }

            if (resultAge < 0) 
            {
                throw new WrongDate("Error! Invalid birthday date!");
            }
            if (resultAge > 135)
            {
                throw new TooOld("Error! Too old");
            }
            return resultAge;
        }

        private bool CheckForBirthday()
        {
            if (Date.Day == DateTime.Today.Day && Date.Month == DateTime.Today.Month)
            {
                return true;
            }
            return false;
        }

        private string ComputeWesternZodiac()
        {
            string res = "";
            if ((Date.Month == 1 && Date.Day >= 21) || (Date.Month == 2 && Date.Day <= 20))
                res += "Aquarius";
            if ((Date.Month == 2 && Date.Day >= 21) || (Date.Month == 3 && Date.Day <= 20))
                res += "Pisces";
            if ((Date.Month == 3 && Date.Day >= 21) || (Date.Month == 4 && Date.Day <= 20))
                res += "Aries";
            if ((Date.Month == 4 && Date.Day >= 21) || (Date.Month == 5 && Date.Day <= 20))
                res += "Taurus";
            if ((Date.Month == 5 && Date.Day >= 21) || (Date.Month == 6 && Date.Day <= 21))
                res += "Gemini";
            if ((Date.Month == 6 && Date.Day >= 22) || (Date.Month == 7 && Date.Day <= 22))
                res += "Cancer";
            if ((Date.Month == 7 && Date.Day >= 23) || (Date.Month == 8 && Date.Day <= 23))
                res += "Leo";
            if ((Date.Month == 8 && Date.Day >= 24) || (Date.Month == 9 && Date.Day <= 23))
                res += "Virgo";
            if ((Date.Month == 9 && Date.Day >= 24) || (Date.Month == 10 && Date.Day <= 22))
                res += "Libra";
            if ((Date.Month == 10 && Date.Day >= 23) || (Date.Month == 11 && Date.Day <= 22))
                res += "Scorpio";
            if ((Date.Month == 11 && Date.Day >= 23) || (Date.Month == 12 && Date.Day <= 21))
                res += "Sagittarius";
            if ((Date.Month == 12 && Date.Day >= 22) || (Date.Month == 1 && Date.Day <= 20))
                res += "Capricorn";
            return "Your Western Zodiac Sign is " + res;
        }

        private string ComputeChineseZodiac()
        {
            int yearForAnimal = Date.Year % 12;
            CorrectChineseYear(ref yearForAnimal);
            int yearForElemental = Date.Year % 10;
            CorrectChineseYear(ref yearForElemental);

            return $"Your Chinese Zodiac Sign is {ChooseChineseElemental(yearForElemental)} {ChooseChineseAnimal(yearForAnimal)}";
        }

        /*Due to the fact that chinese new year starts
          according to the moon phases, and it can be [Jan21; Feb21],
          for more simplicity we'll suppose that in the year when user was born,
          China was celebrating New Year at 21 of January*/
        private void CorrectChineseYear(ref int year)
        {
            if ((Date.Month == 1) && Date.Day < 21)
            {
                if (year == 0)
                {
                    year = 11;
                }
                else
                {
                    year--;
                }
            }
        }

        private string ChooseChineseElemental(int year)
        {
            switch (year)
            {
                case 0:
                case 1:
                    return "Metal";
                case 2:
                case 3:
                    return "Water";
                case 4:
                case 5:
                    return "Wood";
                case 6:
                case 7:
                    return "Fire";
                case 8:
                    return "Earth";
                default:
                    return "Earth";
            }
        }

        private string ChooseChineseAnimal(int year)
        {
            switch (year)
            {
                case 1:
                    return "Rooster";
                case 2:
                    return "Dog";
                case 3:
                    return "Pig";
                case 4:
                    return "Rat";
                case 5:
                    return "Ox";
                case 6:
                    return "Tiger";
                case 7:
                    return "Rabbit";
                case 8:
                    return "Dragon";
                case 9:
                    return "Snake";
                case 10:
                    return "Horse";
                case 11:
                    return "Goat";
                default:
                    return "Monkey";
            }
        }
    }
}