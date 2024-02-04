namespace Unit.RuleSet;

using NUnit.Framework;
using TestFramework;

public partial class RuleSetFactoryShould : Specification
{
    [TestCase]
    public void ReturnFirstRuleSetWhenRequested()
    {
        Given(a_rule_Set_factory);
        When(requesting_first_rule_set);
        Then(first_rule_set_is_returned);
    }     
    
    [TestCase]
    public void ReturnSecondRuleSetWhenRequested()
    {
        Given(a_rule_Set_factory);
        When(requesting_second_rule_set);
        Then(second_rule_set_is_returned);
    }      
    
    [TestCase]
    public void ReturnThirdRuleSetWhenRequested()
    {
        Given(a_rule_Set_factory);
        When(requesting_third_rule_set);
        Then(third_rule_set_is_returned);
    }      
    
    [TestCase]
    public void ReturnFourthRuleSetWhenRequested()
    {
        Given(a_rule_Set_factory);
        When(requesting_fourth_rule_set);
        Then(fourth_rule_set_is_returned);
    }    
}