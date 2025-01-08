using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Application.Excepetions;

public class BusinessProblemDetails : ProblemDetails
{
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}