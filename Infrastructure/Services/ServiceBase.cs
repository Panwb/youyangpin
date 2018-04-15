using System;
using System.Diagnostics;
using System.Transactions;
using Infrastructure.DomainModel;

namespace Infrastructure.Services
{
    public abstract class ServiceBase<TEntity> : IService<TEntity>
        where TEntity : IEntity
    {
        //

        protected ServiceBase() { }

        //protected ServiceBase(ILogger logger)
        //{
        //    _logger = logger;
        //}

        [DebuggerStepThrough]
        protected TResult ExecuteCommand<TResult>(Func<TResult> command)
            where TResult : ServiceResultBase
        {
            var options = new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted };
            using (var ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                try
                {
                    var result = command.Invoke();
                    if (result == null)
                    {
                        ts.Complete();
                        return null;
                    }

                    //if (result.HasViolation && _logger != null)
                    //{
                    //    _logger.LogInformation(result.ErrorMessage);
                    //}
                    if (!result.HasViolation)
                    {
                        ts.Complete();
                    }
                    return result;
                }
                catch (Exception exception)
                {
                    var type = typeof(TResult);
                    if (type.IsAbstract)
                        throw;
                    var instance = Activator.CreateInstance(type) as ServiceResultBase;
                    if (instance != null)
                    {
                        instance.ViolationType = ViolationType.Exception;
                        instance.RuleViolations.Add(new RuleViolation("exception", exception.Message));
                    }
                    //if (_logger != null)
                    //{
                    //    _logger.LogError(exception.ToString());
                    //}
                    return instance as TResult;
                }
            }
        }
    }
}
