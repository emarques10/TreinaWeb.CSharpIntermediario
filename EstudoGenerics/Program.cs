using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa pessoa = new Pessoa
            {
                Id = 1,
                Nome = "Teste"

            };
            Animal animal = new Animal
            {
                Id = 1,
                Especie = "cachorro"
            };
            RepositorioGenerico<Pessoa> Pessoas = new RepositorioGenerico<Pessoa>();
            RepositorioGenerico<Animal> Animais = new RepositorioGenerico<Animal>();

            Pessoas.Insert(pessoa);
            Animais.Insert(animal);

            foreach(Pessoa p in Pessoas.Get())
            {
                Console.WriteLine(p.Nome);
            }

            foreach(Animal a in Animais.Get())
            {
                Console.WriteLine(a.Especie);
            }
            //Console.ReadKey();
        }
    }
}
