using System;
using System.Collections.Generic;

namespace StockPilot.Domain.Entities;

public partial class Client
{
    /// <summary>
    /// Identifiant unique pour chaque client
    /// </summary>
    public int ClientId { get; set; }

    /// <summary>
    /// Nom du client
    /// </summary>
    public string? ClientNom { get; set; }

    /// <summary>
    /// Adresse physique du client
    /// </summary>
    public string? ClientAdress { get; set; }

    /// <summary>
    /// Adresse e-mail du client
    /// </summary>
    public string? ClientEmail { get; set; }

    /// <summary>
    /// Numéro de téléphone du client
    /// </summary>
    public string? ClientTelephone { get; set; }

    /// <summary>
    /// Indique si le client est actif (1 = actif, 0 = inactif)
    /// </summary>
    public bool? ClientIsActive { get; set; }

    /// <summary>
    /// Date de création du client dans le système
    /// </summary>
    public DateOnly? ClientDateCreation { get; set; }

    /// <summary>
    /// Date à partir de laquelle le client est devenu inactif
    /// </summary>
    public DateOnly? ClientDateInactif { get; set; }

    public string? ClientPassword { get; set; }

    public string? ClientUsername { get; set; }

    public virtual ICollection<Societé> Societés { get; set; } = new List<Societé>();
}
