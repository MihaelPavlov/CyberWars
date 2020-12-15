namespace CyberWars.Data.Models.Player
{
    using System;

    public class LoginHistory
    {
        public int Id { get; set; }

        public Player Player { get; set; }

        public string PlayerId { get; set; }

        public DateTime Date { get; set; }

        public string LoginTime { get; set; }
    }
}
