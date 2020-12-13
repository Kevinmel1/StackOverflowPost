using System;

namespace StackOverflowPost
{
    public class StackOverflow
    {
        public int ID { get; private set; } = 0;
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        public int VoteScore { get; private set; } = 1;

        public StackOverflow(int id, string title, string description, DateTime date)
        {
            ID = id;
            Title = title;
            Description = description;
            Date = date;
        }

        public void DisplayPost()
        {
            Console.WriteLine($"- TopicID:{this.ID}(Score:{this.VoteScore})   Title:{this.Title}  Description:{this.Description}  Date:{this.Date.ToShortDateString()}\n");
        }

        public void UpVote()
        {

            VoteScore++;
        }
        public void DownVote()
        {

            VoteScore--;
        }
    }
}