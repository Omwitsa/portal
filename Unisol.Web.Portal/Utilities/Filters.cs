using System;
using System.Linq.Expressions;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Entities.Database.MembershipModels;

namespace Unisol.Web.Portal.Utilities
{
    public class Filters
	{
		public Expression<Func<User, bool>> FilterUsers(UserQuery query)
		{
			var predicate = PredicateBuilder.True<User>();

			if (!string.IsNullOrEmpty(query.SearchText))
			{
				string searchParameter = query.SearchText.ToLower();
				var search = PredicateBuilder.False<User>();
				search = search.Or(p => p.UserName.ToLower().Contains(searchParameter));
				search = search.Or(p => p.PhoneNumber.ToLower().Contains(searchParameter));
				search = search.Or(p => p.Email.ToLower().Contains(searchParameter));
				predicate = predicate.And(search);
			}

			if (query.Role.HasValue)
			{
				predicate = predicate.And(p => p.UserGroup.Role == (Role)query.Role.Value);
			}

			return predicate;
		}

		public Expression<Func<PortalEvents, bool>> FilterEvents(EventsQuery query)
		{
			var predicate = PredicateBuilder.True<PortalEvents>();

			if (!string.IsNullOrEmpty(query.SearchText))
			{
				string searchParameter = query.SearchText.ToLower();
				var search = PredicateBuilder.False<PortalEvents>();
				search = search.Or(p => p.EventDesc.ToLower().Contains(searchParameter));
				search = search.Or(p => p.EventTitle.ToLower().Contains(searchParameter));
				search = search.Or(p => p.PortalEventType.EventTypeName.ToLower().Contains(searchParameter));
				predicate = predicate.And(search);
			}

			if (query.PortalEventTypeId.HasValue)
			{
				predicate = predicate.And(p => p.PortalEventType.Id == query.PortalEventTypeId.Value);
			}

			return predicate;
		}

		public Expression<Func<UserGroupPrivilege, bool>> FilterPrivileges(Query query)
		{
			var predicate = PredicateBuilder.True<UserGroupPrivilege>();

			if (!string.IsNullOrEmpty(query.SearchText))
			{
				string searchParameter = query.SearchText.ToLower();
				var search = PredicateBuilder.False<UserGroupPrivilege>();
				search = search.Or(p => p.PrivilegeName.ToLower().Contains(searchParameter));
				predicate = predicate.And(search);
			}

			return predicate;
		}

		public Expression<Func<EvaluationsCurrent, bool>> FilterCurrentEvaluations(Query query)
		{
			var predicate = PredicateBuilder.True<EvaluationsCurrent>();

			if (!string.IsNullOrEmpty(query.SearchText))
			{
				string searchParameter = query.SearchText.ToLower();
				var search = PredicateBuilder.False<EvaluationsCurrent>();
				search = search.Or(p => p.CurrentEvaluationName.ToLower().Contains(searchParameter));
				search = search.Or(
					p => p.Evaluation.EvaluationName.CaseInsensitiveContains(searchParameter));
				predicate = predicate.And(search);
			}

			return predicate;
		}
	}
}
