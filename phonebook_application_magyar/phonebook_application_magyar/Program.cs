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
        Console.WriteLine("\t\t********** ÜDVÖZÖLJÜK A TELEFONKÖNYVBEN *************");
        Console.WriteLine("\n\n\t\t\t MENÜ\t\t\n\n");
        Console.WriteLine("\t1. Új hozzáadása \t2. Listázás \t3. Kilépés \n\t4. Módosítás \t5. Keresés \t6. Törlés");

        switch (Console.ReadKey(true).KeyChar)
        {
            case '1': AddRecord(); break;
            case '2': ListRecord(); break;
            case '3': Environment.Exit(0); break;
            case '4': ModifyRecord(); break;
            case '5': SearchRecord(); break;
            case '6': DeleteRecord(); break;
            default:
                Console.WriteLine("\nCsak 1 és 6 közötti számot adjon meg.");
                Console.ReadKey();
                Menu();
                break;
        }
    }

    static void AddRecord()
    {
        Console.Clear();
        Person p = new Person();

        Console.Write("\nAdja meg a nevet: ");
        p.Name = Console.ReadLine();
        Console.Write("Adja meg a címet: ");
        p.Address = Console.ReadLine();
        Console.Write("Adja meg az apa nevét: ");
        p.FatherName = Console.ReadLine();
        Console.Write("Adja meg az anya nevét: ");
        p.MotherName = Console.ReadLine();
        Console.Write("Adja meg a telefonszámot: ");
        p.MobileNo = long.Parse(Console.ReadLine());
        Console.Write("Adja meg a nemet: ");
        p.Sex = Console.ReadLine();
        Console.Write("Adja meg az e-mail címet: ");
        p.Email = Console.ReadLine();
        Console.Write("Adja meg az személyigazolvány számot: ");
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

            Console.WriteLine("\nA rekord sikeresen elmentve!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nHiba: {ex.Message}");
        }

        Console.WriteLine("\nNyomjon meg egy gombot a visszatéréshez a menübe.");
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

                    Console.WriteLine("\n\nAZ ÖN REKORDJA\n\n");
                    Console.WriteLine($"Név: {p.Name}\nCím: {p.Address}\nApa neve: {p.FatherName}\nAnya neve: {p.MotherName}\nTelefonszám: {p.MobileNo}\nNem: {p.Sex}\nEmail: {p.Email}\nSzemélyigazolvány szám: {p.CitizenNo}");
                    Console.WriteLine("\nNyomjon meg egy gombot a folytatáshoz.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("\nNincsenek rekordok.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nHiba: {ex.Message}");
        }

        Console.WriteLine("\nNyomjon meg egy gombot a visszatéréshez a menübe.");
        Console.ReadKey();
        Menu();
    }

    static void SearchRecord()
    {
        Console.Clear();
        Console.Write("\nAdja meg a keresni kívánt személy nevét: ");
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
                        Console.WriteLine($"\nRészletes információ {name} név alatt");
                        Console.WriteLine($"Név: {p.Name}\nCím: {p.Address}\nApa neve: {p.FatherName}\nAnya neve: {p.MotherName}\nTelefonszám: {p.MobileNo}\nNem: {p.Sex}\nEmail: {p.Email}\nSzemélyigazolvány szám: {p.CitizenNo}");
                        found = true;
                        break;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("\nRekord nem található.");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("\nNincsenek rekordok.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nHiba: {ex.Message}");
        }

        Console.WriteLine("\nNyomjon meg egy gombot a visszatéréshez a menübe.");
        Console.ReadKey();
        Menu();
    }

    static void DeleteRecord()
    {
        Console.Clear();
        Console.Write("Adja meg a törölni kívánt kontakt nevét: ");
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
                Console.WriteLine("\nRekord sikeresen törölve.");
            }
            else
            {
                Console.WriteLine("\nRekord nem található.");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("\nNincsenek rekordok.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nHiba: {ex.Message}");
        }

        Console.WriteLine("\nNyomjon meg egy gombot a visszatéréshez a menübe.");
        Console.ReadKey();
        Menu();
    }

    static void ModifyRecord()
    {
        Console.Clear();
        Console.Write("Adja meg a módosítani kívánt kontakt nevét: ");
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
                        Console.Write("\nAdjon meg új nevet: ");
                        p.Name = Console.ReadLine();
                        Console.Write("Adjon meg új címet: ");
                        p.Address = Console.ReadLine();
                        Console.Write("Adjon meg új apa nevet: ");
                        p.FatherName = Console.ReadLine();
                        Console.Write("Adjon meg új anya nevet: ");
                        p.MotherName = Console.ReadLine();
                        Console.Write("Adjon meg új telefonszámot: ");
                        p.MobileNo = long.Parse(Console.ReadLine());
                        Console.Write("Adjon meg új nemet: ");
                        p.Sex = Console.ReadLine();
                        Console.Write("Adjon meg új e-mail címet: ");
                        p.Email = Console.ReadLine();
                        Console.Write("Adjon meg új személyigazolvány számot: ");
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
                Console.WriteLine("\nRekord sikeresen módosítva.");
            }
            else
            {
                Console.WriteLine("\nRekord nem található.");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("\nNincsenek rekordok.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nHiba: {ex.Message}");
        }

        Console.WriteLine("\nNyomjon meg egy gombot a visszatéréshez a menübe.");
        Console.ReadKey();
        Menu();
    }
}