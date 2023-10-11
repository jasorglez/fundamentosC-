using fundamentals.Models;
using System.Text.Json ;
using System.Text.Json.Serialization;
using System;


Beer beer = new Beer("Azul", "Descripcion del JSON", 34);

string miJson = JsonSerializer.Serialize(beer);

File.WriteAllText("objeto.txt", miJson);

string miJsonw = File.ReadAllText("objeto.txt");

Beer beer2  = JsonSerializer.Deserialize<Beer>(miJsonw);

string x = "dd";
