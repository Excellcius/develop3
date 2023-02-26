using System;
using System.Threading;

// Base class for all activities
public abstract class Activity {
    protected int duration; // duration in seconds
    protected string description;

    public Activity(string description) {
        this.description = description;
    }

    // Prompt user for duration and show starting message
    public virtual void Start() {
        Console.Write("Enter duration (seconds): ");
        duration = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine($"Starting {description}...");
        Console.WriteLine($"Duration: {duration} seconds");
        Console.WriteLine("Get ready to begin in:");
        for (int i = 3; i >= 1; i--) {
            Console.Write(i + "...");
            Thread.Sleep(1000); // pause for 1 second
        }
        Console.WriteLine("Go!");
    }

    // Show ending message
    public virtual void End() {
        Console.WriteLine($"You did a great job! You completed {description} for {duration} seconds.");
        Console.WriteLine();
        Thread.Sleep(3000); // pause for 3 seconds
    }

    // Show animation while pausing
    protected void Pause(int seconds) {
        for (int i = seconds; i >= 1; i--) {
            Console.Write(".");
            Thread.Sleep(1000); // pause for 1 second
        }
        Console.WriteLine();
    }

    // Abstract method to run the activity
    public abstract void Run();
}

// Breathing activity
public class BreathingActivity : Activity {
    public BreathingActivity() : base("Breathing Exercise") {}

    // Show alternate "Breathe in" and "Breathe out" messages
    public override void Run() {
        Console.WriteLine("Clear your mind and focus on your breathing.");
        for (int i = 0; i < duration; i += 2) {
            Console.WriteLine("Breathe in...");
            Pause(2);
            Console.WriteLine("Breathe out...");
            Pause(2);
        }
    }
}

// Reflection activity
public class ReflectionActivity : Activity {
    private static readonly string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection Exercise") {}

    // Show random prompt and questions
    public override void Run() {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);

        for (int i = 0; i < duration; i += 10) {
            string question = questions[random.Next(questions.Length)];
            Console.WriteLine(question);
            Pause(5);
        }
    }
}

// Listing activity
public class ListingActivity : Activity {
    private static readonly string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who arepeople that inspire you?",
        "What are things that bring you joy?",
        "What are some of your favorite memories?"
};
public ListingActivity() : base("Listing Exercise") {}

// Show random prompt and prompt for list of items
public override void Run() {
    Random random = new Random();
    string prompt = prompts[random.Next(prompts.Length)];
    Console.WriteLine(prompt);

    Console.WriteLine("List your items below:");
    for (int i = 0; i < duration; i += 10) {
        Console.Write($"{i + 10} seconds left... ");
        string item = Console.ReadLine();
    }
    Console.WriteLine("Time's up!");
}
}

class Program {
    static void Main(string[] args) {
    // Create and run activities
    Activity[] activities = {
    new BreathingActivity(),
    new ReflectionActivity(),
    new ListingActivity()
};
        foreach (Activity activity in activities) {
        activity.Start();
        activity.Run();
        activity.End();
    }

    Console.WriteLine("Great job! You completed all activities.");
    Console.ReadLine();
}



