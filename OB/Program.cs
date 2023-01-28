// See https://aka.ms/new-console-template for more information
using OB.ContentContext;

Console.WriteLine("Hello, World!");

var carrer = new Career("Back end", "carrer-backend");

var course = new Course("Fundamentos .Net", "fundamentos-dotnet");
var carrerItem = new CareerItem(0, "Back End", "", course);
carrer.Items.Add(carrerItem);


foreach (var item in carrer.Items)
{
  System.Console.WriteLine(item.Title);
  System.Console.WriteLine(item.Order);
}