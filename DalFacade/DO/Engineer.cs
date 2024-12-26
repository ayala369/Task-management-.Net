

using System.Reflection.Emit;
using System.Security.Cryptography;

namespace DO;
/// <summary>
/// /// Defining the attributes of the Engineer entity 

/// </summary>
/// <param name="Id">Id of the engineer</param>
/// <param name="Name">Name of the engineer</param>
/// <param name="Email">Email of the engineer</param>
/// <param name="Level">Level of the engineer</param>
/// <param name="Cost">Cost of the engineer</param>
public record Engineer
(
    int Id,
    string Name,
    string Email,
EngineerExperience? Level=null,
    double? Cost=null
)
{
    public Engineer() : this(0, "", "", null, null) { }
}

