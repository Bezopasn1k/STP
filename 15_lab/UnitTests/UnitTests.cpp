#include "pch.h"
#include "CppUnitTest.h"
#include "../TPoly/TMember.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace UnitTests
{
	TEST_CLASS(TMemberTests)
	{
	public:

		// ���� ������������
		TEST_METHOD(TestConstructor)
		{
			TMember member(2, 3);
			Assert::AreEqual(2, member.GetCoeff());
			Assert::AreEqual(3, member.GetDegree());
		}

		// ���� ������ GetDegree
		TEST_METHOD(TestGetDegree)
		{
			TMember member(2, 3);
			Assert::AreEqual(3, member.GetDegree());
		}

		// ���� ������ SetDegree
		TEST_METHOD(TestSetDegree)
		{
			TMember member(2, 3);
			member.SetDegree(5);
			Assert::AreEqual(5, member.GetDegree());
		}

		// ���� ������ GetCoeff
		TEST_METHOD(TestGetCoeff)
		{
			TMember member(2, 3);
			Assert::AreEqual(2, member.GetCoeff());
		}

		// ���� ������ SetCoeff
		TEST_METHOD(TestSetCoeff)
		{
			TMember member(2, 3);
			member.SetCoeff(7);
			Assert::AreEqual(7, member.GetCoeff());
		}

		// ���� ������ IsEqual
		TEST_METHOD(TestIsEqual)
		{
			TMember member1(2, 3);
			TMember member2(2, 3);
			TMember member3(3, 3);

			Assert::IsTrue(member1.IsEqual(member2));
			Assert::IsFalse(member1.IsEqual(member3));
		}

		// ���� ������ Differentiate
		TEST_METHOD(TestDifferentiate)
		{
			TMember member(2, 3);
			TMember derivative = member.Differentiate();
			Assert::AreEqual(6, derivative.GetCoeff());
			Assert::AreEqual(2, derivative.GetDegree());
		}

		// ���� ������ Calculate
		TEST_METHOD(TestCalculate)
		{
			TMember member(2, 3);
			Assert::AreEqual(8, member.Calculate(2));
		}

		// ���� ������ ToString
		TEST_METHOD(TestMethodToString)
		{
			TMember member(2, 3);
			Assert::AreEqual(std::string("2x^3"), member.ToString());
		}
	};
}
