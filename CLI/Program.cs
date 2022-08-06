// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using Business.DependencyResolvers;
using Core.Utilities.Result.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Infos;

Console.WriteLine("Hello, World!");

WriterManager writerManager = new(new EfWriterDal());
int count = 0;
foreach (var item in writerManager.DtoGetAll().Data)
{
    count++;
}
Console.WriteLine(count);










//using StreamReader reader = new("random_names_fossbytes.txt");
//using StreamReader readerdegree = new("degress.txt");
//Random random = new Random();
//Writer writer;


//List<string> preAttachList = new();

//string line;

//while ((line = readerdegree.ReadLine()) != null)
//{
//    preAttachList.Add(line);
//}

//string[] preAttachArray = preAttachList.ToArray();
//Console.WriteLine(preAttachArray.Count());
//Console.ReadLine();
//Guid.NewGuid();
//while ((line = reader.ReadLine()) != null)
//{
//    string[] words = line.Split(' ');
//    writer = new()
//    {
//        Id=Guid.NewGuid(),
//        Name = words[0],
//        SurName = words[1],
//        NamePreAttachment =  preAttachArray[random.Next(150)]
//    };
//    IResult result= writerManager.Add(writer);
//    if (!result.Success)
//        Console.WriteLine(result.Message);
//    Console.WriteLine(writer.NamePreAttachment.ToString() + " " + writer.Name + " " + writer.SurName + " " + writer.Id);
//}




