namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class Event : IEntity
    {
        private readonly ICollection<User> participants = new List<User>();

        public virtual DateTime StartedAt { get; set; }
        public virtual DateTime FinishedAt { get; set; }
        public virtual string Place { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        public IEnumerable<User> Participants
        {
            get { return participants; }
        }

        #region IEntity Members

        public virtual int Id { get; private set; }

        #endregion
    }
}
