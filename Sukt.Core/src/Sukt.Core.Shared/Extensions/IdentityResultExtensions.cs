﻿using Microsoft.AspNetCore.Identity;
using Sukt.Core.Shared.Enums;
using Sukt.Core.Shared.OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sukt.Core.Shared.Extensions
{
    public static partial class Extensions
    {
        public static OperationResponse ToOperationResponse(this IdentityResult identityResult)
        {
            return identityResult.Succeeded ? new OperationResponse(OperationEnumType.Success) : new OperationResponse(identityResult.Errors.Select(o => o.Description).ToJoin(), OperationEnumType.Error);
        }
        public static IdentityResult Failed(this IdentityResult identityResult, params string[] errors)
        {
            var identityErrors = identityResult.Errors;
            identityErrors = identityErrors.Union(errors.Select(m => new IdentityError() { Description = m }));
            return IdentityResult.Failed(identityErrors.ToArray());
        }
    }
}
