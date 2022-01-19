using Entities.Concrete;

BookWriter bookWriter = new() {Id=1, Name="furkan",SurName="Bozkurt"};
GraphicDirector GraphicDirector = new() { Id=2,Name=bookWriter.Name,SurName=bookWriter.SurName};

Console.WriteLine(bookWriter.Name+" "+bookWriter.SurName);
Console.WriteLine(GraphicDirector.Name+" "+GraphicDirector.SurName);