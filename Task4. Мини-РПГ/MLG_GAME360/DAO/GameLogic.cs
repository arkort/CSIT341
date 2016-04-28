using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.EnemyEvents;
using DataLayer.PickUpEvents;

namespace DAO
{
    public class GameLogic
    {
        public Data data;

        public bool IsEndGame = false;
        private int randomEvent = 0;
        Random random = new Random();

        //создание персонажа
        public Player GeneratePlayer()
        {
            int max_player_health = random.Next(100, 300);
            int strength = random.Next(5, 15);
            int agility = random.Next(1, 30);
            return (new Player(max_player_health, strength, WeaponGenerate.GenerateWeapon(), agility));
        }

        //инфо о игроке
        public string InfoPlayer()
        {
            StringBuilder Info = new StringBuilder(100);
            Info.Append("Здоровье = ").Append(data.player.health.ToString()).Append("  |  Золото = ")
                .Append(data.player.gold.ToString()).Append("\n\nСила = ").Append(data.player.strength.ToString())
                .Append("  |  Ловкость = ").Append(data.player.agility.ToString()).Append("  |  Оружие = ")
                .Append(data.weapons[data.player.weapontype].Item2.ToString().TrimEnd('а'));
            return Info.ToString();
        }

        //создание оружия
        public void InitWeapons()
        {
            data.weapons.Add(0, new Tuple<int, string>(10, "Кинжала"));
            data.weapons.Add(1, new Tuple<int, string>(20, "Лука"));
            data.weapons.Add(2, new Tuple<int, string>(30, "Меча"));
            data.weapons.Add(3, new Tuple<int, string>(40, "Топора"));
        }

        //случайная генерация событий
        public IEvent GenerateEvent()
        {
            randomEvent = random.Next(0, 100);
            //Вероятность событий
            if (randomEvent < 20)  //20% встретить крысу
            {
                return (new EnemyRat(random.Next(20, 30)));
            }
            if (randomEvent >= 20 && randomEvent < 32) //12% встретить скелета
            {
                return (new EnemySkeleton(random.Next(30, 60), WeaponGenerate.GenerateSkeletonWeapon()));
            }
            if (randomEvent >= 32 && randomEvent < 40) //8% встретить огра
            {
                return (new EnemyOgr(random.Next(60, 80), WeaponGenerate.GenerateOgrWeapon()));
            }
            if (randomEvent >= 40 && randomEvent < 45) //5% встретить босса
            {
                return (new EnemyBoss(random.Next(80, 100), WeaponGenerate.GenerateBossWeapon(), random.NextDouble()));
            }
            if (randomEvent >= 45 && randomEvent < 53) //8% выпадения бинта
            {
                return (new SmallMedKit(random.Next(20, 30)));
            }
            if (randomEvent >= 53 && randomEvent < 58) //5% выпадения аптечки
            {
                return (new MediumMedKit(random.Next(40, 50)));
            }
            if (randomEvent >= 58 && randomEvent < 62) //4% выпадения большой аптечки
            {
                return (new LargeMedKit(random.Next(70, 90)));
            }
            if (randomEvent >= 62 && randomEvent < 82) //20% выпадения малого сокровища
            {
                return (new SmallTreasure(random.Next(75, 150)));
            }
            if (randomEvent >= 82 && randomEvent < 95) //13% выпадения среднего сокровища
            {
                return (new MediumTreasure(random.Next(150, 250)));
            }
            if (randomEvent >= 95 && randomEvent < 100) //5% выпадения большой аптечки
            {
                return (new LargeTreasure(random.Next(500, 750)));
            }
            return null;
        }

        public void GameStart()
        {
            data = new Data(GeneratePlayer());
            InitWeapons();
        }

        public string CheckGame()
        {
            if (data.player.health <= 0)
            {
                this.IsEndGame = true;
                data.player.health = 0;
                return "YOU ARE DEAD.";
            }

            if (data.player.gold >= 20000)
            {
                this.IsEndGame = true;
                data.player.gold = 20000;
                return "VICTORY";
            }
            return "";
        }

        //проверка на завершение боя с врагом
        public bool IsStepFinished(IEvent VerifiableEvent)
        {
            if (VerifiableEvent.GetType() == typeof(EnemyRat))
            {
                EnemyRat rat = null;
                rat = (EnemyRat)VerifiableEvent;
                if (rat.enemyHealth > 0)
                {
                    return false;
                }
            }
            else if (VerifiableEvent.GetType() == typeof(EnemySkeleton))
            {
                EnemySkeleton skeleton = null;
                skeleton = (EnemySkeleton)VerifiableEvent;
                if (skeleton.enemyHealth > 0)
                {
                    return false;
                }
            }
            else if (VerifiableEvent.GetType() == typeof(EnemyOgr))
            {
                EnemyOgr ogr = null;
                ogr = (EnemyOgr)VerifiableEvent;
                if (ogr.enemyHealth > 0)
                {
                    return false;
                }
            }
            else if (VerifiableEvent.GetType() == typeof(EnemyBoss))
            {
                EnemyBoss boss = null;
                boss = (EnemyBoss)VerifiableEvent;
                if (boss.enemyHealth > 0)
                {
                    return false;
                }
            }
            return true;
        }

        public string GameStep()
        {
            string NextEvent;
            string GameResult;
            IEvent gameEvent = null;
            if (data.HistoryEvents.Count != 0)
            {
                if (IsStepFinished(data.HistoryEvents.Last()) && !data.ForceEvent)
                {
                    gameEvent = GenerateEvent();
                }
                else
                {
                    data.ForceEvent = false;
                    gameEvent = data.HistoryEvents.Last();
                }
            }
            else
            {
                gameEvent = GenerateEvent();
            }
            data.AddEvent(gameEvent);
            NextEvent = gameEvent.EventHandle(data.player, this.data);
            GameResult = CheckGame();
            return NextEvent;
        }
    }
}
