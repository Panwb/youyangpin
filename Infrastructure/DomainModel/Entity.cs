using System;
using System.Collections.ObjectModel;

namespace Infrastructure.DomainModel
{
    public interface IEntity
    {
    }

    [Serializable]
    public enum EntityAction
    {
        /// <summary>
        /// New records, It hasn't been saved into database yet
        /// </summary>
        New = 0,

        /// <summary>
        /// The record is existing in database, and isn't changed in application
        /// </summary>
        UnChanged = 1,

        /// <summary>
        /// The records is existing in database, and is changed/dirty in application content
        /// </summary>
        Updated = 2,

        /// <summary>
        /// The records is existing in database ,and is deleted in application content.
        /// </summary>
        Deleted = 3,
        //unnormal record
        UnAttach = 4
    }

    [Serializable]
    public abstract class EntityBase : IEntity
    {
        private EntityAction _action = EntityAction.UnChanged;
        
        /// <summary>
        /// Entity action.
        /// </summary>
        public EntityAction Action
        {
            get { return _action; }
            set { _action = value; }
        }
    }

    [Serializable]
    public class EntityBaseCollection : Collection<EntityBase>
    {
    }
}
