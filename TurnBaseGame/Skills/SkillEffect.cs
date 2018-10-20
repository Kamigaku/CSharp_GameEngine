using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnBaseGame.Entities;

namespace TurnBaseGame.Skills
{
    public class SkillEffect
    {

        private Skill.SKILL_EFFECT _skillEffect;
        private int _value;
        // @TODO : add percentage, durée

        public SkillEffect(Skill.SKILL_EFFECT skillEffect, int value)
        {
            this._skillEffect = skillEffect;
            this._value = value;
        }

        public void execute(IEntity target)
        {
            switch (_skillEffect)
            {
                case Skill.SKILL_EFFECT.DAMAGE:
                    target.GetStatistics().CurrentHealthPoint -= _value;
                    break;
                case Skill.SKILL_EFFECT.DEFEND:
                    target.GetStatistics().CurrentDefense += _value;
                    break;
                case Skill.SKILL_EFFECT.HEAL:
                    target.GetStatistics().CurrentHealthPoint += _value;
                    break;
                case Skill.SKILL_EFFECT.SLOW: // attention, pas très bien ça
                case Skill.SKILL_EFFECT.STUN:
                case Skill.SKILL_EFFECT.ROOT:
                    target.GetStatistics().AddStatus(_skillEffect);
                    break;
                default:
                    throw new Exception(_skillEffect.ToString());
            }
        }

        public void reverse(IEntity target)
        {
            switch (_skillEffect)
            {
                case Skill.SKILL_EFFECT.DAMAGE:
                    target.GetStatistics().CurrentHealthPoint += _value;
                    break;
                case Skill.SKILL_EFFECT.DEFEND:
                    target.GetStatistics().CurrentDefense -= _value;
                    break;
                case Skill.SKILL_EFFECT.HEAL:
                    target.GetStatistics().CurrentHealthPoint -= _value;
                    break;
                case Skill.SKILL_EFFECT.SLOW: // attention, pas très bien ça
                case Skill.SKILL_EFFECT.STUN:
                case Skill.SKILL_EFFECT.ROOT:
                    target.GetStatistics().RemoveStatus(_skillEffect);
                    break;
                default:
                    throw new Exception(_skillEffect.ToString());

            }
        }

    }
}
