using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module8prac2
{
    class Supermarket
    {
        private string[] products = { "Хлеб", "Молоко", "Яйца", "Фрукты" };
        private double[] prices = { 1.0, 2.0, 1.5, 3.0 };

        private double discountPercent;

        public Supermarket(double discountPercent)
        {
            this.discountPercent = discountPercent;
        }

        public double this[int productIndex, int quantity]
        {
            get
            {
                if (productIndex >= 0 && productIndex < products.Length && quantity > 0)
                {
                    return prices[productIndex] * quantity;
                }
                else
                {
                    throw new ArgumentException("Некорректный выбор продукта или количество.");
                }
            }
        }

        public double ApplyDiscount(double totalCost)
        {
            return totalCost * (1 - discountPercent);
        }

        public void DisplayProducts()
        {
            Console.WriteLine("Продукты в нашем ассортименте:");
            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i]} - {prices[i]:C}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в продуктовый супермаркет!");

            // Создаем экземпляр класса Supermarket с 5% скидкой
            Supermarket supermarket = new Supermarket(0.05);

            supermarket.DisplayProducts();

            double totalCost = 0.0;

            while (true)
            {
                Console.Write("Введите номер продукта (0 для завершения): ");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 0)
                    break;

                Console.Write($"Введите количество: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                try
                {
                    double productCost = supermarket[choice - 1, quantity];
                    totalCost += productCost;
                    Console.WriteLine($"Сумма за продукт: {productCost:C}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            double finalCost = supermarket.ApplyDiscount(totalCost);

            Console.WriteLine($"Итоговая сумма к оплате: {finalCost:C}");
            Console.WriteLine("Спасибо за покупки!");
        }
    }
}
