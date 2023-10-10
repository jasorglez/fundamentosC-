// See https://aka.ms/new-console-template for more information
using fundamentals.Models;
using System;




var bebidaAlcoholica = new Vino(100);
MostrarRecomendacion(bebidaAlcoholica);

var bebidaAlc2 = new Beer(90);
MostrarRecomendacion(bebidaAlc2);

static void MostrarRecomendacion(IBeerAlcoholic bebida)
{
    bebida.MaxRecomendado();
}
