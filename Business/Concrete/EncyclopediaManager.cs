using Business.Abstract;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class EncyclopediaManager : IEncyclopediaService
    {
        private readonly IEncyclopediaDal _encyclopediaDal;
    }
}
