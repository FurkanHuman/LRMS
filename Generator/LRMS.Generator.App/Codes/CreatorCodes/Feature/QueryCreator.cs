using PluralizeService.Core;

namespace LRMS.Generator.App.Codes.CreatorCodes.Feature;

internal class QueryCreator : ICreatorCode
{
    public QueryCreator(Type type)
    {
        Type = type;
    }

    public Type Type { get; set; }

    public string GetByIdEntityQuery()
    {
        string plural = PluralizationProvider.Pluralize(Type.Name);

        return
            $@"// this file was created automatically.
using MediatR;

namespace Application.Features.{plural}.Queries.GetById{Type.Name};

public class GetById{Type.Name}Query : IRequest<GetById{Type.Name}Response>
{{

}}
";
    }

    public string GetByIdEntityQueryHandler()
    {
        string plural = PluralizationProvider.Pluralize(Type.Name);

        string letter = Type.Name[0].ToString().ToLower();
        return
            $@"// this file was created automatically.
using Application.Features.{plural}.Rules;
using Application.Repositories;
using AutoMapper;
using {Type.Namespace};
using MediatR;

namespace Application.Features.{plural}.Queries.GetById{Type.Name};

public class GetById{Type.Name}QueryHandler : IRequestHandler<GetById{Type.Name}Query, GetById{Type.Name}Response>
{{
    private readonly I{Type.Name}Repository _{Type.Name.ToLower()}Repository;
    private readonly IMapper _mapper;
    private readonly {Type.Name}BusinessRules _{Type.Name.ToLower()}BusinessRules;

    public GetById{Type.Name}QueryHandler(I{Type.Name}Repository {Type.Name.ToLower()}Repository,{Type.Name}BusinessRules {Type.Name.ToLower()}BusinessRules, IMapper mapper)
    {{
        _{Type.Name.ToLower()}Repository = {Type.Name.ToLower()}Repository;
        _{Type.Name.ToLower()}BusinessRules = {Type.Name.ToLower()}BusinessRules;
        _mapper = mapper;
    }}

    public async Task<GetById{Type.Name}Response> Handle(GetById{Type.Name}Query request, CancellationToken cancellationToken)
    {{

        {Type.Name}? {Type.Name.ToLower()} = await _{Type.Name.ToLower()}Repository.GetAsync({letter} => {letter} == {letter} );
            
        GetById{Type.Name}Response {Type.Name.ToLower()}ListModelResponse = _mapper.Map<GetById{Type.Name}Response>({Type.Name.ToLower()});
        return {Type.Name.ToLower()}ListModelResponse;
    }}
}}
";
    }

    public string GetListByEntityQuery()
    {
        string plural = PluralizationProvider.Pluralize(Type.Name);

        return
            $@"// this file was created automatically.
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.{plural}.Queries.GetListBy{Type.Name};

public class GetListBy{Type.Name}Query : IRequest<GetListResponse<GetListBy{Type.Name}Response>>
{{
    public PageRequest PageRequest {{ get; set; }}
}}
";
    }

    public string GetListByEntityQueryHandler()
    {
        string plural = PluralizationProvider.Pluralize(Type.Name);

        return
            $@"// this file was created automatically.
using Application.Repositories;
using AutoMapper;
using {Type.Namespace};
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.{plural}.Queries.GetListBy{Type.Name};

public class GetListBy{Type.Name}QueryHandler : IRequestHandler<GetListBy{Type.Name}Query, GetListResponse<GetListBy{Type.Name}Response>>
{{
    private readonly I{Type.Name}Repository _{Type.Name.ToLower()}Repository;
    private readonly IMapper _mapper;

    public GetListBy{Type.Name}QueryHandler(I{Type.Name}Repository {Type.Name.ToLower()}Repository, IMapper mapper)
    {{
        _{Type.Name.ToLower()}Repository = {Type.Name.ToLower()}Repository;
        _mapper = mapper;
    }}

    public async Task<GetListResponse<GetListBy{Type.Name}Response>> Handle(GetListBy{Type.Name}Query request, CancellationToken cancellationToken)
    {{
        IPaginate<{Type.Name}> {plural.ToLower()} = await _{Type.Name.ToLower()}Repository.GetListAsync(index: request.PageRequest.Page,
                                                                                                        size: request.PageRequest.PageSize,
                                                                                                        cancellationToken: cancellationToken);

        GetListResponse<GetListBy{Type.Name}Response> mappedGetListResponse = _mapper.Map<GetListResponse<GetListBy{Type.Name}Response>>({plural.ToLower()});
        return mappedGetListResponse;
    }}
}}
";
    }

    public string GetListByEntityDynamicQuery()
    {
        string plural = PluralizationProvider.Pluralize(Type.Name);

        return
            $@"// this file was created automatically.
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.{plural}.Queries.GetListBy{Type.Name}Dynamic;

public class GetListBy{Type.Name}DynamicQuery : IRequest<GetListResponse<GetListBy{Type.Name}DynamicQueryResponse>>
{{
    public PageRequest PageRequest {{ get; set; }}
    public DynamicQuery DynamicQuery {{ get; set; }}
}}
";
    }

    public string GetListByEntityDynamicQueryHandler()
    {
        string plural = PluralizationProvider.Pluralize(Type.Name);

        return
            $@"// this file was created automatically.
using Application.Repositories;
using AutoMapper;
using {Type.Namespace};
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.{plural}.Queries.GetListBy{Type.Name}Dynamic;

public class GetListBy{Type.Name}DynamicQueryHandler : IRequestHandler<GetListBy{Type.Name}DynamicQuery, GetListResponse<GetListBy{Type.Name}DynamicQueryResponse>>
{{
    private readonly I{Type.Name}Repository _{Type.Name.ToLower()}Repository;
    private readonly IMapper _mapper;

    public GetListBy{Type.Name}DynamicQueryHandler(I{Type.Name}Repository {Type.Name.ToLower()}Repository, IMapper mapper)
    {{
        _{Type.Name.ToLower()}Repository = {Type.Name.ToLower()}Repository;
        _mapper = mapper;
    }}

    public async Task<GetListResponse<GetListBy{Type.Name}DynamicQueryResponse>> Handle(GetListBy{Type.Name}DynamicQuery request, CancellationToken cancellationToken)
    {{
        IPaginate<{Type.Name}> {plural.ToLower()} = await _{Type.Name.ToLower()}Repository.GetListByDynamicAsync(
                                                                                                                  dynamic: request.DynamicQuery,
                                                                                                                  index: request.PageRequest.Page,
                                                                                                                  size: request.PageRequest.PageSize,
                                                                                                                  cancellationToken: cancellationToken);

        GetListResponse<GetListBy{Type.Name}DynamicQueryResponse> mappedGetListResponse = _mapper.Map<GetListResponse<GetListBy{Type.Name}DynamicQueryResponse>>({plural.ToLower()});
        return mappedGetListResponse;
    }}
}}
";
    }

}
