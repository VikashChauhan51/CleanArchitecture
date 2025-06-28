// <copyright file="Repository.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

using System.Linq.Expressions;
using CleanArchitecture.Abstractions.Repositories.Core;
using CleanArchitecture.Domain.Core;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ResultifyCore;

namespace CleanArchitecture.Infrastructure.Repositories.Core;

/// <summary>
/// Base repository implementation for common data access operations.
/// </summary>
/// <typeparam name="TEntity">The entity type.</typeparam>
/// <typeparam name="TKey">The type of the entity's key.</typeparam>
public abstract class Repository<TEntity, TKey> : IRepositoryAsync<TEntity, TKey>
    where TEntity : class, IEntity
    where TKey : notnull
{
    protected readonly ApplicationDbContext Context;

    /// <summary>
    /// Initializes a new instance of the <see cref="Repository{TEntity, TKey}"/> class.
    /// </summary>
    /// <param name="context"></param>
    protected Repository(ApplicationDbContext context)
    {
        this.Context = context;
    }

    /// <inheritdoc />
    public void Add(TEntity entity)
    {
        Guard.ThrowIfArgumentIsNull(entity);
        this.Context.Add(entity);
        this.Context.SaveChanges();
    }

    /// <inheritdoc />
    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        Guard.ThrowIfArgumentIsNull(entity);
        await this.Context.AddAsync(entity, cancellationToken).ConfigureAwait(false);
        await this.Context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public void AddRange(IEnumerable<TEntity> entities)
    {
        Guard.ThrowIfArgumentIsNull(entities);
        Guard.ThrowIfArgumentIsEmpty(entities, nameof(entities), "Entities is a empty collection.");
        this.Context.AddRange(entities);
        this.Context.SaveChanges(true);
    }

    /// <inheritdoc />
    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        Guard.ThrowIfArgumentIsNull(entities);
        Guard.ThrowIfArgumentIsEmpty(entities, nameof(entities), "Entities is a empty collection.");
        await this.Context.AddRangeAsync(entities, cancellationToken).ConfigureAwait(false);
        await this.Context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public void Delete(TKey id)
    {
        Guard.ThrowIfArgumentIsNull(id);
        var entity = this.Context.Find<TEntity>(id);
        Guard.ThrowIfArgumentIsNull(entity);
        this.Delete(entity!);
    }

    /// <inheritdoc />
    public void Delete(TEntity entity)
    {
        Guard.ThrowIfArgumentIsNull(entity);
        this.Context.Remove(entity);
        this.Context.SaveChanges();
    }

    /// <inheritdoc />
    public async Task DeleteAsync(TKey id, CancellationToken cancellationToken)
    {
        Guard.ThrowIfArgumentIsNull(id);
        var entity = await this.Context.FindAsync<TEntity>(id).ConfigureAwait(false);
        Guard.ThrowIfArgumentIsNull(entity);
        await this.DeleteAsync(entity!, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
    {
        Guard.ThrowIfArgumentIsNull(entity);
        this.Context.Remove(entity);
        await this.Context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        Guard.ThrowIfArgumentIsNull(entities);
        Guard.ThrowIfArgumentIsEmpty(entities, nameof(entities), "Entities is a empty collection.");
        this.Context.RemoveRange(entities);
        this.Context.SaveChanges(true);
    }

    /// <inheritdoc />
    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        Guard.ThrowIfArgumentIsNull(predicate);
        return this.Context.Set<TEntity>().Where(predicate).ToList();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        Guard.ThrowIfArgumentIsNull(predicate);
        return await this.Context.Set<TEntity>().Where(predicate).ToListAsync().ConfigureAwait(false);
    }

    /// <inheritdoc />
    public IEnumerable<TEntity> GetAll()
    {
        return this.Context.Set<TEntity>().AsNoTracking().ToList();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await this.Context.Set<TEntity>().ToListAsync().ConfigureAwait(false);
    }

    /// <inheritdoc />
    public TEntity? GetById(TKey id)
    {
        Guard.ThrowIfArgumentIsNull(id);
        return this.Context.Set<TEntity>().Find(id);
    }

    /// <inheritdoc />
    public async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken)
    {
        Guard.ThrowIfArgumentIsNull(id);
        return await this.Context.Set<TEntity>().FindAsync(id).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public PaginatedResult<TEntity> GetPagedList(int pageSize, int pageNumber)
    {
        Guard.ThrowIfArgumentIsNegativeOrZero(pageSize);
        Guard.ThrowIfArgumentIsNegativeOrZero(pageNumber);
        var query = this.Context.Set<TEntity>().AsQueryable();
        var totalItemCount = query.Count();
        var pageCount = (long)Math.Ceiling((double)totalItemCount / pageSize);
        var entities = query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return new PaginatedResult<TEntity>(
           Count: entities.Count,
           PageNumber: pageNumber,
           PageSize: pageSize,
           PageCount: pageCount,
           TotalItemCount: totalItemCount,
           HasPreviousPage: pageNumber > 1,
           HasNextPage: pageNumber < pageCount,
           IsFirstPage: pageNumber == 1,
           IsLastPage: pageNumber >= pageCount,
           Entities: entities);
    }

    /// <inheritdoc />
    public async Task<PaginatedResult<TEntity>> GetPagedListAsync(int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        Guard.ThrowIfArgumentIsNegativeOrZero(pageSize);
        Guard.ThrowIfArgumentIsNegativeOrZero(pageNumber);
        var query = this.Context.Set<TEntity>().AsQueryable();
        var totalItemCount = await query.CountAsync(cancellationToken).ConfigureAwait(false);
        var pageCount = (long)Math.Ceiling((double)totalItemCount / pageSize);
        var entities = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);

        return new PaginatedResult<TEntity>(
           Count: entities.Count,
           PageNumber: pageNumber,
           PageSize: pageSize,
           PageCount: pageCount,
           TotalItemCount: totalItemCount,
           HasPreviousPage: pageNumber > 1,
           HasNextPage: pageNumber < pageCount,
           IsFirstPage: pageNumber == 1,
           IsLastPage: pageNumber >= pageCount,
           Entities: entities);
    }

    /// <inheritdoc />
    public IQueryable<TEntity> GetQueryable()
    {
        return this.Context.Set<TEntity>().AsQueryable();
    }

    /// <inheritdoc />
    public void Update(TEntity entity)
    {
        Guard.ThrowIfArgumentIsNull(entity);
        this.Context.Update(entity);
        this.Context.SaveChanges(true);
    }

    /// <inheritdoc />
    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        Guard.ThrowIfArgumentIsNull(entity);
        this.Context.Update(entity);
        await this.Context.SaveChangesAsync(true, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        Guard.ThrowIfArgumentIsNull(entities);
        Guard.ThrowIfArgumentIsEmpty(entities, nameof(entities), "Entities is a empty collection.");
        this.Context.UpdateRange(entities);
        this.Context.SaveChanges(true);
    }
}
