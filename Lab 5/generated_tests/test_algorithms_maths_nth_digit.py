# Test cases automatically generated by Pynguin (https://www.pynguin.eu).
# Please check them before you use them.
import pytest
import algorithms.maths.nth_digit as module_0


@pytest.mark.xfail(strict=True)
def test_case_0():
    int_0 = 757
    var_0 = module_0.find_nth_digit(int_0)
    assert var_0 == 2
    var_1 = module_0.find_nth_digit(int_0)
    assert var_1 == 2
    var_2 = module_0.find_nth_digit(var_1)
    assert var_2 == 2
    var_3 = module_0.find_nth_digit(var_0)
    assert var_3 == 2
    int_1 = -1499
    module_0.find_nth_digit(int_1)


@pytest.mark.xfail(strict=True)
def test_case_1():
    int_0 = -679
    module_0.find_nth_digit(int_0)
