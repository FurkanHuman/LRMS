using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperationAttribute : MethodInterceptionAttribute
    {
        private readonly string[] _roles;
        private readonly IHttpContextAccessor? _httpContextAccessor;

        public SecuredOperationAttribute(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            List<string>? roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

            foreach (string role in _roles)
                if (roleClaims.Contains(role))
                    return;

            throw new Exception(/* mesaj gelecek*/);
        }
    }
}
