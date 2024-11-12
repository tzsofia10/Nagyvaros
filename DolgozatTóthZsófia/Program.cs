using DolgozatTóthZsófia;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
       
        List<Nagyvaros> nagyvarosok = new();
        using StreamReader sr = new StreamReader(
            path: @"..\..\..\src\varosok.csv",
            encoding: Encoding.UTF8);

            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                 nagyvarosok.Add(new Nagyvaros(sr.ReadLine()));
            }

        sr.Close();


        Console.WriteLine($"Összes város: {nagyvarosok.Count}");

        // 1) feladat
        double kinaiOsszNepesseg = nagyvarosok
            .Where(varos => varos.Orszag == "Kína")
            .Sum(varos => varos.Nepesseg);
        Console.WriteLine($"Kínai nagyvárosok össznépessége: {kinaiOsszNepesseg:F2} millió fő");

        // 2) feladat
        double indiaiAtlag = nagyvarosok
            .Where(varos => varos.Orszag == "India")
            .Average(varos => varos.Nepesseg);
        Console.WriteLine($"Indiai nagyvárosok átlaglélekszáma: {indiaiAtlag:F2} millió fő");

        // 3) feladat
        var legnepesebb = nagyvarosok
            .OrderByDescending(varos => varos.Nepesseg)
            .First();
        Console.WriteLine($"Legnépesebb város: {legnepesebb}");

        // 4) feladat
        var nagyvarosok20MFelett = nagyvarosok
            .Where(varos => varos.Nepesseg > 20)
            .OrderByDescending(varos => varos.Nepesseg)
            .ToList();
        Console.WriteLine("20M lakos feletti nagyvárosok (csökkenő sorrendben):");
        nagyvarosok20MFelett.ForEach(Console.WriteLine);

        // 5) feladat
        int tobbVarossalRendelkezoOrszagok = nagyvarosok
            .GroupBy(varos => varos.Orszag)
            .Count(g => g.Count() > 1);
        Console.WriteLine($"Országok, amelyek több nagyvárossal szerepelnek: {tobbVarossalRendelkezoOrszagok}");

        // 6) feladat
        var legtobbKezdobetu = nagyvarosok
            .GroupBy(varos => varos.Nev[0])
            .OrderByDescending(g => g.Count())
            .First().Key;
        Console.WriteLine($"A legtöbb nagyváros neve ezzel a betűvel kezdődik: {legtobbKezdobetu}");
    }
}

