using Microsoft.EntityFrameworkCore.Query.Internal;
using PluralizeService.Core;

namespace LRMS.Generator.App.Codes.CreatorCodes.Feature;

internal  class QueryCreator
{
    public static string GetListEntityQuery(Type type)
    {
        string plural = PluralizationProvider.Pluralize(type.Name);

        return
            $@"// this file was created automatically.
using Application.Features.{plural}.Models;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.{plural}.Queries.GetList{type.Name};

public class GetList{type.Name}Query : IRequest<{type.Name}ListModel>
{{
    public PageRequest PageRequest {{ get; set; }}
}}
";
    }
    public static string GetListEntityQueryHandler(Type type)
    {
        string plural = PluralizationProvider.Pluralize(type.Name);

        return
            $@"// this file was created automatically.

using Application.Features.{plural}.Models;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using {type.Namespace};
using MediatR;

namespace Application.Features.{plural}.Queries.GetList{type.Name};

public class GetList{type.Name}QueryHandler : IRequestHandler<GetList{type.Name}Query, {type.Name}ListModel>
    {{
        private readonly I{type.Name}Repository _{type.Name.ToLower()}Repository;
        private readonly IMapper _mapper;

        public GetList{type.Name}QueryHandler(I{type.Name}Repository {type.Name.ToLower()}Repository, IMapper mapper)
        {{
            _{type.Name.ToLower()}Repository = {type.Name.ToLower()}Repository;
            _mapper = mapper;
        }}

        public async Task<{type.Name}ListModel> Handle(GetList{type.Name}Query request, CancellationToken cancellationToken)
        {{
            IPaginate<{type.Name}> {plural.ToLower()} = await _{type.Name.ToLower()}Repository.GetListAsync(index: request.PageRequest.Page,
                                                                          size: request.PageRequest.PageSize);
            {type.Name}ListModel mapped{type.Name}ListModel = _mapper.Map<{type.Name}ListModel>({plural.ToLower()});
            return mapped{type.Name}ListModel;
        }}
    }}
";
    }
    public static string GetByIdEntityQuery(Type type)
    {
        string plural = PluralizationProvider.Pluralize(type.Name);

        return
            $@"// this file was created automatically.
using Application.Features.{plural}.Dtos;
using MediatR;

namespace Application.Features.{plural}.Queries.GetById{type.Name};

public class GetById{type.Name}Query : IRequest<{type.Name}Dto>
{{

}}
";
    }
    public static string GetByIdEntityQueryHandler(Type type)
    {
        string plural = PluralizationProvider.Pluralize(type.Name);

        return
            $@"// this file was created automatically.

using Application.Features.{plural}.Dtos;
using Application.Features.{plural}.Rules;
using Application.Repositories;
using AutoMapper;
using {type.Namespace};
using MediatR;

namespace Application.Features.{plural}.Queries.GetById{type.Name};

public class GetById{type.Name}QueryHandler : IRequestHandler<GetById{type.Name}Query, {type.Name}Dto>
    {{
        private readonly I{type.Name}Repository _{type.Name.ToLower()}Repository;
        private readonly IMapper _mapper;
        private readonly {type.Name}BusinessRules _{type.Name.ToLower()}BusinessRules;

        public GetById{type.Name}QueryHandler(I{type.Name}Repository {type.Name.ToLower()}Repository,{type.Name}BusinessRules {type.Name.ToLower()}BusinessRules, IMapper mapper)
        {{
            _{type.Name.ToLower()}Repository = {type.Name.ToLower()}Repository;
            _{type.Name.ToLower()}BusinessRules = {type.Name.ToLower()}BusinessRules;
            _mapper = mapper;
        }}

        public async Task<{type.Name}Dto> Handle(GetById{type.Name}Query request, CancellationToken cancellationToken)
        {{
            // await _{type.Name.ToLower()}BusinessRules.{type.Name}IdShouldExistWhenSelected(request.Id);

            {type.Name}? {type.Name.ToLower()} = await _{type.Name.ToLower()}Repository.GetAsync({type.Name[0]} => {type.Name[0]}.Id == request.Id);
            
            {type.Name}Dto {type.Name.ToLower()}Dto = _mapper.Map<{type.Name}Dto>({type.Name.ToLower()});
            return {type.Name.ToLower()}Dto;
        }}
";
    }
    public static string GetListEntityByDynamicQuery(Type type)
    {
        string plural = PluralizationProvider.Pluralize(type.Name);

        return
            $@"// this file was created automatically.
using Application.Features.{plural}.Models;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;

namespace Application.Features.{plural}.Queries.GetList{type.Name}ByDynamic;

public class GetList{type.Name}ByDynamicQuery : IRequest<{type.Name}ListModel>
{{
    public PageRequest PageRequest {{ get; set; }}
    public Dynamic Dynamic {{ get; set; }}
}}
";
    }
    public static string GetListEntityByDynamicQueryHandler(Type type)
    {
        string plural = PluralizationProvider.Pluralize(type.Name);

        return
            $@"// this file was created automatically.

using Application.Features.{plural}.Models;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using {type.Namespace};
using MediatR;

namespace Application.Features.{plural}.Queries.GetList{type.Name}ByDynamic;

public class GetList{type.Name}ByDynamicQueryHandler : IRequestHandler<GetList{type.Name}ByDynamicQuery request, {type.Name}ListModel>
    {{
        private readonly I{type.Name}Repository _{type.Name.ToLower()}Repository;
        private readonly IMapper _mapper;

 public async Task<CarListModel> Handle(GetListCarByDynamicQuery request, CancellationToken cancellationToken)
        {{
            IPaginate<{type.Name}> {plural.ToLower()} = await _{type.Name.ToLower()}Repository.GetListByDynamicAsync(
                                      request.Dynamic,
                                      {type.Name[0].ToString().ToLower()} => // c.Include(c => c.Model)
                                   //         .Include(c => c.Model.Brand)
                                   //         .Include(c => c.Color),
                                      request.PageRequest.Page,
                                      request.PageRequest.PageSize);
            {type.Name}ListModel mapped{type.Name}ListModel = _mapper.Map<{type.Name}ListModel>({plural.ToLower()});
            return mapped{type.Name}ListModel;
        }}
    }}
";
    }



}
