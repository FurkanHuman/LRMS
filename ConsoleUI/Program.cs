using Entities.Concrete.BookFirstPage;

BookWriter bookWriter = new() { Id = 1, Name = "furkan", SurName = "Bozkurt" };
GraphicDesignOrDirector graphicDesignOrDirector = new() { Id = 2, Name = bookWriter.Name, SurName = bookWriter.SurName };

Console.WriteLine(bookWriter.Name + " " + bookWriter.SurName);
Console.WriteLine(graphicDesignOrDirector.Name + " " + graphicDesignOrDirector.SurName);