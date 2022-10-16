using FluentAssertions;
using Wizards.Core.Model.UserModels;
using Wizards.Core.ModelExtensions;

namespace Wizards.Tests.CoreTests;
public class HeroExtensionTests
{
    [Fact]
    public void CalculateSkillDamage_WithNullAsHero_ThrowException()
    {
        var skill = new Skill();
        Hero hero = null;
        var result = () => hero.CalculateSkillDamage(skill);

        result.Should().Throw<ArgumentNullException>();

    }

    [Fact]
    public void CalculateSkillDamage_WithNullHeroSkill_ThrowException()
    {
        var hero = new Hero();
        Skill skill = null;
        var result = () => hero.CalculateSkillDamage(skill);

        result.Should().Throw<ArgumentNullException>();

    }

    [Fact]
    public void CalculateSkillHitChance_WithNullAsHero_ThrowException()
    {
        var skill = new Skill();
        Hero hero = null;
        var result = () => hero.CalculateSkillHitChance(skill);

        result.Should().Throw<ArgumentNullException>();

    }

    [Fact]
    public void CalculateSkillHitChance_WithNullHeroSkill_ThrowException()
    {
        var hero = new Hero();
        Skill skill = null;
        var result = () => hero.CalculateSkillHitChance(skill);

        result.Should().Throw<ArgumentNullException>();

    }

    [Fact]
    public void CalculateSkillArmorPenetrationPercent_WithNullAsHero_ThrowException()
    {
        var skill = new Skill();
        Hero hero = null;
        var result = () => hero.CalculateSkillArmorPenetrationPercent(skill);

        result.Should().Throw<ArgumentNullException>();

    }

    [Fact]
    public void CalculateSkillArmorPenetrationPercent_WithNullHeroSkill_ThrowException()
    {
        var hero = new Hero();
        Skill skill = null;
        var result = () => hero.CalculateSkillArmorPenetrationPercent(skill);

        result.Should().Throw<ArgumentNullException>();

    }

    [Fact]
    public void CalculateSkillHealing_WithNullAsHero_ThrowException()
    {
        var skill = new Skill();
        Hero hero = null;
        var result = () => hero.CalculateSkillHealing(skill);

        result.Should().Throw<ArgumentNullException>();

    }

    [Fact]
    public void CalculateSkillHealing_WithNullHeroSkill_ThrowException()
    {
        var hero = new Hero();
        Skill skill = null;
        var result = () => hero.CalculateSkillHealing(skill);

        result.Should().Throw<ArgumentNullException>();

    }
}