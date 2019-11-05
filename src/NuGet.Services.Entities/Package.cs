﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NuGet.Services.Entities
{
    [DisplayColumn("Title")]
    public class Package
        : IPackageEntity
    {

#pragma warning disable 618 // TODO: remove Package.Authors completely once production services definitely no longer need it
        public Package()
        {
            Authors = new HashSet<PackageAuthor>();
            Dependencies = new HashSet<PackageDependency>();
            PackageHistories = new HashSet<PackageHistory>();
            PackageTypes = new HashSet<PackageType>();
            SupportedFrameworks = new HashSet<PackageFramework>();
            SymbolPackages = new HashSet<SymbolPackage>();
            Deprecations = new HashSet<PackageDeprecation>();
            AlternativeOf = new HashSet<PackageDeprecation>();
            Vulnerabilities = new HashSet<VulnerablePackageVersionRange>();
            Listed = true;
        }
#pragma warning restore 618

        public PackageRegistration PackageRegistration { get; set; }
        public int PackageRegistrationKey { get; set; }

        [Obsolete("Will be removed in a future iteration, for now is write-only")]
        public virtual ICollection<PackageAuthor> Authors { get; set; }

        /// <remarks>
        ///     Has a max length of 4000. Is not indexed and not used for searches. Db column is nvarchar(max).
        /// </remarks>
        public string Copyright { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Created { get; set; }

        public virtual ICollection<PackageDependency> Dependencies { get; set; }

        public virtual ICollection<PackageType> PackageTypes { get; set; }

        /// <remarks>
        ///     Has a max length of 4000. Is not indexed but *IS* used for searches. Db column is nvarchar(max).
        /// </remarks>
        public string Description { get; set; }

        /// <remarks>
        ///     Has a max length of 4000. Is not indexed and not used for searches. Db column is nvarchar(max).
        /// </remarks>
        public string ReleaseNotes { get; set; }

        public int DownloadCount { get; set; }

        /// <remarks>
        ///     Is not a property that we support. Maintained for legacy reasons.
        /// </remarks>
        [Obsolete]
        public string ExternalPackageUrl { get; set; }

        [StringLength(10)]
        public string HashAlgorithm { get; set; }

        /// <summary>
        /// Stringified hashcode generated by hashing the nupkg file with HashAlgorithm.
        /// </summary>
        [StringLength(256)]
        [Required]
        public string Hash { get; set; }

        /// <remarks>
        ///     Has a max length of 4000. Is not indexed and not used for searches. Db column is nvarchar(max).
        /// </remarks>
        public string IconUrl { get; set; }

        public bool IsLatest { get; set; }
        public bool IsLatestStable { get; set; }

        public bool IsLatestSemVer2 { get; set; }
        public bool IsLatestStableSemVer2 { get; set; }

        /// <summary>
        /// This is when the Package Entity was last touched (so caches can notice changes). In UTC.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// This is when the Package Metadata was last edited by a user. Or NULL. In UTC.
        /// 
        /// This field is updated by a trigger on the database if it is edited.
        /// This trigger is defined by a migration named "AddTriggerForPackagesLastEdited".
        /// The trigger guarantees that the timestamps of multiple instances of the gallery do not conflict.
        /// </summary>
        public DateTime? LastEdited { get; set; }

        /// <remarks>
        ///     Has a max length of 4000. Is not indexed and not used for searches. Db column is nvarchar(max).
        /// </remarks>
        public string LicenseUrl { get; set; }

        public bool HideLicenseReport { get; set; }

        [StringLength(20)]
        public string Language { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Published { get; set; }

        /// <summary>The size of the nupkg file in bytes.</summary>
        public long PackageFileSize { get; set; }

        /// <remarks>
        ///     Has a max length of 4000. Is not indexed and not used for searches. Db column is nvarchar(max).
        /// </remarks>
        public string ProjectUrl { get; set; }

        /// <remarks>
        /// Has a max length of 4000. Is not indexed and not used for searches. Db column is nvarchar(max).
        /// </remarks>
        public string RepositoryUrl { get; set; }


        /// <remarks>
        /// Has a max length of 100. Is not indexed and not used for searches. Db column is nvarchar(100).
        /// </remarks>
        [StringLength(100)]
        public string RepositoryType { get; set; }

        /// <summary>
        /// Nullable flag stored in the database. Callers should use the HasReadMe property instead.
        /// </summary>
        [Column("HasReadMe")]
        public bool? HasReadMeInternal { get; set; }

        /// <summary>
        /// Signifies whether or not the ReadMe exists. Falses stored as NULL in database to avoid updating existing rows.
        /// </summary>
        [NotMapped]
        public bool HasReadMe
        {
            get
            {
                return HasReadMeInternal ?? false;
            }
            set
            {
                HasReadMeInternal = value ? (bool?)true : null;
            }
        }

        public bool RequiresLicenseAcceptance { get; set; }

        public bool DevelopmentDependency { get; set; }

        /// <remarks>
        ///     Has a max length of 4000. Is not indexed and not used for searches. Db column is nvarchar(max).
        /// </remarks>
        public string Summary { get; set; }

        /// <remarks>
        ///     Has a max length of 4000. Is not indexed and *IS* used for searches, but is maintained via Lucene. Db column is nvarchar(max).
        /// </remarks>
        public string Tags { get; set; }

        [StringLength(256)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the version listed in the manifest for this package, which MAY NOT conform to NuGet's use of SemVer
        /// </summary>
        [StringLength(Constants.MaxPackageVersionLength)]
        [Required]
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the version for this package that has been normalized to conform to NuGet's use of SemVer
        /// </summary>
        [StringLength(64)]
        public string NormalizedVersion { get; set; }

        /// <summary>
        /// Gets or sets the minimum required SemVer level for consumers of this package, 
        /// based on the Version property containing the original version string,
        /// or the dependency version ranges of this package.
        /// </summary>
        /// <remarks>
        /// If the field value is null, the SemVer level of this version is unknown,
        /// and could either indicate the package version is SemVer1- or non-SemVer-compliant at all (e.g. System.Versioning pattern).
        /// </remarks>
        public int? SemVerLevelKey { get; set; }

        public virtual ICollection<PackageLicenseReport> LicenseReports { get; set; }

        // Pre-calculated data for the feed
        public string LicenseNames { get; set; }
        public string LicenseReportUrl { get; set; }

        public bool Listed { get; set; }
        public bool IsPrerelease { get; set; }
        public virtual ICollection<PackageFramework> SupportedFrameworks { get; set; }

        public string FlattenedAuthors { get; set; }

        public string FlattenedDependencies { get; set; }

        public string FlattenedPackageTypes { get; set; }

        public int Key { get; set; }

        [StringLength(44)]
        public string MinClientVersion { get; set; }

        /// <summary>
        /// The user that uploaded this package or <c>null</c> if the user was deleted.
        /// </summary>
        /// <remarks>
        /// Packages uploaded before this field was added have <c>null</c>.
        /// </remarks>
        public User User { get; set; }
        public int? UserKey { get; set; }

        /// <summary>
        /// List of historical metadata info of this package (before edits were applied)
        /// </summary>
        public virtual ICollection<PackageHistory> PackageHistories { get; set; }

        [Obsolete]
        public bool Deleted { get; set; }

        /// <summary>
        /// The package status key, referring to the <see cref="PackageStatus"/> enum.
        /// </summary>
        public PackageStatus PackageStatusKey { get; set; }

        /// <summary>
        /// Gets or sets the foreign key of the certificate used to sign the package.
        /// </summary>
        public int? CertificateKey { get; set; }

        /// <summary>
        /// Gets or sets the certificate used to sign the package.
        /// </summary>
        public virtual Certificate Certificate { get; set; }

        public virtual ICollection<SymbolPackage> SymbolPackages { get; set; }

        public string Id => PackageRegistration.Id;

        public EmbeddedLicenseFileType EmbeddedLicenseType { get; set; }

        [StringLength(500)]
        public string LicenseExpression { get; set; }

        /// <summary>
        /// Gets and sets the deprecations associated with this package.
        /// </summary>
        /// <remarks>
        /// In the future, a package may have multiple deprecations associated with it, one visible and others hidden.
        /// The visible deprecation will be the deprecation shown in the UI to users.
        /// The hidden deprecations will consist of information about the package that we recommend package owners apply to their package.
        /// For now, we only support a single deprecation per package (the visible deprecation).
        /// </remarks>
        public virtual ICollection<PackageDeprecation> Deprecations { get; set; }

        /// <summary>
        /// Gets and sets the list of deprecations that recommend this package as an alternative.
        /// See <see cref="PackageDeprecation.AlternatePackage"/>.
        /// </summary>
        public virtual ICollection<PackageDeprecation> AlternativeOf { get; set; }

        /// <summary>
        /// Gets or sets the list of vulnerabilites that this package has.
        /// </summary>
        public ICollection<VulnerablePackageVersionRange> Vulnerabilities { get; set; }

        /// <summary>
        /// A flag that indicates that the package metadata had an embedded icon specified.
        /// </summary>
        public bool HasEmbeddedIcon { get; set; }
    }
}
