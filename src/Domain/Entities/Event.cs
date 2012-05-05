﻿namespace BeerConf.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Brandy.Core;
    using Brandy.Security;
    using Brandy.Security.Entities;

    public class Event : IEntity
    {
        private readonly ICollection<User> participants = new List<User>();

        public virtual DateTime Begin { get; set; }

        public virtual DateTime End { get; set; }

        public virtual string Place { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual int? MaxPlaces { get; set; }

        public virtual IEnumerable<User> Participants
        {
            get { return participants; }
        }

        #region IEntity Members

        public virtual int Id { get; set; }

        #endregion

        public virtual void AddParticipant(User user)
        {
            if (MaxPlaces == null || MaxPlaces > participants.Count)
                participants.Add(user);
        }

        public virtual int? AvailablePlaces()
        {
            return MaxPlaces - Participants.Count();
        }
    }
}
