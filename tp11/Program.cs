using System;

public class Animal 
{
    private string nom;
    private string famille;
    private int age;

    public string Nom 
    {
        get { return nom; }
        set { nom = value; }
    }

    public string Famille
    {
        get { return famille; }
        set { famille = value; }
    }

    public int Age 
    {
        get { return age; }
        set { age = value; }
    }

    public Animal() {}

    public Animal(string nom, string famille, int age)
    {
        Nom = nom;
        Famille = famille;
        Age = age;
    }

    public Animal(Animal a)
    {
        nom = a.nom;
        famille = a.famille;
        age = a.age;
    }

    public int CalculerAge()
    {
        return age * 7;
    }

    public void AfficherAnimal()
    {
        Console.WriteLine("Nom : " + nom);
        Console.WriteLine("Famille : " + famille);
        Console.WriteLine("Âge : " + age);
    }

    public override string ToString()
    {
        return $"Nom: {Nom}, Famille: {Famille}, Âge: {Age}";
    }
}

public class Chien : Animal
{
    private string loisir;

    public string Loisir
    {
        get { return loisir; }
        set { loisir = value; }
    }

    public Chien(string nom, string famille, int age, string loisir) : base(nom, famille, age)
    {
        this.loisir = loisir;
    }

    public void AfficherChien()
    {
        AfficherAnimal();
        Console.WriteLine("Loisir : " + loisir);
    }
}

public class Chat : Animal
{
    private int poids;

    public int Poids
    {
        get { return poids; }
        set { poids = value; }
    }

    public Chat(string nom, string famille, int age, int poids) : base(nom, famille, age)
    {
        this.poids = poids;
    }

    public void AfficherChat()
    {
        AfficherAnimal();
        Console.WriteLine("Poids : " + poids + " kg");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Chien chien = new Chien("Noisette", "Labrador", 5, "manger des croquettes");
        Chat chat = new Chat("Neige", "Félin", 3, 6);
       

        Console.WriteLine("Affichage du chien :");
        chien.AfficherChien();
      
         

        Console.WriteLine("\nAffichage du chat :");
        chat.AfficherChat();
       

        Console.WriteLine("\nÂge du chien en années humaines : " + chien.CalculerAge());
        Console.WriteLine("\nÂge du chat en années humaines : " + chat.CalculerAge());

    }
}
