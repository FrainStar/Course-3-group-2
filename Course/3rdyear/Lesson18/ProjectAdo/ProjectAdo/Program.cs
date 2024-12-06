namespace ProjectAdo;

class Program
{
    static void Main(string[] args)
    {
        ContactManager _contactManager = new ContactManager("Data Source=database.db");
        
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Create BD");
            Console.WriteLine("2. Add phone number");
            Console.WriteLine("3. Delete phone number");
            Console.WriteLine("4. Search phone number by name");
            Console.WriteLine("5. Exit");
            
            Console.Write("Enter a number: ");
            int.TryParse(Console.ReadLine(), out int number);

            switch (number)
            {
                case 1:
                    _contactManager.CreateTable();
                    break;
                case 2:
                    Console.Write("Enter Name: ");
                    string? name = Console.ReadLine();
                    
                    Console.Write("Enter phone number: ");
                    string? phone = Console.ReadLine();
                    if (name == null || phone == null)
                    {
                        Console.WriteLine("Please enter a valid phone number");
                        break;
                    }
                    _contactManager.AddContact(name, phone);
                    break;
                case 3:
                    
                    name = Console.ReadLine();
                    if (name == null)
                    {
                        Console.WriteLine("Please enter a valid phone number");
                        break;
                    }
                    
                    _contactManager.DeleteContact(name);
                    break;
                case 4:
                    name = Console.ReadLine();
                    if (name == null)
                    {
                        Console.WriteLine("Please enter a valid phone number");
                        break;
                    }
                    
                    _contactManager.SearchContacts(name);
                    break;
                case 5:
                    exit = true;
                    break;
                    
            }
            
        }
    }
}