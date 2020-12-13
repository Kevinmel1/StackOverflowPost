using System;
using System.Collections.Generic;

namespace StackOverflowPost
{
    class Program
    {
        static void Main()
        {
            List<StackOverflow> posts = new List<StackOverflow>()
            {
                new StackOverflow(1,"C# error: 'An object reference is required for the non-static field, method, or property'", "I have two classes, one for defining the algorithm parameters and another to implement the algorithm:", DateTime.Now ),
                new StackOverflow(2,"Adding item to list using constructor", "I am learning C# and was trying different ways to add to list. I tried two different method below . First One does not work, second one does work.", DateTime.Now ),
                new StackOverflow(3,"Calling the base constructor", "If I inherit from a base class and want to pass something from the constructor of the inherited class to the constructor of the base class, how do I do that?", DateTime.Now ),
                new StackOverflow(4,"How to randomly select an item from a list?", "What is the simplest way to retrieve an item at random from this list?", DateTime.Now ),
                new StackOverflow(5,"How can I loop through a List<T> and grab each item?", "How can I loop through a List and grab each item? I want the output to look like this.", DateTime.Now )
            };
            string state = "listView";

            int selectedPost = 1;

            while (true)
            {
                Console.Clear();
                if (state == "listView")
                {
                    Console.WriteLine("********************************\nWelcome to Stack Overflow forum.\n********************************\nTopics:\n");
                    foreach (StackOverflow post in posts)
                    {
                        post.DisplayPost();
                    }
                    Console.WriteLine($"Select an post Id:");
                    string inputID = "0";
                    try
                    {
                        inputID = Console.ReadLine();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("You didn't enter a number...");
                    }
                    if (inputID == "q")
                    {
                        return;
                    } else if (Int32.TryParse(inputID, out int G))
                    {
                        foreach (StackOverflow post in posts)
                        {
                            if (Convert.ToInt32(inputID) == post.ID)
                            {
                                selectedPost = post.ID;
                                state = "postView";
                            }
                        }
                    } else {
                        Console.WriteLine("Not a valid input, choose a number from the ID's to view post.");
                    }
                }
                else if (state == "postView")
                {
                    
                    var post = posts.Find(x => x.ID == selectedPost);
                    Console.WriteLine($"- TopicID:{post.ID}(Score:{post.VoteScore})   Title:{post.Title}  Description:{post.Description}  Date:{post.Date.ToShortDateString()}\n");
                    Console.WriteLine("********************************\nPress + Enter: + to upvote, - to downvote, 'q' to quit application.\n");
                    switch (Console.ReadLine().ToLower())
                    {
                        case "+":
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.WriteLine($"Upvoted Topic({post.ID}):  '{post.Title}' with '+1':\n");
                            post.UpVote();
                            break;

                        case "-":
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.WriteLine($"Downvoted Topic({post.ID}):  '{post.Title}' with '-1':\n");
                            post.DownVote();
                            break;

                        case "q":
                            state = "listView";
                            break;
                    }
                }
            }
        }
    }
}