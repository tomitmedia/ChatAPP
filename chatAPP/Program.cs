using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace chatApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;


            Console.WriteLine("\nWelcome to Tomitmedia.com!");
            Console.WriteLine("**************************************************************************");
            List<UserAccount> usersAccount = new List<UserAccount>();
            List<List<string>> registeredMember = new List<List<string>>();
            bool registration = false;
            int Members = 0;
            int CurrentUser = 0;

        Menu:
            try
            {
                bool Menu = true;
                while (Menu == true)
                {
                    Console.WriteLine("**************************************************************************");
                    Console.WriteLine("\nPress 1 to Create an account");
                    Console.WriteLine("Press 2 to Login to your account");
                    Console.WriteLine("Press 3 to Exit");
                    int mainMenuInput = Convert.ToInt32(Console.ReadLine());

                    switch (mainMenuInput)
                    {
                        case 1:
                            
                            string User = $"User{ CurrentUser + 1}";
                            Console.WriteLine($"\n{User}");
                            Console.WriteLine("**************************************************************************");

                            Console.Write("\nEnter a Email Address: ");
                            string email = Console.ReadLine();

                            string userName = email.GetUntilOrEmpty().ToLower();
                            var count = email.Count(s => s == '@');
                            var count2 = email.Count(s => s == '.');
                            
                            var exist = usersAccount.Where(i => i.Email == email).FirstOrDefault();

                            if (exist != null && email == exist.Email)
                            {
                                Console.WriteLine("\n--------------------------------------------------------------------------");
                                Console.WriteLine("\nEmail has been taken! try another");
                                Console.WriteLine("\n--------------------------------------------------------------------------");
                                goto case 1;
                            }

                            else if (string.IsNullOrEmpty(email))
                            {
                                Console.WriteLine("\nEmail Address is required!");
                                Console.WriteLine("**************************************************************************");
                                break;
                            }

                            else if (count != 1 || count2 != 1)
                            {
                                Console.WriteLine("\nIncorrect Email Address format!!!");
                                Console.WriteLine("**************************************************************************");
                                break;
                            }

                            else if ( email.Length <= 2)
                            {
                                Console.WriteLine("\nEmail Address too short!!!");
                                Console.WriteLine("**************************************************************************");
                                break;
                            }

                            else if (email.Length >= 25)
                            {
                                Console.WriteLine("\nEmail Address too long!!!\n Maximum of 25 characters/letters");
                                Console.WriteLine("**************************************************************************");
                                break;
                            }
                         
                            else
                            {

                            Pin:

                                Console.Write("\nEnter your Four(4) digits Pin: ");
                                Console.WriteLine("\ne.g '1234'");
                                int userPin = Convert.ToInt32(Console.ReadLine());

                                if (userPin.ToString().Length < 4)
                                {
                                    Console.WriteLine("\nPin too short!!!");
                                    Console.WriteLine("**************************************************************************");
                                    goto Pin;
                                }

                                else if (userPin.ToString().Length > 4)
                                {
                                    Console.WriteLine("\nPin too long!!!");
                                    Console.WriteLine("**************************************************************************");
                                    goto Pin;
                                }

                                Console.Write("\nConfirm your Four(4) digits Pin: ");
                                int confirmPin = Convert.ToInt32(Console.ReadLine());


                                if (userPin != confirmPin)
                                {
                                    Console.WriteLine("\nPin does not match!!!");
                                    Console.WriteLine("**************************************************************************");
                                    goto Pin;
                                }

                                string Msg = " ";

                                usersAccount.Add(new UserAccount(userName.ToLower(), email, confirmPin, Msg));
                                userName = textInfo.ToTitleCase(userName);
                                registeredMember.Add(new List<string> { userName });
                                registration = true;
                                Members += 1;
                                CurrentUser += 1;

                                Console.WriteLine("**************************************************************************");
                                Console.WriteLine("\nRegistration Successful!");
                                Console.WriteLine("\n" + email.ToLower() + "\n Your Username is: " + userName.ToUpper() + "\n");
                                Console.WriteLine("**************************************************************************");

                            }
                            break;

                        case 2:
                            //login();
                            Console.WriteLine("\nYOU");
                            Console.WriteLine("**************************************************************************");
                            Console.Write("\nEnter Username to Login: ");
                            string Usernamee = Console.ReadLine().ToLower();

                            Console.Write("\nEnter your Four(4) digits Pin: ");
                            int pin = Convert.ToInt32(Console.ReadLine());

                            var users = usersAccount.Where(i => i.Username == Usernamee).FirstOrDefault();


                            if (users != null && Usernamee == users.Username && pin != users.Pin)
                            {
                                Console.WriteLine("\nIncorrect Pin!!!");
                                Console.WriteLine("**************************************************************************");
                                goto case 2;
                            }

                            else if(users != null && Usernamee == users.Username && pin == users.Pin)
                            {
                                Console.WriteLine($"\nHello! {users.Username.ToUpper()}");
                                Console.WriteLine("Welcome back ;)");
                                Console.WriteLine(DateTime.Now);
                            }

                            else 
                            {
                                Console.WriteLine("\nOops!!! Account does not exist");
                                Console.WriteLine("**************************************************************************");
                                //goto Menu;
                            }

                            ChatMate:
                            if (registration is true)
                            {
                                Console.WriteLine("\n**************************************************************************");
                                Console.WriteLine($"{CurrentUser} Registered Member(s)");
                                Console.WriteLine("**************************************************************************");
                                Usernamee = textInfo.ToTitleCase(Usernamee);

                                foreach (List<string> subList in registeredMember)
                                {

                                    foreach (string item in subList)
                                    {
                                        if (item != Usernamee)
                                        {
                                            Console.WriteLine(item);
                                            break;
                                        }
                                        Console.WriteLine("You");
                                        break;
                                    }
                                }
                            }

                            else if (registration is false)
                            {
                                Console.WriteLine("\n**************************************************************************");
                                Console.WriteLine("No Registered Member(s) yet!");
                                //break;
                                goto Menu;
                            }

                        user2:
                            if (Members >= 2)
                            {
                                Console.WriteLine("\nUser2");
                                Console.WriteLine("\nNOTE: User is your chatmate!");
                                Console.WriteLine("\n**************************************************************************");

                                Console.Write("\nEnter Username to Login: ");
                                string Username2 = Console.ReadLine().ToLower();

                                Console.Write("\nEnter your Four(4) digits Pin: ");
                                int pin2 = Convert.ToInt32(Console.ReadLine());

                                var users2 = usersAccount.Where(i => i.Username == Username2).FirstOrDefault();


                                if (users2 != null && Username2 == users2.Username && pin2 != users2.Pin)
                                {
                                    Console.WriteLine("\nIncorrect Pin!!!");
                                    Console.WriteLine("**************************************************************************");
                                    goto case 2;
                                }

                                else if (users.Username == Username2 || users2.Username == Usernamee)
                                {
                                    Console.WriteLine($"\nOops! You can't chat with yourself {Username2}!");
                                    goto user2;
                                }

                                else if (users2 != null && Username2 == users2.Username && pin2 == users2.Pin)
                                {
                                    Console.WriteLine($"\nHello! {users2.Username.ToUpper()}");
                                    Console.WriteLine("Welcome back ;)");
                                    Console.WriteLine(DateTime.Now);
                                }
                                else
                                {
                                    Console.WriteLine("\nOops!!! Account does not exist");
                                    Console.WriteLine("**************************************************************************");
                                    goto Menu;
                                }
                            
                        

                            Services:
                                try
                                {
                                    bool serviceInProgress = true;
                                    while (serviceInProgress == true)
                                    {
                                        Console.WriteLine($"\nDear {users.Username.ToUpper()}! You can now chat with {users2.Username.ToUpper()}");
                                        Console.WriteLine("**************************************************************************");
                                        Console.WriteLine("Press 1 to Chat");
                                        Console.WriteLine("Press 2 to Change ChatMate");
                                        Console.WriteLine("Press 3 to Logout");
                                        int serviceInput = Convert.ToInt32(Console.ReadLine());

                                        switch (serviceInput)
                                        {
                                            case 1:
                                                //Chat()
                                                Console.WriteLine("\n**************************************************************************");
                                                Console.WriteLine("Type your message:");
                                            chat:

                                                Console.WriteLine("\n**************************************************************************");
                                                string Msg = Console.ReadLine();
                                                string close = "end chat now";
                                                if (Msg == close.ToUpper())
                                                {
                                                    users.Username = Usernamee.ToLower();
                                                    users2.Username = Username2.ToLower();
                                                    break;
                                                }
                                                else if (string.IsNullOrEmpty(Msg) is false)
                                                {
                                                    users.Username = "You";
                                                    users.Chat(Msg);
                                                    users.Username = textInfo.ToTitleCase(Usernamee);

                                                chat2:

                                                    Console.WriteLine("\n--------------------------------------------------------------------------");
                                                    string Msg2 = Console.ReadLine();
                                                    if (Msg2 == close.ToUpper())
                                                    {
                                                        users.Username = Usernamee.ToLower();
                                                        users2.Username = Username2.ToLower();
                                                        break;
                                                    }

                                                    else if (string.IsNullOrEmpty(Msg2))
                                                    {
                                                        Console.WriteLine("\n--------------------------------------------------------------------------");
                                                        Console.WriteLine($"\n{users2.Username}! Type something Please \nOR type 'END CHAT NOW' to close chat...");

                                                        goto chat2;
                                                    }

                                                    users2.Username = textInfo.ToTitleCase(Username2);
                                                    users2.Chat(Msg2);
                                                    users2.Username = textInfo.ToTitleCase(Username2);
                                                    goto chat;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\n**************************************************************************");
                                                    Console.WriteLine($"\n{users.Username}! You have to type something\nOR type 'END CHAT NOW' to close chat...");
                                                    goto chat;
                                                }

                                            case 2:
                                                goto ChatMate;

                                            case 3:
                                                //Logout()
                                                Console.WriteLine("\n**************************************************************************");
                                                Console.Write("\nAre you sure you want to logout?  Y/N: ");
                                                string choice = Console.ReadLine().ToUpper();
                                                if (choice == "Y")
                                                {
                                                    goto Menu;
                                                }
                                                else if (choice == "N")
                                                {
                                                    continue;
                                                }
                                                Console.WriteLine("\nResponse can only be 'Y/N' ");
                                                Console.WriteLine("**************************************************************************");
                                                goto case 2;

                                            default:

                                                Console.WriteLine("\nOops!!! Entry can only be between '1 & 2'");
                                                break;
                                        }
                                    }
                                }
                                catch (Exception )
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("\nInvalid entry Please try again!!!");
                                    goto Services;
                                }
                            }
                            else if(Members <= 2)
                            {
                                goto Menu;
                            }
                            goto Menu;

                        case 3:
                            //Exit()
                            Console.WriteLine("\nThank you for choosing Tomitmedia!");
                            Menu = false;
                            break;

                        default:
                            Console.WriteLine("\nOops!!! Entry can only be between '1 to 3'");
                            break;
                    }
                }
            }

            catch (Exception )
            {
                Console.WriteLine();
                Console.WriteLine("\nInvalid entry Please try again!!!");
                goto Menu;
            }
        }
    }


    static class GenerateUsername
    {
        public static string GetUntilOrEmpty(this string text, string stopAt = "@")
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    return text.Substring(0, charLocation);
                }
            }

            return text;
        }
    }
}