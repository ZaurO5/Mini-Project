using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants;
public class Messages
{
    public static void ErrorHasOccuredMessage() => Console.WriteLine("Error has occured");
    public static void CountIsZeroMessage(string name) => Console.WriteLine($"There is no {name} in base.");
    public static void NotEnoughMessage(string title) => Console.WriteLine($"{title} isn't Enough");
    public static void NotFoundMessage(string title) => Console.WriteLine($"{title} not found");
    public static void InputMessage(string title) => Console.WriteLine($"Please Enter {title}");
    public static void DateMessage() => Console.WriteLine($"Input date (format: dd/MM/yyyy)");
    public static void InvalidInputMessage(string title) => Console.WriteLine($"{title} is invalid");
    public static void AlreadyExistMessage(string title) => Console.WriteLine($"{title} already exists");
    public static void IncorrectInputMessage() => Console.WriteLine($"Inputs is incorrect");
    public static void LoginMessage() => Console.WriteLine("You logged in");
    public static void SuccessMessage(string title) => Console.WriteLine($"{title} successfully");
    public static void NotExistMessage(string title) => Console.WriteLine($"There is not an Existing {title}");
    public static void SearchYesOrNoMessage(string name) => Console.WriteLine($"search {name} (y/n)?");
    public static void BuyYesOrNoMessage(string name) => Console.WriteLine($"buy {name} (y/n)?");

}
