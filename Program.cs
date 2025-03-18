using System;
using App.Models;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new DatabaseContext())
        {
            // Créer un utilisateur
            var user = new User
            {
                FullName = "John Doe",
                Email = "john.doe@example.com",
                PasswordHash = "hashedpassword", // Hash le mot de passe dans une application réelle
                Role = UserRole.Admin
            };

            context.Users.Add(user);
            context.SaveChanges();

            // Créer une thèse
            var thesis = new Thesis
            {
                Title = "Advanced AI Techniques",
                Author = "John Doe",
                Type = ThesisType.Doctorat,
                SubmissionDate = DateTime.Now,
                Keywords = "AI, Machine Learning",
                FilePath = "/path/to/thesis.pdf",
                UserId = user.Id // Lier la thèse à l'utilisateur
            };

            context.Theses.Add(thesis);
            context.SaveChanges();

            Console.WriteLine("Utilisateur et thèse ajoutés avec succès !");
        }
    }
}