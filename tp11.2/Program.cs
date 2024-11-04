using System;

public class AbonnementAquaStreet
{
    private string nom;
    private string type;
    private int duree;

    public string Nom
    {
        get { return nom; }
        set { nom = value; }
    }

    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public int Duree
    {
        get { return duree; }
        set { duree = value; }
    }

    public AbonnementAquaStreet(string nom, string type, int duree)
    {
        Nom = nom;
        Type = type;
        Duree = duree;
    }

    public virtual double CalculerFraisAdhesion()
    {
        double tarifBase = 30.0;
        return tarifBase * duree;
    }

    public virtual string CheckOffresSpeciales()
    {
        return ((type == "Pacha" || type == "pacha") && duree >= 12)
            ? "Offre spéciale : 9% de réduction pour un abonnement Pacha de 1an ou plus."
            : "Aucune offre spéciale disponible pour cet abonnement.";
    }


    public virtual void Afficher()
    {
        Console.WriteLine("Nom de l'adhérent : " + Nom);
        Console.WriteLine("Type d'abonnement : " + Type);
        Console.WriteLine("Durée de l'abonnement : " + Duree + " mois");
        Console.WriteLine("Frais d'adhésion : " + CalculerFraisAdhesion() + " EUR");
        Console.WriteLine("Offres spéciales : " + CheckOffresSpeciales());
    }
}

public class AbonnementPacha : AbonnementAquaStreet
{
    private bool coachPersonnel;
    private bool accesDetente;

    public bool CoachPersonnel
    {
        get { return coachPersonnel; }
        set { coachPersonnel = value; }
    }

    public bool AccesDetente
    {
        get { return accesDetente; }
        set { accesDetente = value; }
    }

    public AbonnementPacha(string nom, string type, int duree, bool coachPersonnel, bool accesDetente)
        : base(nom, type, duree)
    {
        CoachPersonnel = coachPersonnel;
        AccesDetente = accesDetente;
    }

    public override double CalculerFraisAdhesion()
    {
        double tarifBase = 30.0;
        double frais = tarifBase * Duree;

        if (CoachPersonnel)
        {
            frais += 20.0 * Duree;
        }

        if (AccesDetente)
        {
            frais += 15.0 * Duree;
        }

        return frais;
    }

    public override void Afficher()
    {
        base.Afficher();
        Console.WriteLine("Coach personnel : " + (CoachPersonnel ? "Oui" : "Non"));
        Console.WriteLine("Accès à l'espace détente : " + (AccesDetente ? "Oui" : "Non"));
    }
}

class Program
{
    static void Main(string[] args)
    {
        AbonnementAquaStreet abonnementStandard = new AbonnementAquaStreet("Ayoub", "Standard", 4);
        Console.WriteLine("Affichage de l'abonnement standard :");
        abonnementStandard.Afficher();

        AbonnementPacha abonnementPacha = new AbonnementPacha("Youssef", "Pacha", 12, true, true);
        Console.WriteLine("\nAffichage de l'abonnement Pacha :");
        abonnementPacha.Afficher();
    }
}
