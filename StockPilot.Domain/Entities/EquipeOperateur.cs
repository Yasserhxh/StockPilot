using System;
using System.Collections.Generic;

namespace StockPilot.Domain.Entities;

public partial class EquipeOperateur
{
    /// <summary>
    /// Identifiant unique pour chaque enregistrement dans la relation équipe-opérateur.
    /// </summary>
    public int EquipeOperateurId { get; set; }

    /// <summary>
    /// Référence à l&apos;identifiant de l&apos;équipe dans laquelle l&apos;opérateur est affecté. C&apos;est une clé étrangère qui fait référence à la table Equipe.
    /// </summary>
    public int? EquipeOperateurEquipeId { get; set; }

    /// <summary>
    /// Référence à l&apos;identifiant de l&apos;opérateur affecté à l&apos;équipe. C&apos;est une clé étrangère qui fait référence à la table Operateur.
    /// </summary>
    public int? EquipeOperateurOperateurId { get; set; }

    public virtual Equipe? EquipeOperateurEquipe { get; set; }

    public virtual Operateur? EquipeOperateurOperateur { get; set; }
}
