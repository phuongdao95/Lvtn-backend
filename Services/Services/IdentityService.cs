namespace Services.Services
{
    public class IdentityService
    {
        private int? _userId;
        private string? _userName;
        private string? _userUsername;

        public void InitializeService(int userId, string userName, string userUsername)
        {
            _userId = userId;
            _userName = userName;   
            _userUsername = userUsername;
        }

        public int GetCurrentUserId()
        {
            if (_userId == null)
            {
                throw new Exception("User not instantiated");
            }

            return _userId.Value;
        }

        public string GetCurrentUserName()
        {
            if (_userName == null)
            {
                throw new Exception();
            }

            return _userName;
        }

        public string GetCurrentUserUsername()
        {
            if (_userUsername == null)
            {
                throw new Exception();
            }

            return _userUsername;
        }
        
    }
}
