using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Application.Excepetions;

public class AuthorizationProblemDetails : ProblemDetails
{
    public override string ToString() => JsonConvert.SerializeObject(this);
}