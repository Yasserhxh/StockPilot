using System;
using System.Collections.Generic;

namespace StockPilot.Domain.Entities;

public partial class Societé
{
    /// <summary>
    /// Identifiant unique de la société
    /// </summary>
    public int SocietéId { get; set; }

    /// <summary>
    /// Raison sociale ou nom de la société
    /// </summary>
    public string? SocietéRs { get; set; }

    /// <summary>
    /// Numéro d&apos;identification fiscale de la société
    /// </summary>
    public string? SocietéIf { get; set; }

    /// <summary>
    /// Adresse de la société
    /// </summary>
    public string? SocietéAdress { get; set; }

    /// <summary>
    /// Numéro de téléphone de la société
    /// </summary>
    public string? SocietéTelephone { get; set; }

    /// <summary>
    /// Clé étrangère qui fait référence à client_ID dans la table Client, indiquant le client associé à la société.
    /// </summary>
    public int? SocietéClientId { get; set; }

    /// <summary>
    /// Clé étrangère qui fait référence à la table Ville (par exemple, pour stocker l&apos;ID de la ville où se trouve la société).
    /// </summary>
    public int? SocietéVilleId { get; set; }

    public virtual ICollection<Site> Sites { get; set; } = new List<Site>();

    public virtual Client? SocietéClient { get; set; }

    public virtual Ville? SocietéVille { get; set; }
}
