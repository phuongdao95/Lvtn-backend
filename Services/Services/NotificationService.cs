using Microsoft.EntityFrameworkCore;
using Models.Models;
using Models.Repositories.DataContext;

namespace Services.Services
{
    public class NotificationService
    {
        private EmsContext _dbContext;
        public NotificationService(EmsContext context)
        {
            _dbContext = context;
        } 

        public List<Notification> GetNotificationsForUser(int userId)
        {
            var user = _dbContext.Users
                .Where(user => user.Id == userId)
                .Include(user => user.Notifications)
                .Single();

            if (user.Notifications == null)
            {
                throw new Exception("User not init properly");
            }
            
            return user.Notifications;
        }

        public void AddNotificationForUsers(
            Notification notification, 
            List<User> users)
        {
            _dbContext.Notifications.Add(notification);
            
            foreach (var user in users) 
            {
                notification.Users.Add(user);
            }

            _dbContext.Notifications.Add(notification);
            _dbContext.SaveChanges();
        }

        public void RemoveNotificationOfUser(
            int notificationId, 
            int userId)
        {
            var user = _dbContext.Users.Find(userId);
            var notification = _dbContext.Notifications.Find(notificationId);

            if (user == null || notification == null)
            {
                throw new Exception("User or notification not found");
            }

            notification.Users.Remove(user);

            _dbContext.Notifications.Update(notification);
            _dbContext.SaveChanges();
        }

        public void MarkAllNotifiicationsAsReadForUser(int userId)
        {
            var user = _dbContext.Users
                .Include(user => user.Notifications)
                .Where(user => user.Id == userId)
                .Single();

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (user.Notifications == null)
            {
                throw new Exception("Notification not init properly");
            }

            foreach (var notification in user.Notifications)
            {
                notification.IsRead = true;
            }

            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }
    }
}
