using System;
using System.Collections.Generic;

namespace StockPilot.Domain.Entities;

public partial class Site
{
    /// <summary>
    ///  Identifiant unique du site
    /// </summary>
    public int SiteId { get; set; }

    /// <summary>
    /// Nom du site
    /// </summary>
    public string? SiteNom { get; set; }

    /// <summary>
    /// Adresse physique du site
    /// </summary>
    public string? SiteAdress { get; set; }

    /// <summary>
    /// Clé étrangère qui fait référence à Ville_Id dans la table Ville, indiquant la ville où se trouve le site.
    /// </summary>
    public int? SiteVilleId { get; set; }

    /// <summary>
    /// Identifiant de la société propriétaire du site
    /// </summary>
    public int? SiteSocieteId { get; set; }

    public virtual ICollection<Inventaire> Inventaires { get; set; } = new List<Inventaire>();

    public virtual ICollection<Operateur> Operateurs { get; set; } = new List<Operateur>();

    public virtual Societé? SiteSociete { get; set; }

    public virtual Ville? SiteVille { get; set; }

    public virtual ICollection<Zone> Zones { get; set; } = new List<Zone>();
}
