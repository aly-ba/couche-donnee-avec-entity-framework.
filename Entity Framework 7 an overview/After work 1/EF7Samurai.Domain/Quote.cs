namespace EF7Samurai.Domain
{
    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; }
        //originally did not have the following
        //navigation and FK properties.
       //adding them in made no difference
     
        public Samurai Samurai { get; set; }
        public int SamuraiId { get; set; }
    }
}