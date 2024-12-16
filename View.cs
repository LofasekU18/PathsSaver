public class View
{
    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }
    public void WaitForUser()
    {
        Console.WriteLine("Press keyboard to continue");
        Console.ReadLine();
    }
}