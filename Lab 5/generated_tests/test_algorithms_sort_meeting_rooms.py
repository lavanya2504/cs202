# Test cases automatically generated by Pynguin (https://www.pynguin.eu).
# Please check them before you use them.
import pytest
import algorithms.sort.meeting_rooms as module_0
import builtins as module_1


def test_case_0():
    dict_0 = {}
    var_0 = module_0.can_attend_meetings(dict_0)


@pytest.mark.xfail(strict=True)
def test_case_1():
    bool_0 = True
    module_0.can_attend_meetings(bool_0)


@pytest.mark.xfail(strict=True)
def test_case_2():
    object_0 = module_1.object()
    list_0 = [object_0, object_0, object_0]
    module_0.can_attend_meetings(list_0)
