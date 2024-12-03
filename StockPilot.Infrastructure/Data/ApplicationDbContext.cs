using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockPilot.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace StockPilot.Infrastructure.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        public virtual DbSet<Allée> Allées { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<CodeBarreAllée> CodeBarreAllées { get; set; }

        public virtual DbSet<CodeBarreEtage> CodeBarreEtages { get; set; }

        public virtual DbSet<CodeBarreOperateur> CodeBarreOperateurs { get; set; }

        public virtual DbSet<CodeBarreRack> CodeBarreRacks { get; set; }

        public virtual DbSet<CodeBarreRangée> CodeBarreRangées { get; set; }

        public virtual DbSet<CodeBarreZone> CodeBarreZones { get; set; }

        public virtual DbSet<Equipe> Equipes { get; set; }

        public virtual DbSet<EquipeOperateur> EquipeOperateurs { get; set; }

        public virtual DbSet<Etage> Etages { get; set; }

        public virtual DbSet<FormProduit> FormProduits { get; set; }

        public virtual DbSet<Inventaire> Inventaires { get; set; }

        public virtual DbSet<Operateur> Operateurs { get; set; }

        public virtual DbSet<OperationInventaire> OperationInventaires { get; set; }

        public virtual DbSet<Produit> Produits { get; set; }

        public virtual DbSet<Rack> Racks { get; set; }

        public virtual DbSet<Rangée> Rangées { get; set; }

        public virtual DbSet<Region> Regions { get; set; }

        public virtual DbSet<ResultatInventaire> ResultatInventaires { get; set; }

        public virtual DbSet<Site> Sites { get; set; }

        public virtual DbSet<Societé> Societés { get; set; }

        public virtual DbSet<Statut> Statuts { get; set; }

        public virtual DbSet<TypeInventaire> TypeInventaires { get; set; }

        public virtual DbSet<Ville> Villes { get; set; }

        public virtual DbSet<Zone> Zones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Allée>(entity =>
            {
                entity.HasKey(e => e.AlléeId).HasName("PK__Allée__58D55A03052B8413");

                entity.ToTable("Allée");

                entity.Property(e => e.AlléeId)
                    .HasComment("Identifiant unique pour chaque allée.")
                    .HasColumnName("Allée_Id");
                entity.Property(e => e.AlléeNom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Nom de l'allée")
                    .HasColumnName("Allée_Nom");
                entity.Property(e => e.AlléeZoneId)
                    .HasComment("Référence à l'identifiant de la zone à laquelle l'allée appartient. C'est une clé étrangère.")
                    .HasColumnName("Allée_ZoneId");

                entity.HasOne(d => d.AlléeZone).WithMany(p => p.Allées)
                    .HasForeignKey(d => d.AlléeZoneId)
                    .HasConstraintName("Allée_ZoneId");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.ClientId).HasName("PK__Client__BF554B6CE4B28D07");

                entity.ToTable("Client");

                entity.HasIndex(e => e.ClientEmail, "UQ__Client__A7A650D3FAE098F8").IsUnique();

                entity.Property(e => e.ClientId)
                    .HasComment("Identifiant unique pour chaque client")
                    .HasColumnName("client_Id");
                entity.Property(e => e.ClientAdress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Adresse physique du client")
                    .HasColumnName("client_Adress");
                entity.Property(e => e.ClientDateCreation)
                    .HasComment("Date de création du client dans le système")
                    .HasColumnName("client_DateCreation");
                entity.Property(e => e.ClientDateInactif)
                    .HasComment("Date à partir de laquelle le client est devenu inactif")
                    .HasColumnName("client_DateInactif");
                entity.Property(e => e.ClientEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Adresse e-mail du client")
                    .HasColumnName("client_Email");
                entity.Property(e => e.ClientIsActive)
                    .HasDefaultValue(true)
                    .HasComment("Indique si le client est actif (1 = actif, 0 = inactif)")
                    .HasColumnName("client_IsActive");
                entity.Property(e => e.ClientNom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Nom du client")
                    .HasColumnName("client_Nom");
                entity.Property(e => e.ClientPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Client_Password");
                entity.Property(e => e.ClientTelephone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasComment("Numéro de téléphone du client")
                    .HasColumnName("client_Telephone");
                entity.Property(e => e.ClientUsername)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Client_Username");
            });

            modelBuilder.Entity<CodeBarreAllée>(entity =>
            {
                entity.HasKey(e => e.CodeBarreAlléeId).HasName("PK__CodeBarr__3A7C90A2A4168A7F");

                entity.ToTable("CodeBarreAllée");

                entity.Property(e => e.CodeBarreAlléeId)
                    .HasComment("Identifiant unique pour chaque association entre un code-barres et une allée.")
                    .HasColumnName("CodeBarreAllée_Id");
                entity.Property(e => e.CodeBarreAlléeAlléeId)
                    .HasComment("Référence à l'identifiant de l'allée avec ce code-barres est situé. C'est une clé étrangère.")
                    .HasColumnName("CodeBarreAllée_AlléeId");

                entity.HasOne(d => d.CodeBarreAlléeAllée).WithMany(p => p.CodeBarreAllées)
                    .HasForeignKey(d => d.CodeBarreAlléeAlléeId)
                    .HasConstraintName("CodeBarreAllée_AlléeId");
            });

            modelBuilder.Entity<CodeBarreEtage>(entity =>
            {
                entity.HasKey(e => e.CodeBarreEtageId).HasName("PK__CodeBarr__EC532EC1B8307F25");

                entity.ToTable("CodeBarreEtage");

                entity.Property(e => e.CodeBarreEtageId)
                    .HasComment("Identifiant unique pour chaque association entre un code-barres et un étage.")
                    .HasColumnName("CodeBarreEtage_Id");
                entity.Property(e => e.CodeBarreEtageEtageId)
                    .HasComment("Référence à l'identifiant de l'étage avec ce code-barres est situé. C'est une clé étrangère.")
                    .HasColumnName("CodeBarreEtage_EtageId");

                entity.HasOne(d => d.CodeBarreEtageEtage).WithMany(p => p.CodeBarreEtages)
                    .HasForeignKey(d => d.CodeBarreEtageEtageId)
                    .HasConstraintName("CodeBarreEtage_EtageId");
            });

            modelBuilder.Entity<CodeBarreOperateur>(entity =>
            {
                entity.HasKey(e => e.CodeBarreOperateurId).HasName("PK__CodeBarr__9C140E7C2F7FFFC2");

                entity.ToTable("CodeBarreOperateur");

                entity.Property(e => e.CodeBarreOperateurId)
                    .HasComment("Identifiant unique pour chaque association entre un opérateur et un code-barres.")
                    .HasColumnName("CodeBarreOperateur_Id");
                entity.Property(e => e.CodeBarreOperateurOperateurId)
                    .HasComment("Référence à l'identifiant de l'opérateur, lié à la table Operateur.")
                    .HasColumnName("CodeBarreOperateur_OperateurId");

                entity.HasOne(d => d.CodeBarreOperateurOperateur).WithMany(p => p.CodeBarreOperateurs)
                    .HasForeignKey(d => d.CodeBarreOperateurOperateurId)
                    .HasConstraintName("CodeBarreOperateur_OperateurId");
            });

            modelBuilder.Entity<CodeBarreRack>(entity =>
            {
                entity.HasKey(e => e.CodeBarreRackId).HasName("PK__CodeBarr__4A88C0C48D7878BA");

                entity.ToTable("CodeBarreRack");

                entity.Property(e => e.CodeBarreRackId)
                    .HasComment("Identifiant unique pour chaque association entre un code-barres et un rack.")
                    .HasColumnName("CodeBarreRack_Id");
                entity.Property(e => e.CodeBarreRackRackId)
                    .HasComment("Référence à l'identifiant du rack avec ce code-barres est situé. C'est une clé étrangère.")
                    .HasColumnName("CodeBarreRack_RackId");

                entity.HasOne(d => d.CodeBarreRackRack).WithMany(p => p.CodeBarreRacks)
                    .HasForeignKey(d => d.CodeBarreRackRackId)
                    .HasConstraintName("CodeBarreRack_RackId");
            });

            modelBuilder.Entity<CodeBarreRangée>(entity =>
            {
                entity.HasKey(e => e.CodeBarreRangéeId).HasName("PK__CodeBarr__47535DFE57D2BBF1");

                entity.ToTable("CodeBarreRangée");

                entity.Property(e => e.CodeBarreRangéeId)
                    .HasComment("Identifiant unique pour chaque association entre un code-barres et une rangée.")
                    .HasColumnName("CodeBarreRangée_Id");
                entity.Property(e => e.CodeBarreRangéeRangéeId)
                    .HasComment("Référence à l'identifiant de la rangée avec ce code-barres est situé. C'est une clé étrangère.")
                    .HasColumnName("CodeBarreRangée_RangéeId");

                entity.HasOne(d => d.CodeBarreRangéeRangée).WithMany(p => p.CodeBarreRangées)
                    .HasForeignKey(d => d.CodeBarreRangéeRangéeId)
                    .HasConstraintName("CodeBarreRangée_RangéeId");
            });

            modelBuilder.Entity<CodeBarreZone>(entity =>
            {
                entity.HasKey(e => e.CodeBarreZoneId).HasName("PK__CodeBarr__F046EBC6C1681EC7");

                entity.ToTable("CodeBarreZone");

                entity.Property(e => e.CodeBarreZoneId)
                    .HasComment("Identifiant unique pour chaque association entre un code-barres et une zone.")
                    .HasColumnName("CodeBarreZone_Id");
                entity.Property(e => e.CodeBarreZoneZoneId)
                    .HasComment("Référence à l'identifiant de la zone avec ce code-barres est situé. C'est une clé étrangère.")
                    .HasColumnName("CodeBarreZone_ZoneId");

                entity.HasOne(d => d.CodeBarreZoneZone).WithMany(p => p.CodeBarreZones)
                    .HasForeignKey(d => d.CodeBarreZoneZoneId)
                    .HasConstraintName("CodeBarreZone_ZoneId");
            });

            modelBuilder.Entity<Equipe>(entity =>
            {
                entity.HasKey(e => e.EquipeId).HasName("PK__Equipe__C93C5DE8C09622F5");

                entity.ToTable("Equipe");

                entity.Property(e => e.EquipeId)
                    .HasComment("Identifiant unique pour chaque équipe.")
                    .HasColumnName("Equipe_Id");
                entity.Property(e => e.EquipeInventaireId)
                    .HasComment("Référence à l'identifiant de l'inventaire associé à cette équipe. C'est une clé étrangère qui fait référence à la table Inventaire.")
                    .HasColumnName("Equipe_InventaireId");

                entity.HasOne(d => d.EquipeInventaire).WithMany(p => p.Equipes)
                    .HasForeignKey(d => d.EquipeInventaireId)
                    .HasConstraintName("Equipe_InventaireId");
            });

            modelBuilder.Entity<EquipeOperateur>(entity =>
            {
                entity.HasKey(e => e.EquipeOperateurId).HasName("PK__EquipeOp__CD3D157BD1E82B84");

                entity.ToTable("EquipeOperateur");

                entity.Property(e => e.EquipeOperateurId)
                    .HasComment("Identifiant unique pour chaque enregistrement dans la relation équipe-opérateur.")
                    .HasColumnName("EquipeOperateur_Id");
                entity.Property(e => e.EquipeOperateurEquipeId)
                    .HasComment("Référence à l'identifiant de l'équipe dans laquelle l'opérateur est affecté. C'est une clé étrangère qui fait référence à la table Equipe.")
                    .HasColumnName("EquipeOperateur_EquipeId");
                entity.Property(e => e.EquipeOperateurOperateurId)
                    .HasComment("Référence à l'identifiant de l'opérateur affecté à l'équipe. C'est une clé étrangère qui fait référence à la table Operateur.")
                    .HasColumnName("EquipeOperateur_OperateurId");

                entity.HasOne(d => d.EquipeOperateurEquipe).WithMany(p => p.EquipeOperateurs)
                    .HasForeignKey(d => d.EquipeOperateurEquipeId)
                    .HasConstraintName("EquipeOperateur_EquipeId");

                entity.HasOne(d => d.EquipeOperateurOperateur).WithMany(p => p.EquipeOperateurs)
                    .HasForeignKey(d => d.EquipeOperateurOperateurId)
                    .HasConstraintName("EquipeOperateur_OperateurId");
            });

            modelBuilder.Entity<Etage>(entity =>
            {
                entity.HasKey(e => e.EtageId).HasName("PK__Etage__0F13A9CBE9AFC812");

                entity.ToTable("Etage");

                entity.Property(e => e.EtageId)
                    .HasComment("Identifiant unique pour chaque étage")
                    .HasColumnName("Etage_Id");
                entity.Property(e => e.EtageNom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Nom de l'étage")
                    .HasColumnName("Etage_Nom");
                entity.Property(e => e.EtageRangéeId)
                    .HasComment("Référence à l'identifiant de la rangée dans laquelle l'étage est situé. C'est une clé étrangère.")
                    .HasColumnName("Etage_RangéeId");

                entity.HasOne(d => d.EtageRangée).WithMany(p => p.Etages)
                    .HasForeignKey(d => d.EtageRangéeId)
                    .HasConstraintName("Etage_RangéeId");
            });

            modelBuilder.Entity<FormProduit>(entity =>
            {
                entity.HasKey(e => e.FormProduitId).HasName("PK__FormProd__277478DA1E43E773");

                entity.ToTable("FormProduit");

                entity.Property(e => e.FormProduitId)
                    .HasComment("Identifiant unique pour chaque forme de produit")
                    .HasColumnName("FormProduit_Id");
                entity.Property(e => e.FormProduitCodeBarre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Code-barres unique pour identifier cette forme spécifique du produit.")
                    .HasColumnName("FormProduit_CodeBarre");
                entity.Property(e => e.FormProduitProduitId)
                    .HasComment("Référence à l'identifiant du produit parent. C'est une clé étrangère.")
                    .HasColumnName("FormProduit_ProduitId");
                entity.Property(e => e.FormProduitQuantite)
                    .HasComment("Quantité disponible de cette forme du produit.")
                    .HasColumnName("FormProduit_Quantite");

                entity.HasOne(d => d.FormProduitProduit).WithMany(p => p.FormProduits)
                    .HasForeignKey(d => d.FormProduitProduitId)
                    .HasConstraintName("FormProduit_ProduitId");
            });

            modelBuilder.Entity<Inventaire>(entity =>
            {
                entity.HasKey(e => e.InventaireId).HasName("PK__Inventai__4645A98DF52C4799");

                entity.ToTable("Inventaire");

                entity.Property(e => e.InventaireId)
                    .HasComment("Identifiant unique pour chaque inventaire.")
                    .HasColumnName("Inventaire_Id");
                entity.Property(e => e.InventaireDate)
                    .HasComment("Date de l'inventaire.")
                    .HasColumnName("Inventaire_Date");
                entity.Property(e => e.InventaireIsTotal)
                    .HasComment("Indicateur qui spécifie si l'inventaire est total (1) ou partiel (0).")
                    .HasColumnName("Inventaire_IsTotal");
                entity.Property(e => e.InventaireLibelle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Libellé ou nom de l'inventaire")
                    .HasColumnName("Inventaire_libelle");
                entity.Property(e => e.InventaireSiteId)
                    .HasComment("Référence au site où l'inventaire est effectué, lié à l'identifiant du site dans la table Site.")
                    .HasColumnName("Inventaire_SiteId");
                entity.Property(e => e.InventaireStatutId)
                    .HasComment("Référence au statut de l'inventaire, lié à l'identifiant du statut dans la table Statut.")
                    .HasColumnName("Inventaire_StatutId");
                entity.Property(e => e.InventaireTypeInventaireId)
                    .HasComment("Référence au type d'inventaire, lié à l'identifiant du type dans la table TypeInventaire.")
                    .HasColumnName("Inventaire_TypeInventaireId");

                entity.HasOne(d => d.InventaireSite).WithMany(p => p.Inventaires)
                    .HasForeignKey(d => d.InventaireSiteId)
                    .HasConstraintName("Inventaire_SiteId");

                entity.HasOne(d => d.InventaireStatut).WithMany(p => p.Inventaires)
                    .HasForeignKey(d => d.InventaireStatutId)
                    .HasConstraintName("Inventaire_StatutId");

                entity.HasOne(d => d.InventaireTypeInventaire).WithMany(p => p.Inventaires)
                    .HasForeignKey(d => d.InventaireTypeInventaireId)
                    .HasConstraintName("Inventaire_TypeInventaireId");
            });

            modelBuilder.Entity<Operateur>(entity =>
            {
                entity.HasKey(e => e.OperateurId).HasName("PK__Operateu__DD6FAFB1471872AD");

                entity.ToTable("Operateur");

                entity.Property(e => e.OperateurId)
                    .HasComment("Identifiant unique pour chaque opérateur.")
                    .HasColumnName("Operateur_Id");
                entity.Property(e => e.OperateurCin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Numéro de carte d'identité nationale de l'opérateur.")
                    .HasColumnName("Operateur_Cin");
                entity.Property(e => e.OperateurNom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Nom de l'opérateur.")
                    .HasColumnName("Operateur_Nom");
                entity.Property(e => e.OperateurPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Mot de passe pour se connecter au système.")
                    .HasColumnName("Operateur_Password");
                entity.Property(e => e.OperateurPrenom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Prénom de l'opérateur.")
                    .HasColumnName("Operateur_Prenom");
                entity.Property(e => e.OperateurSiteId)
                    .HasComment("Référence à l'identifiant du site où l'opérateur travaille. C'est une clé étrangère qui fait référence à la table Site.")
                    .HasColumnName("Operateur_SiteId");
                entity.Property(e => e.OperateurUsername)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Nom d'utilisateur pour se connecter au système.")
                    .HasColumnName("Operateur_Username");

                entity.HasOne(d => d.OperateurSite).WithMany(p => p.Operateurs)
                    .HasForeignKey(d => d.OperateurSiteId)
                    .HasConstraintName("Operateur_SiteId");
            });

            modelBuilder.Entity<OperationInventaire>(entity =>
            {
                entity.HasKey(e => e.OperationInventaireId).HasName("PK__Operatio__18B7EDD044030108");

                entity.ToTable("OperationInventaire");

                entity.Property(e => e.OperationInventaireId)
                    .HasComment("Identifiant unique pour chaque opération d'inventaire. ")
                    .HasColumnName("OperationInventaire_Id");
                entity.Property(e => e.OperationInventaireInventaireId)
                    .HasComment("Référence à l'identifiant de l'inventaire auquel cette opération appartient. C'est une clé étrangère qui fait référence à la table Inventaire.")
                    .HasColumnName("OperationInventaire_InventaireId");
                entity.Property(e => e.OperationInventaireZoneId)
                    .HasComment("Référence à l'identifiant de la zone dans laquelle l'opération d'inventaire est réalisée. C'est une clé étrangère qui fait référence à la table Zone.")
                    .HasColumnName("OperationInventaire_ZoneId");

                entity.HasOne(d => d.OperationInventaireInventaire).WithMany(p => p.OperationInventaires)
                    .HasForeignKey(d => d.OperationInventaireInventaireId)
                    .HasConstraintName("OperationInventaire_InventaireId");

                entity.HasOne(d => d.OperationInventaireZone).WithMany(p => p.OperationInventaires)
                    .HasForeignKey(d => d.OperationInventaireZoneId)
                    .HasConstraintName("OperationInventaire_ZoneId");
            });

            modelBuilder.Entity<Produit>(entity =>
            {
                entity.HasKey(e => e.ProduitId).HasName("PK__Produit__DBDF7B2C20682064");

                entity.ToTable("Produit");

                entity.Property(e => e.ProduitId)
                    .HasComment("Identifiant unique pour chaque produit.")
                    .HasColumnName("Produit_Id");
                entity.Property(e => e.ProduitEtageId)
                    .HasComment("Référence à l'identifiant de l'étage où le produit est stocké. C'est une clé étrangère.")
                    .HasColumnName("Produit_EtageId");
                entity.Property(e => e.ProduitLibelle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Libellé ou nom du produit.")
                    .HasColumnName("Produit_Libelle");
                entity.Property(e => e.ProduitPrix)
                    .HasComment("Prix du produit.")
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Produit_Prix");

                entity.HasOne(d => d.ProduitEtage).WithMany(p => p.Produits)
                    .HasForeignKey(d => d.ProduitEtageId)
                    .HasConstraintName("Produit_EtageId");
            });

            modelBuilder.Entity<Rack>(entity =>
            {
                entity.HasKey(e => e.RackId).HasName("PK__Rack__3B72075B69B2E97F");

                entity.ToTable("Rack");

                entity.Property(e => e.RackId)
                    .HasComment("Identifiant unique pour chaque rack")
                    .HasColumnName("Rack_Id");
                entity.Property(e => e.RackAlléeId)
                    .HasComment("Référence à l'identifiant de l'allée dans laquelle le rack est situé. C'est une clé étrangère.")
                    .HasColumnName("Rack_AlléeId");
                entity.Property(e => e.RackNom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Nom du rack")
                    .HasColumnName("Rack_Nom");

                entity.HasOne(d => d.RackAllée).WithMany(p => p.Racks)
                    .HasForeignKey(d => d.RackAlléeId)
                    .HasConstraintName("Rack_AlléeId");
            });

            modelBuilder.Entity<Rangée>(entity =>
            {
                entity.HasKey(e => e.RangéeId).HasName("PK__Rangée__13CD194487C697CF");

                entity.ToTable("Rangée");

                entity.Property(e => e.RangéeId)
                    .HasComment("Identifiant unique pour chaque rangée")
                    .HasColumnName("Rangée_Id");
                entity.Property(e => e.RangéeNom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Nom de la rangée")
                    .HasColumnName("Rangée_Nom");
                entity.Property(e => e.RangéeRackId)
                    .HasComment("Référence à l'identifiant du rack dans lequel la rangée est située. C'est une clé étrangère")
                    .HasColumnName("Rangée_RackId");

                entity.HasOne(d => d.RangéeRack).WithMany(p => p.Rangées)
                    .HasForeignKey(d => d.RangéeRackId)
                    .HasConstraintName("Rangée_RackId");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.RegionId).HasName("PK__Region__A9EAD4FFE34950BA");

                entity.ToTable("Region");

                entity.Property(e => e.RegionId)
                    .HasComment("Identifiant unique pour chaque région. C'est la clé primaire.")
                    .HasColumnName("Region_Id");
                entity.Property(e => e.RegionNom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Nom de la région.")
                    .HasColumnName("Region_Nom");
            });

            modelBuilder.Entity<ResultatInventaire>(entity =>
            {
                entity.HasKey(e => e.ResultatInventaireId).HasName("PK__Resultat__AABC56D849C78C73");

                entity.ToTable("ResultatInventaire");

                entity.Property(e => e.ResultatInventaireId)
                    .HasComment("Identifiant unique pour chaque enregistrement de résultat d'inventaire.")
                    .HasColumnName("ResultatInventaire_Id");
                entity.Property(e => e.ResultatInventaireEquipeId)
                    .HasComment("Référence à l'identifiant de l'équipe responsable de l'inventaire, liée à la table Equipe.")
                    .HasColumnName("ResultatInventaire_EquipeId");
                entity.Property(e => e.ResultatInventaireFormProduitId)
                    .HasComment("Référence à l'identifiant du produit formulé, lié à la table FormProduit.")
                    .HasColumnName("ResultatInventaire_FormProduitId");
                entity.Property(e => e.ResultatInventaireInventaireId)
                    .HasComment("Référence à l'identifiant de l'inventaire, liée à la table Inventaire.")
                    .HasColumnName("ResultatInventaire_InventaireId");
                entity.Property(e => e.ResultatInventaireOperateurId)
                    .HasComment("Référence à l'identifiant de l'opérateur qui a participé à l'inventaire, liée à la table Operateur.")
                    .HasColumnName("ResultatInventaire_OperateurId");

                entity.HasOne(d => d.ResultatInventaireEquipe).WithMany(p => p.ResultatInventaires)
                    .HasForeignKey(d => d.ResultatInventaireEquipeId)
                    .HasConstraintName("ResultatInventaire_EquipeId");

                entity.HasOne(d => d.ResultatInventaireFormProduit).WithMany(p => p.ResultatInventaires)
                    .HasForeignKey(d => d.ResultatInventaireFormProduitId)
                    .HasConstraintName("ResultatInventaire_FormProduitId");

                entity.HasOne(d => d.ResultatInventaireInventaire).WithMany(p => p.ResultatInventaires)
                    .HasForeignKey(d => d.ResultatInventaireInventaireId)
                    .HasConstraintName("ResultatInventaire_InventaireId");

                entity.HasOne(d => d.ResultatInventaireOperateur).WithMany(p => p.ResultatInventaires)
                    .HasForeignKey(d => d.ResultatInventaireOperateurId)
                    .HasConstraintName("ResultatInventaire_OperateurId");
            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.HasKey(e => e.SiteId).HasName("PK__Site__E422232E1CD135AA");

                entity.ToTable("Site");

                entity.HasIndex(e => e.SiteAdress, "UQ__Site__442E7CDE2D3D21D9").IsUnique();

                entity.Property(e => e.SiteId)
                    .HasComment(" Identifiant unique du site")
                    .HasColumnName("Site_Id");
                entity.Property(e => e.SiteAdress)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Adresse physique du site")
                    .HasColumnName("Site_Adress");
                entity.Property(e => e.SiteNom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Nom du site")
                    .HasColumnName("Site_Nom");
                entity.Property(e => e.SiteSocieteId)
                    .HasComment("Identifiant de la société propriétaire du site")
                    .HasColumnName("Site_SocieteId");
                entity.Property(e => e.SiteVilleId)
                    .HasComment("Clé étrangère qui fait référence à Ville_Id dans la table Ville, indiquant la ville où se trouve le site.")
                    .HasColumnName("Site_VilleId");

                entity.HasOne(d => d.SiteSociete).WithMany(p => p.Sites)
                    .HasForeignKey(d => d.SiteSocieteId)
                    .HasConstraintName("Site_SocieteId");

                entity.HasOne(d => d.SiteVille).WithMany(p => p.Sites)
                    .HasForeignKey(d => d.SiteVilleId)
                    .HasConstraintName("Site_VilleId");
            });

            modelBuilder.Entity<Societé>(entity =>
            {
                entity.HasKey(e => e.SocietéId).HasName("PK__Societé__04358C9F3CFB2E8D");

                entity.ToTable("Societé");

                entity.HasIndex(e => e.SocietéAdress, "UQ__Societé__E5F76C6DFED7C7AE").IsUnique();

                entity.Property(e => e.SocietéId)
                    .HasComment("Identifiant unique de la société")
                    .HasColumnName("Societé_Id");
                entity.Property(e => e.SocietéAdress)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Adresse de la société")
                    .HasColumnName("Societé_Adress");
                entity.Property(e => e.SocietéClientId)
                    .HasComment("Clé étrangère qui fait référence à client_ID dans la table Client, indiquant le client associé à la société.")
                    .HasColumnName("Societé_ClientId");
                entity.Property(e => e.SocietéIf)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Numéro d'identification fiscale de la société")
                    .HasColumnName("Societé_If");
                entity.Property(e => e.SocietéRs)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Raison sociale ou nom de la société")
                    .HasColumnName("Societé_Rs");
                entity.Property(e => e.SocietéTelephone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasComment("Numéro de téléphone de la société")
                    .HasColumnName("Societé_Telephone");
                entity.Property(e => e.SocietéVilleId)
                    .HasComment("Clé étrangère qui fait référence à la table Ville (par exemple, pour stocker l'ID de la ville où se trouve la société).")
                    .HasColumnName("Societé_VilleId");

                entity.HasOne(d => d.SocietéClient).WithMany(p => p.Societés)
                    .HasForeignKey(d => d.SocietéClientId)
                    .HasConstraintName("Societé_ClientId");

                entity.HasOne(d => d.SocietéVille).WithMany(p => p.Societés)
                    .HasForeignKey(d => d.SocietéVilleId)
                    .HasConstraintName("Societé_VilleId");
            });

            modelBuilder.Entity<Statut>(entity =>
            {
                entity.HasKey(e => e.StatutId).HasName("PK__Statut__C9A2F59F5987DD15");

                entity.ToTable("Statut");

                entity.Property(e => e.StatutId)
                    .HasComment("Identifiant unique pour chaque statut.")
                    .HasColumnName("Statut_Id");
                entity.Property(e => e.StatutNom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Nom du statut")
                    .HasColumnName("Statut_Nom");
            });

            modelBuilder.Entity<TypeInventaire>(entity =>
            {
                entity.HasKey(e => e.TypeInventaireId).HasName("PK__TypeInve__03EB729C10902F8A");

                entity.ToTable("TypeInventaire");

                entity.Property(e => e.TypeInventaireId)
                    .HasComment("Identifiant unique pour chaque type d'inventaire.")
                    .HasColumnName("TypeInventaire_Id");
                entity.Property(e => e.TypeInventaireLibelle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Libellé du type d'inventaire (ex: \"Inventaire simple\", \"Inventaire double avec arbitrage\".).")
                    .HasColumnName("TypeInventaire_libelle");
            });

            modelBuilder.Entity<Ville>(entity =>
            {
                entity.HasKey(e => e.VilleId).HasName("PK__Ville__5A0D204B8CEEE4A5");

                entity.ToTable("Ville");

                entity.Property(e => e.VilleId)
                    .HasComment("Identifiant unique pour chaque ville")
                    .HasColumnName("Ville_Id");
                entity.Property(e => e.VilleNom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Nom de la ville")
                    .HasColumnName("Ville_Nom");
                entity.Property(e => e.VilleRegionId)
                    .HasComment("Référence à l'identifiant de la région à laquelle appartient la ville.")
                    .HasColumnName("Ville_RegionId");

                entity.HasOne(d => d.VilleRegion).WithMany(p => p.Villes)
                    .HasForeignKey(d => d.VilleRegionId)
                    .HasConstraintName("Ville_RegionId");
            });

            modelBuilder.Entity<Zone>(entity =>
            {
                entity.HasKey(e => e.ZoneId).HasName("PK__Zone__B4610C9EE22380FB");

                entity.ToTable("Zone");

                entity.Property(e => e.ZoneId)
                    .HasComment("Identifiant unique pour chaque zone.")
                    .HasColumnName("Zone_Id");
                entity.Property(e => e.ZoneNom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Nom de la zone.")
                    .HasColumnName("Zone_Nom");
                entity.Property(e => e.ZoneSiteId)
                    .HasComment("Référence à l'identifiant du site auquel appartient la zone. C'est une clé étrangère.")
                    .HasColumnName("Zone_SiteId");

                entity.HasOne(d => d.ZoneSite).WithMany(p => p.Zones)
                    .HasForeignKey(d => d.ZoneSiteId)
                    .HasConstraintName("Zone_SiteId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
