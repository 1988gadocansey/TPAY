using System.ComponentModel.DataAnnotations;

namespace TPAY.Models;

/// <summary>
/// Defines the Properties and methods of a User
/// </summary>
public class UserData:BaseEntity
{
       

    [Required]
    public string? UserId { get; set; }


    [Required]
    public string? FirstName { get; set; }

    [Required]
    public string? LastName { get; set; }

    [Required]
    public string? EmailAddress { get; set; }

    public string? PictureUrl { get; set; }

    [Required]
    public string? Provider { get; set; }

    public string Fullname()
    {
        return FirstName + " " + LastName;
    }
}