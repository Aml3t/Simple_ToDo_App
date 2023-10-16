﻿using Globomantics.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Infrastructure.Data
{
    public class DomainToDataMapping
    {
        public static TTo MapTodoFromDomain<TFrom, TTo>(Domain.Todo input)
            where TFrom : Domain.Todo
            where TTo : Data.Models.Todo
        {
            var model = input switch
            {
                Domain.Bug bug => MapBug(bug),
                Domain.Feature feature => MapFeature(feature),
                Domain.TodoTask task => MapTask(task),
                _ => throw new NotImplementedException()
            } as TTo;

            return model;
        }

        public static Data.Models.User MapUser(Domain.User user)
        {
            return new() { Id = user.Id, Name = user.Name };
        }

        private static Data.Models.Bug MapTask(Domain.Bug bug)
        {
            return new()
            {
                Id = bug.Id,
                AffectedUsers = bug.AffectedUsers,
                AffectedVersion = bug.AffectedVersion,
                CreatedDate = bug.CreatedDate,
                DueDate = bug.DueDate,
                Images = bug.Images.Select(image => new Data.Models.Image
                { ImageData = Convert.ToBase64String(image) }).ToArray(),
                IsCompleted = bug.IsCompleted,
                IsDeleted = bug.IsDeleted,
                Severity = (Data.Models.Severity)bug.Severity,
                Title = bug.Title,
                Description = bug.Description
            };
        }

        private static object MapFeature(Feature feature)
        {
            throw new NotImplementedException();
        }

        private static object MapBug(Bug bug)
        {
            throw new NotImplementedException();
        }
    }
}
