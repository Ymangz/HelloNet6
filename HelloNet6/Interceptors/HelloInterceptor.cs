using Anotar.Serilog;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace HelloNet6.Inter;

public class HelloInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        var _logger = eventData.Context.GetService<ILogger<HelloInterceptor>>();
        _logger.LogInformation("SavingChanges");
        LogTo.Information("在EFCore中DI注入");
        return base.SavingChanges(eventData, result);
    }

    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        return base.SavedChanges(eventData, result);
    }

    public override void SaveChangesFailed(DbContextErrorEventData eventData)
    {
        base.SaveChangesFailed(eventData);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        return base.SavedChangesAsync(eventData, result, cancellationToken);
    }

    public override Task SaveChangesFailedAsync(DbContextErrorEventData eventData,
        CancellationToken cancellationToken = new CancellationToken())
    {
        return base.SaveChangesFailedAsync(eventData, cancellationToken);
    }
}