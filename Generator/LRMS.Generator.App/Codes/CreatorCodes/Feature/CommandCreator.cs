namespace LRMS.Generator.App.Codes.CreatorCodes.Feature;

internal class CommandCreator
{
    public static string EntitiyCommand(string nameSpacePath, string commandName, string dtoName)
    {
        return
$@"// this file was created automatically.
using MediatR;
using Core.Application.Pipelines.Authorization;

namespace {nameSpacePath};

public class {commandName}Command : IRequest<{dtoName}>, ISecuredRequest
{{

public string[] Roles =>new[] {{""}};

}}
";
    }

    public static string EntitiyCommandHandler(string nameSpacePath, string commandName, string dtoName)
    {
        return
$@"// this file was created automatically.
using MediatR;

namespace {nameSpacePath};

public class {commandName}CommandHandler : IRequestHandler<{commandName}Command, {dtoName}>
{{
    public Task<BlablaDTO> Handle({commandName}Command request, CancellationToken cancellationToken)
    {{
        throw new NotImplementedException();
    }}
}}
";
    }

    public static string EntitiyCommandValidator(string nameSpacePath, string commandName)
    {
        return
$@"// this file was created automatically.

using FluentValidation;

namespace {nameSpacePath};

public class {commandName}CommandValidator : AbstractValidator<{commandName}Command>
{{
    public {commandName}CommandValidator()
    {{
    }}
}}
";
    }
}
