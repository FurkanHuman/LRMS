// this file was created automatically.
using Application.Repositories;
using Application.Features.CoverCaps.Constants;
using Core.Application.Rules;
using Domain.Entities.Infos;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Application.Features.CoverCaps.Rules;

public class CoverCapBusinessRules : BaseBusinessRules
{

    private readonly ICoverCapRepository _covercapRepository;

    public CoverCapBusinessRules(ICoverCapRepository covercapRepository)
    {
        _covercapRepository = covercapRepository;
    }

    internal void NameIsExit(CoverCap coverCap)
    {
        bool result = _covercapRepository.Any(c => c.Name.ToLower() == coverCap.Name.ToLower());
        if (result)
            throw new BusinessException(CoverCapMessages.NameIsExit);
    }

    internal void IdIsExit(CoverCap coverCap)
    {
        bool result = _covercapRepository.Any(c => c.Id == coverCap.Id);
        if (result)
            throw new BusinessException(CoverCapMessages.IdIsExit);
    }
}
