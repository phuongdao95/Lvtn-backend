using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Models.Repositories.DataContext;

namespace Services.Services
{
    public class NotificationService
    {
        private EmsContext _dbContext;
        private IMapper _mapper;
        public NotificationService(
            EmsContext context,
            IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        } 

        public List<Notification> GetNotificationsForUser(int userId)
        {
            var user = _dbContext.Users
                .Where(user => user.Id == userId)
                .Include(user => user.Notifications)
                .Single();

            if (user == null)
            {   
                throw new Exception("User not found");
            }

            var userNotification = user.Notifications
                .OrderByDescending(p => p.DateTime)
                .ToList();

            return userNotification;
        }

        public void AddNotificationForAllUser(
            Notification notification)
        {
            var userList = _dbContext.Users.ToList();

            var notificationList = new List<Notification>();

            foreach (var user in userList)
            {
                var userNotification = new Notification
                {
                    DateTime = notification.DateTime,
                    IsGlobal = true,
                    IsRead = false,
                    Message = notification.Message,
                    Title = notification.Title,
                    UserId = user.Id
                };

                notificationList.Add(userNotification);
            }

            _dbContext.Notifications.AddRange(notificationList);
            _dbContext.SaveChanges();
        }

        public void AddNotificationForUsers(
            Notification notification, 
            List<User> users)
        {
            
            foreach (var user in users) 
            {
                var userNotification = _mapper.Map<Notification>(notification);
                userNotification.UserId = user.Id;
                _dbContext.Notifications.Add(notification);
            }

            _dbContext.SaveChanges();
        }

        public void RemoveNotification(
            int notificationId)
        {
            var notification = _dbContext.Notifications.Find(notificationId);

            if (notification == null)
            {
                throw new Exception("User or notification not found");
            }

            _dbContext.Notifications.Remove(notification);
            _dbContext.SaveChanges();
        }

        public void DeleteAllNotificationOfUser(int userId)
        {
            var notification = _dbContext.Notifications
                .Where(notification => notification.UserId == userId)
                .ToList();

            _dbContext.Notifications.RemoveRange(notification);
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
