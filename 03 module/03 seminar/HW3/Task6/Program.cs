using System;

namespace Task6
{
    public class RingIsFoundEventArgs : EventArgs
    {
        public String Message { get; set; }

        public RingIsFoundEventArgs(string s)
        {
            Message = s;
        }

    }

    public abstract class Creature
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public Creature(string s)
        {
            Name = s;
        }

        public virtual void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> иду в {e.Message}");
            Location = e.Message;
        }
    }

    public class Wizard : Creature
    {
        public delegate void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs a);

        public event RingIsFoundEventHandler RaiseRingIsFoundEvent;

        public Wizard(string s) : base(s) { }

        public void RingWasFound()
        {
            Console.WriteLine($"{Name} >> Кольцо найдено");
            RaiseRingIsFoundEvent(this, new RingIsFoundEventArgs("Ривендейл"));
        }
    }

    public class Hobbit : Creature
    {

        public Hobbit(string s) : base(s) { }

        public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"Хоббит {Name} >> иду в {e.Message}");
            Location = e.Message;
        }
    }

    public class Human : Creature
    {
        public Human(string s) : base(s) { }

        public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"Человек {Name} >> иду в {e.Message}");
            Location = e.Message;
        }
    }

    public class Elf : Creature
    {
        public Elf(string s) : base(s) { }

        public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"Ельф {Name} >> иду в {e.Message}");
            Location = e.Message;
        }
    }

    public class Dwarf : Creature
    {
        public Dwarf(string s) : base(s) { }

        public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"Гном {Name} >> иду в {e.Message}");
            Location = e.Message;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Wizard wizard = new Wizard("Гендальф");
            Creature[] creatures = new Creature[8];
            creatures[0] = new Hobbit("Фродо");
            creatures[1] = new Hobbit("Сэм");
            creatures[2] = new Hobbit("Пипин");
            creatures[3] = new Hobbit("Мэрри");
            creatures[4] = new Human("Боромир");
            creatures[5] = new Human("Арагорн");
            creatures[6] = new Dwarf("Гимли");
            creatures[7] = new Elf("Леголас");

            foreach (Creature c in creatures)
                wizard.RaiseRingIsFoundEvent += c.RingIsFoundEventHandler;

            wizard.RingWasFound();
        }
    }
}
