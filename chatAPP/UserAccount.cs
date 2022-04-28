using System;
using System.Linq;
using System.Collections.Generic;


namespace chatApp
{
    public class RegisteredMember
    {
        public string Name;

        public RegisteredMember(string name)
        {
            Name = name;
        }
    }

    public class UserAccount
    {
        public string Username;
        public string Email;
        public string Message;
        public int Pin;

        public UserAccount(string userName, string email, int pin, string msg)
        {
            Username = userName;
            Email = email;
            Pin = pin;
            Message = msg;

        }

        public void Chat(string msg)
        {
            Message = msg;
            Console.WriteLine("Sent by:" + Username);
            Console.WriteLine("Date Sent:" + DateTime.Now);
            Console.WriteLine("**************************************************************************");
        }
    }
}
    