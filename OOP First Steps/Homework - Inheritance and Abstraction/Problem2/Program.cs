namespace Problem2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Frog goshko = new Frog("Goshko", 10, Gender.Male);
                Frog peshko = new Frog("Peshko", 3, Gender.Male);
                Frog mariika = new Frog("Mariika", 7, Gender.Female);

                Dog ivancho = new Dog("Ivancho", 11, Gender.Male);
                Dog sashko = new Dog("Sashko", 1, Gender.Male);
                Dog magdalena = new Dog("Magdalena", 2, Gender.Female);

                Kitten tania = new Kitten("Tania", 3);
                Kitten penka = new Kitten("Penka", 4);
                Kitten goshka = new Kitten("Goshka", 10);

                Tomcat kristian = new Tomcat("Kristian", 1);
                Tomcat pesho = new Tomcat("Pesho", 10);
                Tomcat stanislav = new Tomcat("Stanislav", 5);

                IList<Animal> animals = new List<Animal>()
                {
                goshko, peshko, mariika, ivancho, sashko, magdalena,
                tania, penka, goshka, kristian, pesho, stanislav
                };

                double catsAvarageYears = animals.Where(a => a is Cat)
                    .Average(cat => cat.Age);

                double dogsAvarageYears = animals.Where(a => a is Dog)
                    .Average(dog => dog.Age);

                double frogsAvarageYears = animals.Where(a => a is Frog)
                    .Average(frog => frog.Age);

                Console.WriteLine("Cats avarage yers is {0:F2}", frogsAvarageYears);
                Console.WriteLine("Dogs avarage yers is {0:F2}", dogsAvarageYears);
                Console.WriteLine("Frogs avarage yers is {0:F2}", frogsAvarageYears);
            }
            catch (ArgumentOutOfRangeException aoorx)
            {
                Console.WriteLine(aoorx.Message);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
