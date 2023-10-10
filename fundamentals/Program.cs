// See https://aka.ms/new-console-template for more information
using fundamentals.Models;
using System;



CervezaBD cervezaBD = new CervezaBD();

var cervezas = cervezaBD.Get();

foreach (var item in cervezas)
{
    Console.WriteLine(item.Name);
}