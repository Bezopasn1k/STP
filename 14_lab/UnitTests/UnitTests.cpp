#include "pch.h"
#include "CppUnitTest.h"
#include "../TSet/TSet.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace UnitTests
{
    // ����� ��� ������ TSet
    TEST_CLASS(TSetTests)
    {
    public:

        // ���� ������������ � �������� �� �������
        TEST_METHOD(TestConstructorAndIsEmpty)
        {
            TSet<int> set;
            Assert::IsTrue(set.isEmpty());
        }

        // ���� ������� � �������� �� ������� ��������
        TEST_METHOD(TestInsertAndContains)
        {
            TSet<int> set;
            set.insert_(5);
            Assert::IsTrue(set.contains(5));
            Assert::IsFalse(set.contains(10));
        }

        // ���� �������� ��������
        TEST_METHOD(TestDelete)
        {
            TSet<int> set;
            set.insert_(5);
            set.del(5);
            Assert::IsFalse(set.contains(5));
        }

        // ���� ����������� ��������
        TEST_METHOD(TestUnion)
        {
            TSet<int> set1, set2;
            set1.insert_(1);
            set1.insert_(2);
            set2.insert_(2);
            set2.insert_(3);

            TSet<int> result = set1.add(set2);
            Assert::IsTrue(result.contains(1));
            Assert::IsTrue(result.contains(2));
            Assert::IsTrue(result.contains(3));
        }

        // ���� �������� ��������
        TEST_METHOD(TestDifference)
        {
            TSet<int> set1, set2;
            set1.insert_(1);
            set1.insert_(2);
            set2.insert_(2);
            set2.insert_(3);

            TSet<int> result = set1.subtract(set2);
            Assert::IsTrue(result.contains(1));
            Assert::IsFalse(result.contains(2));
            Assert::IsFalse(result.contains(3));
        }

        // ���� ����������� ��������
        TEST_METHOD(TestIntersection)
        {
            TSet<int> set1, set2;
            set1.insert_(1);
            set1.insert_(2);
            set2.insert_(2);
            set2.insert_(3);

            TSet<int> result = set1.multiply(set2);
            Assert::IsFalse(result.contains(1));
            Assert::IsTrue(result.contains(2));
            Assert::IsFalse(result.contains(3));
        }

        // ���� �������� ���������
        TEST_METHOD(TestCount)
        {
            TSet<int> set;
            set.insert_(1);
            set.insert_(2);
            set.insert_(3);

            Assert::AreEqual(3, set.count());
        }

        // ���� ��������� �������� �� �������
        TEST_METHOD(TestElement)
        {
            TSet<int> set;
            set.insert_(1);
            set.insert_(2);
            set.insert_(3);

            Assert::AreEqual(2, set.element(1));
            Assert::ExpectException<std::invalid_argument>([&] { set.element(3); });
        }
    };
}
