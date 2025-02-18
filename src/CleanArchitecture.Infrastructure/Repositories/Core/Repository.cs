﻿using CleanArchitecture.Domain.Abstractions.Repositories.Core;
using CleanArchitecture.Domain.Core;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ResultifyCore;
using System.Linq.Expressions;

namespace CleanArchitecture.Infrastructure.Repositories.Core;
public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey>, IRepositoryAsync<TEntity, TKey>
    where TEntity : class, IEntity
    where TKey : notnull
{
    protected readonly ApplicationDbContext Context;

    protected Repository(ApplicationDbContext context)
    {
        Context = context;
    }

    public void Add(TEntity entity)
    {
        Guard.ThrowIfArgumentIsNull(entity);
        Context.Add(entity);
        Context.SaveChanges();
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        Guard.ThrowIfArgumentIsNull(entity);
        await Context.AddAsync(entity, cancellationToken).ConfigureAwait(false);
        await Context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        Guard.ThrowIfArgumentIsNull(entities);
        Guard.ThrowIfArgumentIsEmpty(entities, nameof(entities), "Entities is a empty collection.");
        Context.AddRange(entities);
        Context.SaveChanges(true);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        Guard.ThrowIfArgumentIsNull(entities);
        Guard.ThrowIfArgumentIsEmpty(entities, nameof(entities), "Entities is a empty collection.");
        await Context.AddRangeAsync(entities, cancellationToken).ConfigureAwait(false);
        await Context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public void Delete(TKey id)
    {
        Guard.ThrowIfArgumentIsNull(id);
        var entity = Context.Find<TEntity>(id);
        Guard.ThrowIfArgumentIsNull(entity);
        Delete(entity!);
    }

    public void Delete(TEntity entity)
    {
        Guard.ThrowIfArgumentIsNull(entity);
        Context.Remove(entity);
        Context.SaveChanges();
    }

    public async Task DeleteAsync(TKey id, CancellationToken cancellationToken)
    {
        Guard.ThrowIfArgumentIsNull(id);
        var entity = await Context.FindAsync<TEntity>(id);
        Guard.ThrowIfArgumentIsNull(entity);
        await DeleteAsync(entity!, cancellationToken);
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
    {
        Guard.ThrowIfArgumentIsNull(entity);
        Context.Remove(entity);
        await Context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        Guard.ThrowIfArgumentIsNull(entities);
        Guard.ThrowIfArgumentIsEmpty(entities, nameof(entities), "Entities is a empty collection.");
        Context.RemoveRange(entities);
        Context.SaveChanges(true);
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        Guard.ThrowIfArgumentIsNull(predicate);
        return Context.Set<TEntity>().Where(predicate).ToList();
    }

    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        Guard.ThrowIfArgumentIsNull(predicate);
        return await Context.Set<TEntity>().Where(predicate).ToListAsync();
    }

    public IEnumerable<TEntity> GetAll()
    {
        return Context.Set<TEntity>().AsNoTracking().ToList();
    }
    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await Context.Set<TEntity>().ToListAsync();
    }

    public TEntity? GetById(TKey id)
    {
        Guard.ThrowIfArgumentIsNull(id);
        return Context.Set<TEntity>().Find(id);
    }
    public async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken)
    {
        Guard.ThrowIfArgumentIsNull(id);
        return await Context.Set<TEntity>().FindAsync(id);
    }

    public PaginatedResult<TEntity> GetPagedList(int pageSize, int pageNumber)
    {
        Guard.ThrowIfArgumentIsNegativeOrZero(pageSize);
        Guard.ThrowIfArgumentIsNegativeOrZero(pageNumber);
        var query = Context.Set<TEntity>().AsQueryable();
        var totalItemCount = query.Count();
        var pageCount = (long)Math.Ceiling((double)totalItemCount / pageSize);
        var entities = query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return new PaginatedResult<TEntity>
       (
           Count: entities.Count,
           PageNumber: pageNumber,
           PageSize: pageSize,
           PageCount: pageCount,
           TotalItemCount: totalItemCount,
           HasPreviousPage: pageNumber > 1,
           HasNextPage: pageNumber < pageCount,
           IsFirstPage: pageNumber == 1,
           IsLastPage: pageNumber >= pageCount,
           Entities: entities
       );
    }

    public async Task<PaginatedResult<TEntity>> GetPagedListAsync(int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        Guard.ThrowIfArgumentIsNegativeOrZero(pageSize);
        Guard.ThrowIfArgumentIsNegativeOrZero(pageNumber);
        var query = Context.Set<TEntity>().AsQueryable();
        var totalItemCount = await query.CountAsync(cancellationToken).ConfigureAwait(false);
        var pageCount = (long)Math.Ceiling((double)totalItemCount / pageSize);
        var entities = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);

        return new PaginatedResult<TEntity>
       (
           Count: entities.Count,
           PageNumber: pageNumber,
           PageSize: pageSize,
           PageCount: pageCount,
           TotalItemCount: totalItemCount,
           HasPreviousPage: pageNumber > 1,
           HasNextPage: pageNumber < pageCount,
           IsFirstPage: pageNumber == 1,
           IsLastPage: pageNumber >= pageCount,
           Entities: entities
       );
    }

    public IQueryable<TEntity> GetQueryable()
    {
        return Context.Set<TEntity>().AsQueryable();
    }

    public void Update(TEntity entity)
    {
        Guard.ThrowIfArgumentIsNull(entity);
        Context.Update(entity);
        Context.SaveChanges(true);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        Guard.ThrowIfArgumentIsNull(entity);
        Context.Update(entity);
        await Context.SaveChangesAsync(true, cancellationToken).ConfigureAwait(false);
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        Guard.ThrowIfArgumentIsNull(entities);
        Guard.ThrowIfArgumentIsEmpty(entities, nameof(entities), "Entities is a empty collection.");
        Context.UpdateRange(entities);
        Context.SaveChanges(true);
    }
}
