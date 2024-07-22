using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

struct Person
{
    public string Name;
    public string Address;
    public string FatherName;
    public string MotherName;
    public long MobileNo;
    public string Sex;
    public string Email;
    public string CitizenNo;
}

class Program
{
    static void Main()
    {
        Console.BackgroundColor = ConsoleColor.Magenta;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();
        Start();
    }

    static void Start()
    {
        Menu();
    }

    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("\t\t********** WELCOME TO PHONEBOOK *************");
        Console.WriteLine("\n\n\t\t\t MENU\t\t\n\n");
        Console.WriteLine("\t1. Add New \t2. List \t3. Exit \n\t4. Modify \t5. Search\t6. Delete");

        switch (Console.ReadKey(true).KeyChar)
        {
            case '1': AddRecord(); break;
            case '2': ListRecord(); break;
            case '3': Environment.Exit(0); break;
            case '4': ModifyRecord(); break;
            case '5': SearchRecord(); break;
            case '6': DeleteRecord(); break;
            default:
                Console.WriteLine("\nEnter a number between 1 and 6.");
                Console.ReadKey();
                Menu();
                break;
        }
    }

    static void AddRecord()
    {
        Console.Clear();
        Person p = new Person();

        Console.Write("\nEnter name: ");
        p.Name = Console.ReadLine();
        Console.Write("Enter address: ");
        p.Address = Console.ReadLine();
        Console.Write("Enter father's name: ");
        p.FatherName = Console.ReadLine();
        Console.Write("Enter mother's name: ");
        p.MotherName = Console.ReadLine();
        Console.Write("Enter phone number: ");
        p.MobileNo = long.Parse(Console.ReadLine());
        Console.Write("Enter sex: ");
        p.Sex = Console.ReadLine();
        Console.Write("Enter email: ");
        p.Email = Console.ReadLine();
        Console.Write("Enter citizen number: ");
        p.CitizenNo = Console.ReadLine();

        try
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open("project.dat", FileMode.Append)))
            {
                writer.Write(p.Name.PadRight(35));
                writer.Write(p.Address.PadRight(50));
                writer.Write(p.FatherName.PadRight(35));
                writer.Write(p.MotherName.PadRight(30));
                writer.Write(p.MobileNo);
                writer.Write(p.Sex.PadRight(8));
                writer.Write(p.Email.PadRight(100));
                writer.Write(p.CitizenNo.PadRight(20));
            }

            Console.WriteLine("\nRecord saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }

        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
        Menu();
    }

    static void ListRecord()
    {
        Console.Clear();

        try
        {
            using (BinaryReader reader = new BinaryReader(File.Open("project.dat", FileMode.Open)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    Person p = new Person
                    {
                        Name = reader.ReadString().Trim(),
                        Address = reader.ReadString().Trim(),
                        FatherName = reader.ReadString().Trim(),
                        MotherName = reader.ReadString().Trim(),
                        MobileNo = reader.ReadInt64(),
                        Sex = reader.ReadString().Trim(),
                        Email = reader.ReadString().Trim(),
                        CitizenNo = reader.ReadString().Trim()
                    };

                    Console.WriteLine("\n\nYOUR RECORD IS\n\n");
                    Console.WriteLine($"Name: {p.Name}\nAddress: {p.Address}\nFather's name: {p.FatherName}\nMother's name: {p.MotherName}\nMobile number: {p.MobileNo}\nSex: {p.Sex}\nEmail: {p.Email}\nCitizen number: {p.CitizenNo}");
                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("\nNo records found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }

        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
        Menu();
    }

    static void SearchRecord()
    {
        Console.Clear();
        Console.Write("\nEnter the name of the person to search: ");
        string name = Console.ReadLine();
        bool found = false;

        try
        {
            using (BinaryReader reader = new BinaryReader(File.Open("project.dat", FileMode.Open)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    Person p = new Person
                    {
                        Name = reader.ReadString().Trim(),
                        Address = reader.ReadString().Trim(),
                        FatherName = reader.ReadString().Trim(),
                        MotherName = reader.ReadString().Trim(),
                        MobileNo = reader.ReadInt64(),
                        Sex = reader.ReadString().Trim(),
                        Email = reader.ReadString().Trim(),
                        CitizenNo = reader.ReadString().Trim()
                    };

                    if (p.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"\nDetail Information About {name}");
                        Console.WriteLine($"Name: {p.Name}\nAddress: {p.Address}\nFather's name: {p.FatherName}\nMother's name: {p.MotherName}\nMobile number: {p.MobileNo}\nSex: {p.Sex}\nEmail: {p.Email}\nCitizen number: {p.CitizenNo}");
                        found = true;
                        break;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("\nRecord not found.");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("\nNo records found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }

        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
        Menu();
    }

    static void DeleteRecord()
    {
        Console.Clear();
        Console.Write("Enter the name of the contact to delete: ");
        string name = Console.ReadLine();
        List<Person> persons = new List<Person>();
        bool found = false;

        try
        {
            using (BinaryReader reader = new BinaryReader(File.Open("project.dat", FileMode.Open)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    Person p = new Person
                    {
                        Name = reader.ReadString().Trim(),
                        Address = reader.ReadString().Trim(),
                        FatherName = reader.ReadString().Trim(),
                        MotherName = reader.ReadString().Trim(),
                        MobileNo = reader.ReadInt64(),
                        Sex = reader.ReadString().Trim(),
                        Email = reader.ReadString().Trim(),
                        CitizenNo = reader.ReadString().Trim()
                    };

                    if (p.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        found = true;
                    }
                    else
                    {
                        persons.Add(p);
                    }
                }
            }

            if (found)
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open("project.dat", FileMode.Create)))
                {
                    foreach (var p in persons)
                    {
                        writer.Write(p.Name.PadRight(35));
                        writer.Write(p.Address.PadRight(50));
                        writer.Write(p.FatherName.PadRight(35));
                        writer.Write(p.MotherName.PadRight(30));
                        writer.Write(p.MobileNo);
                        writer.Write(p.Sex.PadRight(8));
                        writer.Write(p.Email.PadRight(100));
                        writer.Write(p.CitizenNo.PadRight(20));
                    }
                }
                Console.WriteLine("\nRecord deleted successfully.");
            }
            else
            {
                Console.WriteLine("\nRecord not found.");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("\nNo records found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }

        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
        Menu();
    }

    static void ModifyRecord()
    {
        Console.Clear();
        Console.Write("\nEnter the name of the contact to modify: ");
        string name = Console.ReadLine();
        List<Person> persons = new List<Person>();
        bool found = false;

        try
        {
            using (BinaryReader reader = new BinaryReader(File.Open("project.dat", FileMode.Open)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    Person p = new Person
                    {
                        Name = reader.ReadString().Trim(),
                        Address = reader.ReadString().Trim(),
                        FatherName = reader.ReadString().Trim(),
                        MotherName = reader.ReadString().Trim(),
                        MobileNo = reader.ReadInt64(),
                        Sex = reader.ReadString().Trim(),
                        Email = reader.ReadString().Trim(),
                        CitizenNo = reader.ReadString().Trim()
                    };

                    if (p.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        found = true;
                        Console.Write("\nEnter new name: ");
                        p.Name = Console.ReadLine();
                        Console.Write("Enter new address: ");
                        p.Address = Console.ReadLine();
                        Console.Write("Enter new father's name: ");
                        p.FatherName = Console.ReadLine();
                        Console.Write("Enter new mother's name: ");
                        p.MotherName = Console.ReadLine();
                        Console.Write("Enter new phone number: ");
                        p.MobileNo = long.Parse(Console.ReadLine());
                        Console.Write("Enter new sex: ");
                        p.Sex = Console.ReadLine();
                        Console.Write("Enter new email: ");
                        p.Email = Console.ReadLine();
                        Console.Write("Enter new citizen number: ");
                        p.CitizenNo = Console.ReadLine();
                    }

                    persons.Add(p);
                }
            }

            if (found)
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open("project.dat", FileMode.Create)))
                {
                    foreach (var p in persons)
                    {
                        writer.Write(p.Name.PadRight(35));
                        writer.Write(p.Address.PadRight(50));
                        writer.Write(p.FatherName.PadRight(35));
                        writer.Write(p.MotherName.PadRight(30));
                        writer.Write(p.MobileNo);
                        writer.Write(p.Sex.PadRight(8));
                        writer.Write(p.Email.PadRight(100));
                        writer.Write(p.CitizenNo.PadRight(20));
                    }
                }
                Console.WriteLine("\nRecord modified successfully.");
            }
            else
            {
                Console.WriteLine("\nRecord not found.");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("\nNo records found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }

        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
        Menu();
    }
}