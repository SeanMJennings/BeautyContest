namespace Unit.RuleSet;

using BeautyContest.Application.RuleSets;
using BeautyContest.Application.RuleSets.Factory;
using FluentAssertions;

public partial class RuleSetFactoryShould
{
    private IAmARuleSetFactory ruleSetFactory = null!;
    private IAmARuleSet ruleSet = null!;
    
    private void a_rule_Set_factory()
    {
        ruleSetFactory = new RuleSetFactory();
    }

    private void requesting_first_rule_set()
    {
        ruleSet = ruleSetFactory.GetRule(RuleSet.One);
    }    
    
    private void requesting_second_rule_set()
    {
        ruleSet = ruleSetFactory.GetRule(RuleSet.Two);
    }    
    
    private void requesting_third_rule_set()
    {
        ruleSet = ruleSetFactory.GetRule(RuleSet.Three);
    }    
    
    private void requesting_fourth_rule_set()
    {
        ruleSet = ruleSetFactory.GetRule(RuleSet.Four);
    }

    private void first_rule_set_is_returned()
    {
        ruleSet.Should().BeOfType<FirstRuleSet>();
    }    
    
    private void second_rule_set_is_returned()
    {
        ruleSet.Should().BeOfType<SecondRuleSet>();
    }    
    
    private void third_rule_set_is_returned()
    {
        ruleSet.Should().BeOfType<ThirdRuleSet>();
    }    
    
    private void fourth_rule_set_is_returned()
    {
        ruleSet.Should().BeOfType<FourthRuleSet>();
    }
}