using System;
using System.Collections.Generic;

namespace PowerPlantAccounting
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }

        public Transaction(int id, string description)
        {
            Id = id;
            Description = description;
            Note = string.Empty;
        }

        public void AddNote(string note)
        {
            Note = note;
            Console.WriteLine($"Примітку додано до транзакції {Id}: {Note}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var transactions = new List<Transaction>
            {
                new Transaction(1, "Купівля обладнання"),
                new Transaction(2, "Оплата послуг")
            };

            Console.WriteLine("Оберіть транзакцію за ID:");
            foreach (var t in transactions)
            {
                Console.WriteLine($"ID: {t.Id}, Опис: {t.Description}");
            }

            int selectedId = int.Parse(Console.ReadLine());
            var transaction = transactions.Find(t => t.Id == selectedId);

            if (transaction != null)
            {
                Console.WriteLine("Введіть примітку:");
                string note = Console.ReadLine();
                transaction.AddNote(note);
            }
            else
            {
                Console.WriteLine("Транзакцію не знайдено.");
            }
        }
    }
}
