namespace Models.DTO.Request
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public string CitizenId { get; set; }
        public bool Sex { get; set; }
        public DateTime Birthday { get; set; }


    }
}
