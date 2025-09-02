using System;
using System.Threading;
using System.IO;

namespace Skola
{
    class Program
    {
        static void Funkce_programu(string Text)
        {
            Console.WriteLine("Zadejte hledané slovo:");                 /* funkce najít */
            string Najit = Console.ReadLine();
            bool klic_slovo = Text.Contains(Najit);

            while (klic_slovo == false)
            {
                Console.WriteLine("Zadané slovo text neobsahuje. (Program rozlišuje velká a malá písmena !!!)"); /* Ošetření vstupu, zjištění zda slovo existuje v textu */
                Najit = Console.ReadLine();
                klic_slovo = Text.Contains(Najit);
            }
            if (klic_slovo == true)
            {
                string[] zadany_text = Text.Split(' ');         /* Rozdělení textu na slova a uložení do pole */

                for (int i = 0; i < zadany_text.Length; i++)
                {
                    int Porovnani_slov = String.Compare(zadany_text[i], Najit); /*Cyklus porovná každé slovo a zjistí, zda se shoduje s hledaným slovem*/
                    string slovicko = zadany_text[i];

                    bool Slovo_carka = slovicko.Contains(",");
                    bool Tecka = slovicko.Contains(".");
                    bool Vykricnik = slovicko.Contains("!"); /* Zjištění zda text obsahuje tyto speciální znaky (je to kontrola speciálních znaků na konci slov) */
                    bool Otaznik = slovicko.Contains("?");

                    if (Tecka == true)
                    {
                        string Najit_tecka = Najit + ".";
                        Porovnani_slov = String.Compare(zadany_text[i], Najit_tecka);
                    }

                    if (Vykricnik == true)
                    {
                        string Najit_vykricnik = Najit + "!";
                        Porovnani_slov = String.Compare(zadany_text[i], Najit_vykricnik);   /* Algoritmus pro vyhledávání v textu. Text se rozdělí na slova, která se uloží do pole, v poli se nalezne vyhledávané slovo, následně se vypíše obsah celého pole s podtrženým hledaným slovem/slovy.*/
                    }

                    if (Otaznik == true)
                    {
                        string Najit_otaznik = Najit + "?";
                        Porovnani_slov = String.Compare(zadany_text[i], Najit_otaznik); /*Díky těmto podmínkám je slovo například: Ahoj a Ahoj, počítáno jako jedno a to samé */
                    }

                    if (Slovo_carka == true)
                    {
                        string Najit_carka = Najit + ",";
                        Porovnani_slov = String.Compare(zadany_text[i], Najit_carka);
                    }

                    if (Porovnani_slov == 0)
                    {
                        const string UNDERLINE = "\x1B[4m";
                        const string RESET = "\x1B[0m";
                        zadany_text[i] = UNDERLINE + zadany_text[i] + RESET; /* Algoritmus podtrhne hledané slovo a vypíše do konzole */
                    }
                }
                Console.Clear();
                Console.WriteLine("------------------------------------------");
                for (int a = 0; a < zadany_text.Length; a++)
                {
                    Console.Write(zadany_text[a] + " ");                                /* Výsledek hledání */
                }
                Console.WriteLine();
                Console.WriteLine("------------------------------------------");
            }
        }
        static void Funkce_programu2(string Text)
        {
            /* Najít a nahradit */
            Console.WriteLine("Zadejte hledané slovo:");
            string Najit_nahradit = Console.ReadLine();
            bool klic_slovo_nahradit = Text.Contains(Najit_nahradit);
            while (klic_slovo_nahradit == false)
            {
                Console.WriteLine("Zadané slovo text neobsahuje. (Program rozlišuje velká a malá písmena !!!)");     /* Ošetření vstupu, zjištění zda slovo existuje v textu */
                Najit_nahradit = Console.ReadLine();
                klic_slovo_nahradit = Text.Contains(Najit_nahradit);
            }
            if (klic_slovo_nahradit == true)
            {
                string[] zadany_text = Text.Split(' ');

                for (int i = 0; i < zadany_text.Length; i++)
                {
                    int Porovnani_slov = String.Compare(zadany_text[i], Najit_nahradit);
                    string slovicko = zadany_text[i];

                    bool Slovo_carka = slovicko.Contains(",");
                    bool Tecka = slovicko.Contains(".");
                    bool Vykricnik = slovicko.Contains("!");
                    bool Otaznik = slovicko.Contains("?");

                    if (Tecka == true)
                    {
                        string Najit_tecka = Najit_nahradit + ".";
                        Porovnani_slov = String.Compare(zadany_text[i], Najit_tecka);
                    }
                    if (Vykricnik == true)
                    {
                        string Najit_vykricnik = Najit_nahradit + "!";
                        Porovnani_slov = String.Compare(zadany_text[i], Najit_vykricnik);
                    }
                    if (Otaznik == true)
                    {
                        string Najit_otaznik = Najit_nahradit + "?";
                        Porovnani_slov = String.Compare(zadany_text[i], Najit_otaznik);    /* Stejný algortimus jako u "najít", podtrhne nám slova, která chceme nahradit. */
                    }
                    if (Slovo_carka == true)
                    {
                        string Najit_carka = Najit_nahradit + ",";
                        Porovnani_slov = String.Compare(zadany_text[i], Najit_carka);
                    }
                    if (Porovnani_slov == 0)
                    {
                        const string UNDERLINE = "\x1B[4m";
                        const string RESET = "\x1B[0m";
                        zadany_text[i] = UNDERLINE + zadany_text[i] + RESET;
                    }
                }
                Console.Clear();
                Console.WriteLine("------------------------------------------");
                for (int a = 0; a < zadany_text.Length; a++)
                {
                    Console.Write(zadany_text[a] + " ");                                /*Vypsnání nalezeného*/
                }
                Console.WriteLine();
                Console.WriteLine("------------------------------------------");

                Console.WriteLine("Nahradit slovem:");
                string Nahradit = Console.ReadLine();

                string Nalezeno_nahrazeno = Text.Replace(Najit_nahradit, Nahradit);      /* Samotné nahrazení */
                Console.WriteLine("------------------------------------------");
                Console.WriteLine(Nalezeno_nahrazeno);
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Přejete si uložit výsledek do souboru ? [A/N]");

                string ulozit = Console.ReadLine();

                while ((ulozit != "A") && (ulozit != "N"))
                {
                    Console.WriteLine("Zadejte [A/N]");                /*Možnost uložení do souboru*/
                    ulozit = Console.ReadLine();
                }
                if (ulozit == "A")
                {
                    try
                    {
                        Console.WriteLine("Zadejte název souboru");
                        string NazevSouboru = Console.ReadLine();
                        using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\" + NazevSouboru + ".txt"))  /*Uložení do souboru*/
                        {
                            sw.WriteLine(Nalezeno_nahrazeno);
                        }
                        Console.WriteLine("Soubor byl uložen na adresu " + Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\" + NazevSouboru + ".txt");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0} Program nemá práva zapisovat do Dokumentů", e);
                    }
                }
            }
        }
        static void Ukoncit_program()
        {
            ConsoleKeyInfo cki;
            Console.WriteLine("Press the Escape (Esc) key to quit \n");
            do
            {
                Console.SetCursorPosition(0, 10);  /*Funkce, která vypne program, když uživatel stiskne ESCAPE*/
                cki = Console.ReadKey();
            } while (cki.Key != ConsoleKey.Escape);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Vítejte v programu pro vyhledávání v textu. Vyberte jednu z níže nabízených možností.");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("1. Zadat text do konzole");
            Console.WriteLine("2. Načtení textu ze souboru");                                             /* Menu v hlavní časti programu */
            Console.WriteLine("3. Analýza textu");
            Console.WriteLine("4. Konec");
            Console.WriteLine("------------------------------------------");

            int volba;

            while (!int.TryParse(Console.ReadLine(), out volba) || volba > 4 || volba <= 0)
            {
                Console.Clear();
                Console.WriteLine("Vítejte v programu pro vyhledávání v textu. Vyberte jednu z níže nabízených možností.");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("1. Zadat text do konzole");
                Console.WriteLine("2. Načtení textu ze souboru");                                          /* Ošetření vstupů */
                Console.WriteLine("3. Analýza textu");
                Console.WriteLine("4. Konec");
                Console.WriteLine("------------------------------------------");

                Console.WriteLine("Zadejte číslo 1-4 !");
            }
            switch (volba)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Zadejte text:");
                    string Text = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine(Text);
                    Console.WriteLine("------------------------------------------");           /*Fáze zadávání textu a výber možností pro práci s ním. */
                    Console.WriteLine("Vyberte co chcete dělat s textem:");
                    Console.WriteLine("1. Najít");
                    Console.WriteLine("2. Najít a nahradit");
                    Console.WriteLine("------------------------------------------");
                    int Rozhodnuti;

                    while (!int.TryParse(Console.ReadLine(), out Rozhodnuti) || Rozhodnuti > 2 || Rozhodnuti <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine(Text);
                        Console.WriteLine("------------------------------------------");        /* Ošetření vstupu*/
                        Console.WriteLine("Vyberte co chcete dělat s textem:");
                        Console.WriteLine("1. Najít");
                        Console.WriteLine("2. Najít a nahradit");
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Zadejte číslo 1-2 !");
                    }
                    switch (Rozhodnuti)
                    {
                        case 1:
                            Funkce_programu(Text);          /* Zavolání výše uvedené funkce*/
                            Ukoncit_program();
                            break;
                        case 2:
                            Funkce_programu2(Text);
                            Ukoncit_program();
                            break;
                        default:
                            Console.WriteLine("Byla zadána neplatná volba!");
                            break;
                    }
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Uložte textový soubor na plochu a napište jeho název");              /* Načítání ze souboru */
                    Console.WriteLine("------------------------------------------");
                    string Cesta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);    /* Získání cesty na plochu */
                    string[] folders = Directory.GetFiles(Cesta, "*.txt", SearchOption.TopDirectoryOnly); /* Výpis souborů na ploše */
                    foreach (var value in folders)
                    {
                        Console.WriteLine(value);
                    }
                    string nazev = Console.ReadLine();
                    string path = Cesta + @"\" + nazev + ".txt";        /* Otevření a vyhledávání souboru (pro zjednodušení kódu musí být soubor formátu *.txt a být umístěn na ploše)*/
                    while (!File.Exists(path))
                    {
                        Console.WriteLine("Soubor neexistuje.");
                        nazev = Console.ReadLine();
                        path = Cesta + @"\" + nazev + ".txt";
                    }
                    if (File.Exists(path))
                    {
                        string Vlozeny_text = File.ReadAllText(path);

                        Console.Clear();
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine(Vlozeny_text);
                        Console.WriteLine("------------------------------------------"); /* Stejná práce s textem */
                        Console.WriteLine("Vyberte co chcete dělat s textem:");
                        Console.WriteLine("1. Najít");
                        Console.WriteLine("2. Najít a nahradit");
                        int Vyber;

                        while (!int.TryParse(Console.ReadLine(), out Vyber) || Vyber > 2 || Vyber <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine(Vlozeny_text);
                            Console.WriteLine("------------------------------------------");        /* Ošetření vstupu*/
                            Console.WriteLine("Vyberte co chcete dělat s textem:");
                            Console.WriteLine("1. Najít");
                            Console.WriteLine("2. Najít a nahradit");
                            Console.WriteLine("------------------------------------------");

                            Console.WriteLine("Zadejte číslo 1-2 !");
                        }
                        switch (Vyber)
                        {
                            case 1:
                                Funkce_programu(Vlozeny_text);
                                Ukoncit_program();
                                break;
                            case 2:
                                Funkce_programu2(Vlozeny_text);
                                Ukoncit_program();
                                break;
                            default:
                                Console.WriteLine("Byla zadána neplatná volba!");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Soubor neexistuje.");
                    }

                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Zadejte text:");
                    string text = Console.ReadLine();
                    int PocetSlov = 0, PocetZnaku = 0;

                    while (PocetZnaku < text.Length && char.IsWhiteSpace(text[PocetZnaku])) /* Spočítání počtu znaků*/
                        PocetZnaku++;

                    while (PocetZnaku < text.Length)
                    {
                        while (PocetZnaku < text.Length && !char.IsWhiteSpace(text[PocetZnaku])) /* Analýza textu*/
                            PocetZnaku++;

                        PocetSlov++;

                        while (PocetZnaku < text.Length && char.IsWhiteSpace(text[PocetZnaku])) /* Spočítání počtu slov*/
                            PocetZnaku++;
                    }
                    Console.Clear();
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine(text);
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("Počet slov: " + PocetSlov);
                    Console.WriteLine("Počet znaků " + PocetZnaku);
                    Console.WriteLine();

                    Ukoncit_program();

                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Byla zadána neplatná volba!");
                    break;
            }

        }
    }
}








