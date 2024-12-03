using System;
using System.Collections.Generic;

namespace StockPilot.Domain.Entities;

public partial class Operateur
{
    /// <summary>
    /// Identifiant unique pour chaque opérateur.
    /// </summary>
    public int OperateurId { get; set; }

    /// <summary>
    /// Nom de l&apos;opérateur.
    /// </summary>
    public string? OperateurNom { get; set; }

    /// <summary>
    /// Prénom de l&apos;opérateur.
    /// </summary>
    public string? OperateurPrenom { get; set; }

    /// <summary>
    /// Numéro de carte d&apos;identité nationale de l&apos;opérateur.
    /// </summary>
    public string? OperateurCin { get; set; }

    /// <summary>
    /// Nom d&apos;utilisateur pour se connecter au système.
    /// </summary>
    public string? OperateurUsername { get; set; }

    /// <summary>
    /// Mot de passe pour se connecter au système.
    /// </summary>
    public string? OperateurPassword { get; set; }

    /// <summary>
    /// Référence à l&apos;identifiant du site où l&apos;opérateur travaille. C&apos;est une clé étrangère qui fait référence à la table Site.
    /// </summary>
    public int? OperateurSiteId { get; set; }

    public virtual ICollection<CodeBarreOperateur> CodeBarreOperateurs { get; set; } = new List<CodeBarreOperateur>();

    public virtual ICollection<EquipeOperateur> EquipeOperateurs { get; set; } = new List<EquipeOperateur>();

    public virtual Site? OperateurSite { get; set; }

    public virtual ICollection<ResultatInventaire> ResultatInventaires { get; set; } = new List<ResultatInventaire>();
}
