using Yafet_Flores_20251900155_ConexionAPI.AppServices;
using Yafet_Flores_20251900155_ConexionAPI.Modelo;

var servicio = new dogsServices();
var datos = await servicio.GetDogFacts();

foreach (var item in datos)
{
    Console.WriteLine(item);
}