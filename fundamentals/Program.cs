// See https://aka.ms/new-console-template for more information
using fundamentals.Models;
using System;



int numero = new int();

int? numero2 = null;

Console.WriteLine(numero.ToString());
Console.WriteLine(numero2.ToString());

var persona = new { nombre = "Angel", apellido = "Soriano" };

Console.WriteLine(persona.nombre);
Console.WriteLine(persona.apellido);

int[] numeros = new int[10] { 1, 9, 4, 5, 6, 7, 8, 9, 2, 3 };


for ( int i=0; i < numeros.Length; i++)
    {
    Console.WriteLine("interaccion = " + i + "-" + numeros[i]);
    }



foreach (var numerow in numeros)
{
    Console.WriteLine("Uso foreach="+numerow);
}

List<int> namelista= new List<int>() { 1,2,3,4,5,6,7,8};

namelista.Add(9);
namelista.Add(10);

namelista.Remove(3);

foreach (var numerow in namelista)
{
    Console.WriteLine("Uso de Listas =" + numerow);
}


List<Beer> namebeers = new List<Beer>() { new Beer(1, "Corona", "Primer Cerveza", 92) };

namebeers.Add(new Beer(2, "Tecate", "Segunda Cerveza", 22));

Beer superior = new Beer(3, "Superior", "Tercera Cerveza", 22);

namebeers.Add(superior);

foreach (var namebeer in namebeers)
{
    Console.WriteLine("Clase Cerveza Name =" + namebeer.Name  + "Clase Cerveza Descripcion =" + namebeer.Description);
}

