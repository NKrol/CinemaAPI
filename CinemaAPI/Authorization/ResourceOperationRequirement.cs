using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CinemaAPI.Authorization
{
    public enum ResourceOperation
    {
        Create,
        Read,
        Update,
        Delete
    }

    public class ResourceOperationRequirement : IAuthorizationRequirement
    {
        private readonly ResourceOperation _resourceOperation;

        public ResourceOperationRequirement(ResourceOperation resourceOperation)
        {
            _resourceOperation = resourceOperation;
        }

        public ResourceOperation ResourceOperation { get; }
    }
}
