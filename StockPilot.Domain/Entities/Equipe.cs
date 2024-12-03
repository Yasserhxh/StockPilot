using System;
using System.Collections.Generic;

namespace StockPilot.Domain.Entities;

public partial class Equipe
{
    /// <summary>
    /// Identifiant unique pour chaque équipe.
    /// </summary>
    public int EquipeId { get; set; }

    /// <summary>
    /// Référence à l&apos;identifiant de l&apos;inventaire associé à cette équipe. C&apos;est une clé étrangère qui fait référence à la table Inventaire.
    /// </summary>
    public int? EquipeInventaireId { get; set; }

    public virtual Inventaire? EquipeInventaire { get; set; }

    public virtual ICollection<EquipeOperateur> EquipeOperateurs { get; set; } = new List<EquipeOperateur>();

    public virtual ICollection<ResultatInventaire> ResultatInventaires { get; set; } = new List<ResultatInventaire>();
}
