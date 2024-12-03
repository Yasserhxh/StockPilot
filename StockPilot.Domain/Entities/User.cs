using Microsoft.AspNetCore.Identity;

namespace StockPilot.Domain.Entities;

/// <summary>
/// Represents a user in the authentication system, extending the IdentityUser class.
/// </summary>
public class User : IdentityUser<string>
{
    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// Gets or sets the first name of the user in Arabic.
    /// </summary>
    public string FirstNameAr { get; set; } = default!;

    /// <summary>
    /// Gets or sets the last name of the user in Arabic.
    /// </summary>
    public string LastNameAr { get; set; } = default!;

    /// <summary>
    /// Gets or sets the collection of user roles.
    /// </summary>
    public ICollection<UserRole> UserRoles { get; set; } = [];

    /// <summary>
    /// Gets the role names associated with the user.
    /// </summary>
    /// <returns>A list of role names.</returns>
    public IList<string> GetRoleNames() => UserRoles.Count != 0 ? UserRoles.Select(ur => ur.Role.Name!).ToList() : []; 
}
