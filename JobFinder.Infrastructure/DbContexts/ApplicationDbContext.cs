using JobFinder.Application.Common.Extensions;
using JobFinder.Domain.Common;
using JobFinder.Domain.Entities;
using JobFinder.Infrastructure.Identity;
using JobFinder.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

namespace JobFinder.Infrastructure.DbContexts;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{

    private readonly ICurrentUser _currentUser;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUser currentUser) : base(options)
    {
        _currentUser = currentUser;
    }

    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<ApplicantLanguage> ApplicantLanguages { get; set; }
    public DbSet<ApplicantSkill> ApplicantSkills { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<CompanyGallery> CompanyGalleries { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<JobSkill> JobSkills { get; set; }
    public DbSet<JobLanguage> JobLanguages { get; set; }
    public DbSet<JobApplicant> JobApplicants { get; set; }
    public DbSet<JobApplicantAnswer> JobApplicantAnswers { get; set; }
    public DbSet<JobApplicantLifecycle> JobApplicantLifecycles { get; set; }
    public DbSet<JobAttachment> JobAttachments { get; set; }
    public DbSet<JobQuestion> JobQuestions { get; set; }
    public DbSet<JobQuestionAnswer> JobQuestionAnswers { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Reference> References { get; set; }
    public DbSet<Skill> Skills { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.AppendGlobalQueryFilter<IBaseEntity>(x => x.DeletedOn == null);

        base.OnModelCreating(builder);

        builder.Entity<ApplicationUser>(entity =>
        {
            entity.ToTable(name: "ApplicationUsers");
        });
        builder.Entity<Skill>().HasData(
            new Skill { Id = Guid.NewGuid(), Title = "Communication", IsActive = true },
            new Skill { Id = Guid.NewGuid(), Title = "Leadership", IsActive = true },
            new Skill { Id = Guid.NewGuid(), Title = "Technical", IsActive = true },
            new Skill { Id = Guid.NewGuid(), Title = "Problem Solving", IsActive = true },
            new Skill { Id = Guid.NewGuid(), Title = "Time Management", IsActive = true },
            new Skill { Id = Guid.NewGuid(), Title = "Teamwork", IsActive = true },
            new Skill { Id = Guid.NewGuid(), Title = "Adaptability", IsActive = true },
            new Skill { Id = Guid.NewGuid(), Title = "Creativity", IsActive = true },
            new Skill { Id = Guid.NewGuid(), Title = "Critical Thinking", IsActive = true },
            new Skill { Id = Guid.NewGuid(), Title = "Attention to Detail", IsActive = true },
            new Skill { Id = Guid.NewGuid(), Title = "Organizational", IsActive = true },
            new Skill { Id = Guid.NewGuid(), Title = "Analytical", IsActive = true },
            new Skill { Id = Guid.NewGuid(), Title = "Interpersonal", IsActive = true },
            new Skill { Id = Guid.NewGuid(), Title = "Project Management", IsActive = true },
            new Skill { Id = Guid.NewGuid(), Title = "Communication", IsActive = true });

        builder.Entity<Language>().HasData(
            new Language { Id = Guid.NewGuid(), Title = "Spanish", IsActive = true },
            new Language { Id = Guid.NewGuid(), Title = "English", IsActive = true },
            new Language { Id = Guid.NewGuid(), Title = "Hindi", IsActive = true },
            new Language { Id = Guid.NewGuid(), Title = "Arabic", IsActive = true },
            new Language { Id = Guid.NewGuid(), Title = "Bengali", IsActive = true },
            new Language { Id = Guid.NewGuid(), Title = "Portuguese", IsActive = true },
            new Language { Id = Guid.NewGuid(), Title = "Russian", IsActive = true },
            new Language { Id = Guid.NewGuid(), Title = "Japanese", IsActive = true },
            new Language { Id = Guid.NewGuid(), Title = "German", IsActive = true },
            new Language { Id = Guid.NewGuid(), Title = "French", IsActive = true },
            new Language { Id = Guid.NewGuid(), Title = "Korean", IsActive = true },
            new Language { Id = Guid.NewGuid(), Title = "Italian", IsActive = true },
            new Language { Id = Guid.NewGuid(), Title = "Turkish", IsActive = true });
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        DateTime nowDate = DateTime.Now;
        foreach (var entry in ChangeTracker.Entries<BaseEntity>().ToList())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedOn = nowDate;
                    entry.Entity.CreatedBy = _currentUser.UserId;
                    entry.Entity.CreatorName = _currentUser.Username;
                    break;

                case EntityState.Modified:
                    if (entry.Entity.DeleteName.HasValue())
                    {
                        entry.Entity.DeletedOn = nowDate;
                        entry.Entity.DeletedBy = _currentUser.UserId;
                        entry.Entity.DeleteName = _currentUser.Username;
                    }
                    else
                    {
                        entry.Entity.LastModifiedOn = nowDate;
                        entry.Entity.LastModifiedBy = _currentUser.UserId;
                        entry.Entity.ModifierName = _currentUser.Username;
                    }
                    break;
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}


internal static class ModelBuilderExtensions
{
    public static ModelBuilder AppendGlobalQueryFilter<TInterface>(this ModelBuilder modelBuilder, Expression<Func<TInterface, bool>> filter)
    {
        // get a list of entities without a baseType that implement the interface TInterface
        var entities = modelBuilder.Model.GetEntityTypes()
            .Where(e => e.BaseType is null && e.ClrType.GetInterface(typeof(TInterface).Name) is not null)
            .Select(e => e.ClrType);

        foreach (var entity in entities)
        {
            var parameterType = Expression.Parameter(modelBuilder.Entity(entity).Metadata.ClrType);
            var filterBody = ReplacingExpressionVisitor.Replace(filter.Parameters.Single(), parameterType, filter.Body);

            // get the existing query filter
            if (modelBuilder.Entity(entity).Metadata.GetQueryFilter() is { } existingFilter)
            {
                var existingFilterBody = ReplacingExpressionVisitor.Replace(existingFilter.Parameters.Single(), parameterType, existingFilter.Body);

                // combine the existing query filter with the new query filter
                filterBody = Expression.AndAlso(existingFilterBody, filterBody);
            }

            // apply the new query filter
            modelBuilder.Entity(entity).HasQueryFilter(Expression.Lambda(filterBody, parameterType));
        }

        return modelBuilder;
    }
}