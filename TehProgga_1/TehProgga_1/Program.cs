using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace TehProgga_1
{
    public class GameObject
    {
        public int id;
        public string name;
        public int x;
        public int y;
        public int getId() { return id; }
        public string getName() { return name; }
        public int getX() { return x; }
        public int getY() { return y; }
    }
    public class Unit : GameObject
    {
        public bool alive = true;
        public float hp;
        public bool isAlive() { return alive; }
        public float getHp() { return hp; }
        public void receiverDamage(float rdmg) { hp -= rdmg; if (hp <= 0) { alive = false; } }
    }
    class Building : GameObject
    {
        public bool status;
        public bool isBuilt() { return status; }
    }
    class Archer : Unit, Attacker, Moveable
    {
        public float damage;
        public void Attack(Unit unit)
        { 
            unit.receiverDamage(damage);
        }
        public void MoveTo(int x0, int y0)
        {
            x = x0;
            y = y0;
        }
    }
    class Fort : Building, Attacker
    {
        public float damage;
        public void Attack(Unit unit)
        {
            unit.receiverDamage(damage);
        }
    }
    class MobileHome : Building, Moveable
    {
        public void MoveTo(int x0, int y0)
        {
            x = x0;
            y = y0;
        }
    }
    interface Attacker
    {
        void Attack(Unit unit);
    }
    interface Moveable
    {
        void MoveTo(int x, int y);
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Archer ark = new Archer();
            ark.hp = 10;
            ark.damage = 3;
            Console.WriteLine(ark.isAlive());
            Console.WriteLine(ark.getHp());
            ark.MoveTo(1,1);
            Fort nox = new Fort();
            nox.damage = 10;
            nox.Attack(ark);
            Console.WriteLine(ark.getHp());
            Console.WriteLine(ark.isAlive());

        }
    }
}
