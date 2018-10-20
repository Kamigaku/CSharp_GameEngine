using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnBaseGame.Entities;

namespace TurnBaseGame.Skills
{
    public class Skill
    {

        #region Enums
        public enum SKILL_SHAPE
        {
            CROSS, LEFT_LINE, RIGHT_LINE, FRONT_LINE, BACK_LINE, FRONT_AND_BACK_LINE,
            LEFT_AND_RIGHT_LINE, CIRCLE
        }

        public enum SKILL_TARGET
        {
            NONE, ME, EVERYONE, TARGET
        }

        public enum SKILL_EFFECT
        {
            DAMAGE, DEFEND, HEAL, SLOW, STUN, ROOT
        }

        public enum SKILL_ORIENTATION
        {
            TOP, LEFT, RIGHT, BOT
        }
        #endregion Enums

        #region Member variables
        //private TextButton _textButton;    // private MonoGame.Extended.Gui.Controls.GuiButton _button;
        private String _skillName;
        private int _apCost;
        private IEntity _caster;
        private SKILL_TARGET _skillTarget;
        private List<SkillEffect> _skillEffects;
        private SKILL_ORIENTATION _skillOrientation;
        private List<Point>[] _orientedRange;
        #endregion Member variables

        public Skill(Skill s, IEntity caster, bool addToHUD)
        {
            _caster = caster;
            _skillName = s._skillName;
            _apCost = s._apCost;
            _skillTarget = s._skillTarget;
            _skillEffects = s._skillEffects;
            _skillOrientation = s._skillOrientation;
            //_textButton = s._textButton;
            if (addToHUD)
                AddListenerToTextButton();
            _orientedRange = s._orientedRange;
        }

        public Skill(IEntity caster, String skillName, int apCost, SKILL_TARGET focusATarget,
                        List<SkillEffect> skillEffects, List<Point> range)
        {
            _caster = caster;
            _skillName = skillName;
            _apCost = apCost;
            _skillTarget = focusATarget;
            _skillEffects = skillEffects;
            _skillOrientation = SKILL_ORIENTATION.TOP;
            //_textButton = new TextButton(skillName, LevelManager.getLevelManager().getLevel().getHUD().getSkin());
            if (this._caster != null)
                AddListenerToTextButton();

            _orientedRange = new List<Point>[4];
            _orientedRange[0] = range;
            for (int i = 1; i < 4; i++)
                _orientedRange[i] = new List<Point>(range.Count);
            for (int i = 0; i < range.Count; i++)
            {
                this._orientedRange[(int)SKILL_ORIENTATION.RIGHT].Add(new Point(range[i].Y, -range[i].X));
                this._orientedRange[(int)SKILL_ORIENTATION.BOT].Add(new Point(-range[i].X, -range[i].Y));
                this._orientedRange[(int)SKILL_ORIENTATION.LEFT].Add(new Point(-range[i].Y, -range[i].X));
            }
        }

        public Skill(IEntity caster, String skillName, int apCost, SKILL_TARGET focusATarget, List<SkillEffect> skillEffects)
        {
            this._caster = caster;
            this._skillName = skillName;
            this._apCost = apCost;
            this._skillTarget = focusATarget;
            this._skillEffects = skillEffects;
            this._skillOrientation = SKILL_ORIENTATION.TOP;
            //this._textButton = new TextButton(skillName, LevelManager.getLevelManager().getLevel().getHUD().getSkin());
            //this._textButton.addListener(new ClickListener() {
            //        @Override
            //        public void clicked(InputEvent event, float x, float y) 
            //        {
            //                FightManager.getFightManager().selectedSkill = Skill.this;
            //        }
            //});
        }
    
        private void AddListenerToTextButton()
        {
            //_textButton.addListener(new ClickListener() {
            //    @Override
            //    public void clicked(InputEvent event, float x, float y)
            //    {
            //        FightManager.getFightManager().selectedSkill = Skill.this;
            //    }

            //    public void enter(InputEvent event, float x, float y, int pointer, Actor fromActor)
            //    {
            //        if (pointer == -1 && FightManager.getFightManager().selectedSkill == null)
            //        {
            //            Layer l = LevelManager.getLevelManager().getLevel().getLayer(Layer.SKILL_HIGHLIGHTER);
            //            for (int i = 0; i < _orientedRange[_skillOrientation.ordinal()].size(); i++)
            //            {
            //                Point casterPosition = _caster.getPhysicsComponent().getPointPosition();
            //                l.addTile(new GroundHighlighter("sprites/ground_highlighter.png",
            //                            casterPosition.x + _orientedRange[_skillOrientation.ordinal()].get(i).x,
            //                            casterPosition.y + _orientedRange[_skillOrientation.ordinal()].get(i).y));
            //            }
            //        }
            //    }

            //    public void exit(InputEvent event, float x, float y, int pointer, Actor toActor)
            //    {
            //        if (pointer == -1)
            //            if (FightManager.getFightManager().selectedSkill == null)
            //                LevelManager.getLevelManager().getLevel().getLayer(Layer.SKILL_HIGHLIGHTER).removeAllTiles();
            //            else if (FightManager.getFightManager().selectedSkill == Skill.this) {
            //            LevelManager.getLevelManager().getLevel().getLayer(Layer.SKILL_HIGHLIGHTER).removeAllTiles();
            //            Skill.this.setSkillOrientation(SKILL_ORIENTATION.TOP);
            //        }
            //    }
            
            //});
        }
    
        public void setCaster(IEntity caster)
        {
            this._caster = caster;
        }

        //public List<Point> getRange(SKILL_ORIENTATION skillOrientation)
        //{
        //    return this._orientedRange[skillOrientation.ordinal()];
        //}

        //public TextButton getTextButton()
        //{
        //    return this._textButton;
        //}
        
        public void setSkillOrientation(SKILL_ORIENTATION skillOrientation)
        {
            //if (skillOrientation != this._skillOrientation)
            //{
            //    this._skillOrientation = skillOrientation;
            //    Layer l = LevelManager.getLevelManager().getLevel().getLayer(Layer.SKILL_HIGHLIGHTER);
            //    l.removeAllTiles();
            //    for (int i = 0; i < _orientedRange[skillOrientation.ordinal()].size(); i++)
            //    {
            //        Point casterPosition = _caster.getPhysicsComponent().getPointPosition();
            //        l.addTile(new GroundHighlighter("sprites/ground_highlighter.png",
            //                    casterPosition.X + _orientedRange[skillOrientation.ordinal()].get(i).x,
            //                    casterPosition.Y + _orientedRange[skillOrientation.ordinal()].get(i).y));
            //    }
            //}
        }
    }
}
