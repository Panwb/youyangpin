using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Infrastructure.Entities
{
    public interface IEntity
    {
    }

    [DataContract(Name = "EntityAction")]
    [Serializable]
    public enum EntityAction
    {
        /// <summary>
        /// New records, It hasn't been saved into database yet
        /// </summary>
        [EnumMember]
        New = 0,

        /// <summary>
        /// The record is existing in database, and isn't changed in application
        /// </summary>
        [EnumMember]
        UnChanged = 1,

        /// <summary>
        /// The records is existing in database, and is changed/dirty in application content
        /// </summary>
        [EnumMember]
        Updated = 2,

        /// <summary>
        /// The records is existing in database ,and is deleted in application content.
        /// </summary>
        [EnumMember]
        Deleted = 3,
        //unnormal record
        [EnumMember]
        UnAttach = 4
    }

    [DataContract]
    [Serializable]
    public abstract class EntityBase : IEntity
    {
        private EntityAction _action = EntityAction.UnChanged;
        
        /// <summary>
        /// Entity action.
        /// </summary>
        [DataMember(Name = "Action")]
        public EntityAction Action
        {
            get { return _action; }
            set { _action = value; }
        }
    }

    [DataContract]
    [Serializable]
    public class EntityBaseCollection : Collection<EntityBase>
    {
    }
}
