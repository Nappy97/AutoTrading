namespace AutoTrading.Application.Common.Security;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class AuthorizeAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuthorizeAttribute"/> class. 
    /// </summary>
    public AuthorizeAttribute() { }

    /// <summary>
    /// Gets or sets a comma delimited list of roles that are allowed to access the resource.
    /// </summary>
    public long[] Roles { get; set; } = [];

    /// <summary>
    /// Gets or sets the policy name that determines access to the resource.
    /// </summary>
    public long[] Actions { get; set; } = [];
}