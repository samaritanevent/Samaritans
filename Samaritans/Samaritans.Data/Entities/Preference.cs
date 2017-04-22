namespace Samaritans.Data.Entities
{
    public class Preference
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
