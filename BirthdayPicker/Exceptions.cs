using System;

namespace BirthdayPicker.Exceptions
{
    internal class WrongEmail : Exception
    {
        public WrongEmail(string message) : base(message){}
    }
    internal class TooOld : Exception
    {
        public TooOld(string message) : base(message) { }
       
    }
    internal class WrongDate: Exception
    {
        public WrongDate(string message) : base(message)
        { }
        
    }
}
