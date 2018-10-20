using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnBaseGame.Skills;

namespace TurnBaseGame.Entities.Configurations
{
    public class Statistic
    {

        private readonly int _baseActionPoint;
        private int _currentActionPoint;
        public int CurrentActionPoint
        {
            get
            {
                return _currentActionPoint;
            }
            set
            {
                _currentActionPoint += value;
                // check if AP is lower than 0
            }
        }

        private readonly int _baseHealthPoint;
        private int _currentHealthPoint;
        public int CurrentHealthPoint
        {
            get
            {
                return _currentHealthPoint;
            }
            set
            {
                if(value > 0) // Gain HP
                {
                    _currentHealthPoint += value;
                    _currentHealthPoint = _currentHealthPoint > _baseHealthPoint ? _baseHealthPoint : _currentHealthPoint;
                }
                else if(value < 0) // Lose HP
                {
                    int removedByDefense = value - CurrentDefense;
                    CurrentDefense -= value;
                    if(removedByDefense > 0)
                    {
                        _currentHealthPoint -= removedByDefense;
                    }
                }
            }
        }

        private readonly int _baseDefense;
        private int _currentDefense;
        public int CurrentDefense
        {
            get
            {
                return _currentDefense;
            }
            set
            {
                _currentDefense += value;
                if (_currentDefense < 0)
                    _currentDefense = 0;
            }
        }

        private readonly int _baseInitiative;
        private int _currentInitiative;

        private int _level;

        public List<Skill.SKILL_EFFECT> status;

        public Statistic(int level, int actionPoint, int healthPoint, int initiative, int defense)
        {
            _baseActionPoint = actionPoint;
            _currentActionPoint = _baseActionPoint;

            _baseHealthPoint = healthPoint;
            _currentHealthPoint = _baseHealthPoint;

            _baseInitiative = initiative;
            _currentInitiative = _baseInitiative;

            _baseDefense = defense;
            _currentDefense = _baseDefense;

            _level = level;

            status = new List<Skill.SKILL_EFFECT>();
        }

        public Statistic(Statistic s)
        {
            _baseActionPoint = s._baseActionPoint;
            _currentActionPoint = s._baseActionPoint;

            _baseHealthPoint = s._baseHealthPoint;
            _currentHealthPoint = s._baseHealthPoint;

            _baseInitiative = s._baseInitiative;
            _currentInitiative = s._baseInitiative;

            _currentDefense = s._currentDefense;
            _baseDefense = s._baseDefense;

            _level = s._level;

            status = new List<Skill.SKILL_EFFECT>();
        }

        public void Reset()
        {
            _currentActionPoint = _baseActionPoint;
            _currentDefense = _baseDefense;
            _currentHealthPoint = _baseHealthPoint;
            _currentInitiative = _baseInitiative;
        }

        public void RemoveStatus(int index)
        {
            this.status.RemoveAt(index);
        }

        public void RemoveStatus(Skill.SKILL_EFFECT skillEffect)
        {
            for (int i = status.Count - 1; i >= 0; i--)
            {
                if (status[i] == skillEffect)
                    status.RemoveAt(i);
            }
        }

        public void AddStatus(Skill.SKILL_EFFECT skillEffect)
        {
            this.status.Add(skillEffect);
        }

        /// <summary>
        /// Display in an detailled way the current statistic.
        /// </summary>
        /// <returns>The statistics</returns>
        public override String ToString()
        {
            String phrase = "Level " + _level + "\n" +
                   "HP : " + _currentHealthPoint + "/" + _baseHealthPoint + "\n" +
                   "Defense : " + _currentDefense + "\nAffected by :\n";
            if (status.Count == 0)
                phrase += "None";
            for (int i = 0; i < status.Count; i++)
            {
                if (i == 0)
                    phrase += this.status[i];
                else
                    phrase += ", " + this.status[i];
            }
            return phrase;
        }
        
        /// <summary>
        /// Reset the ActionPoint to their initial value
        /// </summary>
        public void ResetActionPoints()
        {
            _currentActionPoint = _baseActionPoint;
        }



    }
}
