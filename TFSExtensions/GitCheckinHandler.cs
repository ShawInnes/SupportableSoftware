using Microsoft.TeamFoundation.Framework.Server;
using Microsoft.TeamFoundation.Git.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFSExtensions
{
    public class GitCheckinHandler : ISubscriber
    {
        public string Name
        {
            get { return "Git WAG Checkin Handler"; }
        }

        public SubscriberPriority Priority
        {
            get { return SubscriberPriority.Normal; }
        }

        public EventNotificationStatus ProcessEvent(TeamFoundationRequestContext requestContext, NotificationType notificationType, object notificationEventArgs, out int statusCode, out string statusMessage, out Microsoft.TeamFoundation.Common.ExceptionPropertyCollection properties)
        {
            statusCode = 0;
            statusMessage = string.Empty;
            properties = null;

            try
            {
                if (notificationType == NotificationType.DecisionPoint && notificationEventArgs is Microsoft.TeamFoundation.Git.Server.PushNotification)
                {
                    Microsoft.TeamFoundation.Git.Server.PushNotification pushNotification = notificationEventArgs as Microsoft.TeamFoundation.Git.Server.PushNotification;

                    TeamFoundationGitRepositoryService repositoryService = requestContext.GetService<TeamFoundationGitRepositoryService>();

                    using (TfsGitRepository repository = repositoryService.FindRepositoryById(requestContext, pushNotification.RepositoryId))
                    {
                        foreach (var item in pushNotification.IncludedCommits)
                        {
                            TfsGitCommit gitCommit = (TfsGitCommit)repository.LookupObject(requestContext, item);
                            var comment = gitCommit.GetComment(requestContext);

                            if (string.IsNullOrEmpty(comment))
                            {
                                statusMessage = "Checkin Comment Required";
                                return EventNotificationStatus.ActionDenied;
                            }

                            if (!comment.StartsWith("WAG"))
                            {
                                statusMessage = "WAG-xxxx or WAGxxxx Checkin Comment Required";
                                return EventNotificationStatus.ActionDenied;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return EventNotificationStatus.ActionPermitted;
        }

        public Type[] SubscribedTypes()
        {
            return new Type[] { typeof(Microsoft.TeamFoundation.Git.Server.PushNotification) };
        }
    }
}
